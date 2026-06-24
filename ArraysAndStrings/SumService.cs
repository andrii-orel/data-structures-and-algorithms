namespace ArraysAndStrings;

public interface ISumService
{
    int TwoSumUniquePairs(List<int> nums, int target);
    int[] TwoSum(int[] numbers, int target);
    int[] TwoSum2(int[] nums, int target);
    IList<IList<int>> ThreeSum(int[] nums);
}

public class SumService : ISumService
{
    // Amazon Online Assessment (OA) - Two Sum - Unique Pairs
    // Write a function that takes a list of numbers and a target number, and then returns the number of unique pairs that add up to the target number.
    // [X, Y] and [Y, X] are considered the same pair, and not unique.
    //     Examples
    //     Example 1:
    // Input: [1, 1, 2, 45, 46, 46], target = 47
    // Output: 2
    // Explanation:
    // 1 + 46 = 47
    // 2 + 45 = 47
    //
    // Example 2:
    // Input: [1, 1], target = 2
    // Output: 1
    // Explanation:
    // 1 + 1 = 2
    //
    // Example 3:
    // Input: [1, 5, 1, 5], target = 6
    // Output: 1
    // Explanation:
    // [1, 5] and [5, 1] are considered the same, therefore there is only one unique pair that adds up to 6.
    public int TwoSumUniquePairs(List<int> nums, int target)
    {
        var seen = new HashSet<(int, int)>();
        var complement = new HashSet<int>();
        foreach (int num in nums)
        {
            if (complement.Contains(target - num))
            {
                var pair = num < target - num 
                    ? (num, target - num) 
                    : (target - num, num);
                seen.Add(pair);
            }
            complement.Add(num);
        }
        return seen.Count;
    }
    
    // 1. Two Sum
    // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //
    //     You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //
    //     You can return the answer in any order.
    //     Example 1:
    //
    // Input: nums = [2,7,11,15], target = 9
    // Output: [0,1]
    // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    // Example 2:
    //
    // Input: nums = [3,2,4], target = 6
    // Output: [1,2]
    // Example 3:
    //
    // Input: nums = [3,3], target = 6
    // Output: [0,1]
    // Constraints:
    //
    // 2 <= nums.length <= 104
    // -109 <= nums[i] <= 109
    // -109 <= target <= 109
    // Only one valid answer exists.
    public int[] TwoSum(int[] nums, int target)
    {
        var cases = new Dictionary<int,int>();
        for(int i = 0; i < nums.Length - 1; i++){
            var compliment = target - nums[i];
            if(cases.TryGetValue(compliment, out var value)){
                return [cases[value], i];
            }
            cases.Add(nums[i], i);
        }
 
        return [];
        // var map = new Dictionary<int, int>();
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     var complement = target - nums[i];
        //     if (map.TryGetValue(complement, out var value))
        //     {
        //         return [value, i];
        //     }
        //
        //     map[nums[i]] = i;
        // }
        //
        // // Return an empty array if no solution is found
        // return [];
    }


    // 167. Two Sum II - Input Array Is Sorted
    // Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    //
    //     Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
    //
    // The tests are generated such that there is exactly one solution. You may not use the same element twice.
    //
    //     Your solution must use only constant extra space.
    //     Example 1:
    //
    // Input: numbers = [2,7,11,15], target = 9
    // Output: [1,2]
    // Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
    // Example 2:
    //
    // Input: numbers = [2,3,4], target = 6
    // Output: [1,3]
    // Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
    // Example 3:
    //
    // Input: numbers = [-1,0], target = -1
    // Output: [1,2]
    // Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
    public int[] TwoSum2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            int sum = nums[left] + nums[right];
            if (sum == target)
            {
                return new int[] { left + 1, right + 1 };
            }

            if (sum < target)
            {
                ++left;
            }
            else
            {
                --right;
            }
        }

        return new[] { -1, -1 };
    }
    // 15. 3Sum
    // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    //
    // Notice that the solution set must not contain duplicate triplets.
    //
    //     Example 1:
    //
    // Input: nums = [-1,0,1,2,-1,-4]
    // Output: [[-1,-1,2],[-1,0,1]]
    // Explanation: 
    // nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
    // nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
    // nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
    // The distinct triplets are [-1,0,1] and [-1,-1,2].
    // Notice that the order of the output and the order of the triplets does not matter.
    //     Example 2:
    //
    // Input: nums = [0,1,1]
    // Output: []
    // Explanation: The only possible triplet does not sum up to 0.
    // Example 3:
    //
    // Input: nums = [0,0,0]
    // Output: [[0,0,0]]
    // Explanation: The only possible triplet sums up to 0.
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        List<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < nums.Length && nums[i] <= 0; ++i)
            if (i == 0 || nums[i - 1] != nums[i])
            {
                TwoSumII(nums, i, result);
            }

        return result;
    }

    void TwoSumII(int[] nums, int i, List<IList<int>> res)
    {
        int lo = i + 1, hi = nums.Length - 1;
        while (lo < hi)
        {
            int sum = nums[i] + nums[lo] + nums[hi];
            if (sum < 0)
            {
                ++lo;
            }
            else if (sum > 0)
            {
                --hi;
            }
            else
            {
                res.Add(new List<int> { nums[i], nums[lo++], nums[hi--] });
                while (lo < hi && nums[lo] == nums[lo - 1]) ++lo;
            }
        }
    }
}