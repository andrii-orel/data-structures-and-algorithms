namespace ArraysAndStrings;

public interface IIntervalsService
{
    int[][] Merge(int[][] intervals);
    IList<string> SummaryRanges(int[] nums);
    int[][] Insert(int[][] intervals, int[] newInterval);
    int FindMinArrowShots(int[][] points);
}

public class IntervalsService : IIntervalsService
{
    // 452. Minimum Number of Arrows to Burst Balloons
    // There are some spherical balloons taped onto a flat wall that represents the XY-plane. The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] denotes a balloon whose horizontal diameter stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.
    //     Arrows can be shot up directly vertically (in the positive y-direction) from different points along the x-axis. A balloon with xstart and xend is burst by an arrow shot at x if xstart <= x <= xend. There is no limit to the number of arrows that can be shot. A shot arrow keeps traveling up infinitely, bursting any balloons in its path.
    //     Given the array points, return the minimum number of arrows that must be shot to burst all balloons.
    //     Example 1:
    // Input: points = [[10,16],[2,8],[1,6],[7,12]]
    // Output: 2
    // Explanation: The balloons can be burst by 2 arrows:
    // - Shoot an arrow at x = 6, bursting the balloons [2,8] and [1,6].
    // - Shoot an arrow at x = 11, bursting the balloons [10,16] and [7,12].
    //     Example 2:
    // Input: points = [[1,2],[3,4],[5,6],[7,8]]
    // Output: 4
    // Explanation: One arrow needs to be shot for each balloon for a total of 4 arrows.
    //     Example 3:
    // Input: points = [[1,2],[2,3],[3,4],[4,5]]
    // Output: 2
    // Explanation: The balloons can be burst by 2 arrows:
    // - Shoot an arrow at x = 2, bursting the balloons [1,2] and [2,3].
    // - Shoot an arrow at x = 4, bursting the balloons [3,4] and [4,5].
    //     Constraints:
    // 1 <= points.length <= 105
    // points[i].length == 2
    //     -231 <= xstart < xend <= 231 - 1
    public int FindMinArrowShots(int[][] points)
    {
        // Sort the balloons based on their end coordinates
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

        int arrows = 1;
        int prevEnd = points[0][1];

        // Count the number of non-overlapping intervals
        for (int i = 1; i < points.Length; ++i) {
            if (points[i][0] > prevEnd) {
                arrows++;
                prevEnd = points[i][1];
            }
        }

        return arrows;
    }

    // 57. Insert Interval
    // You are given an array of non-overlapping intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
    //     Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).
    // Return intervals after the insertion.
    //     Note that you don't need to modify intervals in-place. You can make a new array and return it.
    //     Example 1:
    // Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
    // Output: [[1,5],[6,9]]
    // Example 2:
    // Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    // Output: [[1,2],[3,10],[12,16]]
    // Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
    //     Constraints:
    // 0 <= intervals.length <= 104
    // intervals[i].length == 2
    // 0 <= starti <= endi <= 105
    // intervals is sorted by starti in ascending order.
    //     newInterval.length == 2
    // 0 <= start <= end <= 105
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int n = intervals.Length, i = 0;
        var result = new List<int[]>();

        // Case 1: No overlapping before merging intervals
        while (i < n && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

        // Case 2: Overlapping and merging intervals
        while (i < n && newInterval[1] >= intervals[i][0])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        result.Add(newInterval);

        // Case 3: No overlapping after merging newInterval
        while (i < n)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }

    // 228. Summary Ranges
    // You are given a sorted unique integer array nums.
    // A range [a,b] is the set of all integers from a to b (inclusive).
    //     Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.
    //     Each range [a,b] in the list should be output as:
    // "a->b" if a != b
    // "a" if a == b
    // Example 1:
    // Input: nums = [0,1,2,4,5,7]
    // Output: ["0->2","4->5","7"]
    // Explanation: The ranges are:
    // [0,2] --> "0->2"
    //     [4,5] --> "4->5"
    //     [7,7] --> "7"
    // Example 2:
    // Input: nums = [0,2,3,4,6,8,9]
    // Output: ["0","2->4","6","8->9"]
    // Explanation: The ranges are:
    // [0,0] --> "0"
    //     [2,4] --> "2->4"
    //     [6,6] --> "6"
    //     [8,9] --> "8->9"
    // Constraints:
    // 0 <= nums.length <= 20
    //     -231 <= nums[i] <= 231 - 1
    // All the values of nums are unique.
    //     nums is sorted in ascending order.
    public IList<string> SummaryRanges(int[] nums)
    {
        const string to = "->";
        var ranges = new List<string>();

        for (var i = 0; i < nums.Length; i++)
        {
            var start = nums[i];
            // Keep iterating until the next element is one more than the current element.
            while (i + 1 < nums.Length && nums[i] + 1 == nums[i + 1])
            {
                i++;
            }

            ranges.Add(start != nums[i] ? $"{start}{to}{nums[i]}" : start.ToString());
        }

        return ranges;
    }

    // 56. Merge Intervals
    // Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
    //     Example 1:
    // Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    // Output: [[1,6],[8,10],[15,18]]
    // Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
    //     Example 2:
    // Input: intervals = [[1,4],[4,5]]
    // Output: [[1,5]]
    // Explanation: Intervals [1,4] and [4,5] are considered overlapping.
    //     Constraints:
    // 1 <= intervals.length <= 104
    // intervals[i].length == 2
    // 0 <= starti <= endi <= 104
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        var merged = new List<int[]>()
        {
            intervals[0]
        };

        for (var i = 1; i < intervals.Length; i++)
        {
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
}