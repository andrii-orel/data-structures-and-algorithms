﻿namespace ArraysAndStrings;

public interface IPrefixSumService
{
    int WaysToSplitArray(int[] nums);
    int WaysToSplitArray2(int[] nums);
    int[] RunningSum(int[] nums);
}

public class PrefixSumService : IPrefixSumService
{
    // 2270. Number of Ways to Split Array
    // Medium
    // You are given a 0-indexed integer array nums of length n.
    // nums contains a valid split at index i if the following are true:
    // The sum of the first i + 1 elements is greater than or equal to the sum of the last n - i - 1 elements.
    // There is at least one element to the right of i. That is, 0 <= i < n - 1.
    // Return the number of valid splits in nums.
    // Example 1:
    // Input: nums = [10,4,-8,7]
    // Output: 2
    // Explanation: 
    // There are three ways of splitting nums into two non-empty parts:
    // - Split nums at index 0. Then, the first part is [10], and its sum is 10. The second part is [4,-8,7], and its sum is 3. Since 10 >= 3, i = 0 is a valid split.
    // - Split nums at index 1. Then, the first part is [10,4], and its sum is 14. The second part is [-8,7], and its sum is -1. Since 14 >= -1, i = 1 is a valid split.
    // - Split nums at index 2. Then, the first part is [10,4,-8], and its sum is 6. The second part is [7], and its sum is 7. Since 6 < 7, i = 2 is not a valid split.
    // Thus, the number of valid splits in nums is 2.
    // Example 2:
    // Input: nums = [2,3,1,0]
    // Output: 2
    // Explanation: 
    // There are two valid splits in nums:
    // - Split nums at index 1. Then, the first part is [2,3], and its sum is 5. The second part is [1,0], and its sum is 1. Since 5 >= 1, i = 1 is a valid split. 
    // - Split nums at index 2. Then, the first part is [2,3,1], and its sum is 6. The second part is [0], and its sum is 0. Since 6 >= 0, i = 2 is a valid split.
    // Constraints:
    // 2 <= nums.length <= 105
    // -105 <= nums[i] <= 105
    public int WaysToSplitArray(int[] nums)
    {
        int n = nums.Length;
        long[] prefix = new long[n];
        prefix[0] = nums[0];
        // Create prefix array
        for (int i = 1; i < n; i++)
        {
            prefix[i] = nums[i] + prefix[i - 1];
        }

        int result = 0;
        for (int i = 0; i < n - 1; i++)
        {
            long leftSection = prefix[i];
            long rightSection = prefix[n - 1] - prefix[i];
            if (leftSection >= rightSection)
            {
                result++;
            }
        }

        return result;
    }

    public int WaysToSplitArray2(int[] nums)
    {
        int result = 0;
        long leftSection = 0;
        long total = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }
        // foreach (var num in nums)
        // {
        //     total += num;
        // }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            leftSection += nums[i];
            long rightSection = total - leftSection;
            if (leftSection >= rightSection)
            {
                result++;
            }
        }

        return result;
    }

    // https://leetcode.com/problems/running-sum-of-1d-array/submissions/1319759787/
    // Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
    // Return the running sum of nums.
    // Example 1:
    // Input: nums = [1,2,3,4]
    // Output: [1,3,6,10]
    // Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].
    // Example 2:
    // Input: nums = [1,1,1,1,1]
    // Output: [1,2,3,4,5]
    // Explanation: Running sum is obtained as follows: [1, 1+1, 1+1+1, 1+1+1+1, 1+1+1+1+1].
    // Example 3:
    // Input: nums = [3,1,2,10,1]
    // Output: [3,4,6,16,17]
    // Constraints:
    // 1 <= nums.length <= 1000
    // -10^6 <= nums[i] <= 10^6
    public int[] RunningSum(int[] nums)
    {
        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }

        return nums;
    }
    // I have SQL query which I need to fix. Declare @processCode
    // DECLARE @processCode VARCHAR (50) = 'OA'
    // Declare @contentType VARCHAR (50) = 'Incremental'
    // SELECT
    // Process_Code, Subscription ID, Latest Flag, File Pattern, Content Type, File Name
    // FROM
    // ref.PROCESS SUBSCRIPTION ps
    // WHERE
    // ps.Deleted Flag = 0
    // AND ( IF(@contentType IS NULL) THEN @processCode IS NULL OR @processCode ps. Process Code
    // ELSE @processCode = ps.Process Code AND @contentType = ps.Content Type)

}