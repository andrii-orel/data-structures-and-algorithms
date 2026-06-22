namespace ArraysAndStrings;
public interface IGridPrinter
{
    Task PrintGrid(string url);
}

public class GridPrinter :  IGridPrinter
{
    public async Task PrintGrid(string url)
    {
        // Transform URL to TSV export link if needed
        if (url.Contains("/edit"))
        {
            var docId = ExtractDocId(url);
            url = $"https://docs.google.com/document/d/{docId}/export?format=tsv";
        }

        using var httpClient = new HttpClient();
        string tsvContent = await httpClient.GetStringAsync(url);

        var xCoords = new List<int>();
        var yCoords = new List<int>();
        var characters = new List<char>();

        string[] lines = tsvContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Skip header
        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split('\t');

            if (cols.Length < 3)
                continue;

            int x = int.Parse(cols[0].Trim());
            string characterStr = cols[1].Trim();
            int y = int.Parse(cols[2].Trim());

            if (characterStr.Length != 1)
                continue;

            xCoords.Add(x);
            yCoords.Add(y);
            characters.Add(characterStr[0]);
        }

        int maxX = 0;
        int maxY = 0;

        for (int i = 0; i < xCoords.Count; i++)
        {
            maxX = Math.Max(maxX, xCoords[i]);
            maxY = Math.Max(maxY, yCoords[i]);
        }

        // Initialize grid
        char[,] grid = new char[maxY + 1, maxX + 1];

        for (int y = 0; y <= maxY; y++)
            for (int x = 0; x <= maxX; x++)
                grid[y, x] = ' ';

        // Place characters
        for (int i = 0; i < characters.Count; i++)
        {
            int x = xCoords[i];
            int y = yCoords[i];
            grid[y, x] = characters[i];
        }

        // Print grid
        for (int y = 0; y <= maxY; y++)
        {
            for (int x = 0; x <= maxX; x++)
            {
                Console.Write(grid[y, x]);
            }
            Console.WriteLine();
        }
    }

    private static string? ExtractDocId(string url)
    {
        var start = url.IndexOf("/d/") + 3;
        var end = url.IndexOf("/", start);
        if (start >= 0 && end > start)
            return url.Substring(start, end - start);

        return null;
    }
}
