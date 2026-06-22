namespace MathProblems;

public interface ISearchService
{
    int ShipWithinDays(int[] weights, int days);
}

public class SearchService : ISearchService
{
    public int ShipWithinDays(int[] weights, int days)
    {
        if(weights.Length == 0)
            return 0;

        var left = 0; //weights.Max();
        var right = 0; //weights.Sum();

        for (var i = 0; i < weights.Length; i++)
        {
            left = Math.Max(left, weights[i]);
            right += weights[i];
        }
        
        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanDeliver(mid, weights, days))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
    
    private bool CanDeliver(int capacity, int[] weights, int days) {
        var currentWeight = 0;
        var daysNeeded = 1;

        foreach (var weight in weights)
        {
            currentWeight += weight;
            if (currentWeight > capacity) {
                currentWeight = weight;
                daysNeeded++;
            }
        }

        return daysNeeded <= days;
    }
}