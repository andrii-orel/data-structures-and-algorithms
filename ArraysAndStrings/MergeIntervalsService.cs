namespace ArraysAndStrings;

public class PaintDrop
{
    public double Start { get; set; }
    public double End { get; set; }
}

public interface IMergeIntervalsService
{
    bool SaveDrop(PaintDrop paintDrop);
}

// This was a coding interview question for Senior .NET position
// Need to implement SaveDrop method
// Idea was taken from Leetcode #56.
// Please see IntervalsService.
public class MergeIntervalsService : IMergeIntervalsService
{
    // [42.222______________________________72.2324]
    // [2.234__________________________________________________12.5344]
    // [5.4322_____________8.2343]	
    // [8.5___________________10]
    // [0____________________________________________________________________________100]
    public bool SaveDrop(PaintDrop paintDrop)
    {
        var paintDrops = GetIntervals();
        paintDrops.Add(paintDrop);

        var intervals = ConvertIntervalsToDoubleArray(paintDrops);
        var mergedIntervals = MergeIntervals1(intervals);
        var result = IsRoadFullyPainted(mergedIntervals);
        
        if (!result)
        {
            // Save Drop
        }
        
        return !result;
    }
    // O(n*log(n))
    public double[][] MergeIntervals1(double[][] intervals)
    {
        Array.Sort(intervals, (a, b) => (int)(a[0] - b[0]));
        var merged = new List<double[]>
        {
            intervals[0]
        };
        for (var i = 1; i < intervals.Length; i++)
        {
            // var currentStart = intervals[i][0];
            // var currentEnd = intervals[i][1];
            // var mergedLastEnd = merged.Last()[1];
            if (intervals[i][0] <= merged.Last()[1])
            {
                merged.Last()[1] = Math.Max(merged.Last()[1], intervals[i][1]);
            }
            else
            {
                merged.Add(intervals[i]);
            }
        }

        return merged.ToArray();
    }
    
    // O(n*log(n))
    public double[][] MergeIntervals2(double[][] intervals)
    {
        Array.Sort(intervals, (a, b) => (int)(a[0] - b[0]));
        LinkedList<double[]> merged = new LinkedList<double[]>();
        foreach (double[] interval in intervals) {
            // If the list of merged intervals is empty or if the current
            // interval does not overlap with the previous, append it
            if (merged.Count == 0 || merged.Last.Value[1] < interval[0]) {
                merged.AddLast(interval);
            }
            // Otherwise, there is overlap, so we merge the current and previous
            // intervals
            else {
                merged.Last.Value[1] =
                    Math.Max(merged.Last.Value[1], interval[1]);
            }
        }

        return merged.ToArray();
    }
    
    // Read from DB as List<PaintDrop>
    public List<PaintDrop> GetIntervals()
    {
        var result = new List<PaintDrop>
        {
            new PaintDrop { Start = 42.222, End = 72.2324, },
            new PaintDrop { Start = 8.5, End = 10, },
            new PaintDrop { Start = 2.234, End = 12.5344, },
            new PaintDrop { Start = 5.4322, End = 8.2343, },
        };
        
        
        return result;
    }

    public double[][] ConvertIntervalsToDoubleArray(List<PaintDrop> paintDrops)
    {
        var result = new double[paintDrops.Count][];
        for (int i = 0; i < paintDrops.Count; i++)
        {
            result[i] = [paintDrops[i].Start, paintDrops[i].End];
        }
        return result;
        // return new double [][]
        // {
        //     [42.222, 72.2324],
        //     [8.5, 10],
        //     [2.234, 12.5344],
        //     [5.4322, 8.2343],
        // };
    }
    
    // Implement in O(1) complexity
    // Tolerance = 18
    public bool IsRoadFullyPainted(double[][] intervals)
    {
        var start = intervals[0][0];
        var end = intervals[0][1];
        return intervals.Length == 1 && start == 0 && Math.Abs(end - 100) < 18;
    }
}