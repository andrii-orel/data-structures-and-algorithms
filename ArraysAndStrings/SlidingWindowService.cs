namespace ArraysAndStrings;

public interface ISlidingWindowService
{
    int FindLength(int[] nums, int k);
    double FindMaxAverage(int[] nums, int k);
    double FindMaxAverage2(int[] nums, int k);
    int LongestOnes(int[] nums, int k);
}

public class SlidingWindowService : ISlidingWindowService
{
    // Let's use an integer curr that tracks the sum of the current window.
    // Since the problem wants subarrays whose sum is less than or equal to k,
    // we want to maintain curr <= k.
    // Let's look at an example where nums = [3, 1, 2, 7, 4, 2, 1, 1, 5] and k = 8
    public int FindLength(int[] nums, int k)
    {
        int left = 0;
        int curr = 0; // curr is the current sum of the window
        int ans = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            curr += nums[right];
            while (curr > k)
            {
                curr -= nums[left];
                left++;
            }

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }

    // 643. Maximum Average Subarray I
    // You are given an integer array nums consisting of n elements, and an integer k.
    // Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.
    // Any answer with a calculation error less than 10-5 will be accepted.
    // Example 1:
    // Input: nums = [1,12,-5,-6,50,3], k = 4
    // Output: 12.75000
    // Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
    // Example 2:
    // Input: nums = [5], k = 1
    // Output: 5.00000
    // Constraints:
    // n == nums.length
    // 1 <= k <= n <= 105
    // -104 <= nums[i] <= 104
    public double FindMaxAverage(int[] nums, int k)
    {
        int[] sum = new int[nums.Length];
        sum[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            sum[i] = sum[i - 1] + nums[i];
        }

        double result = sum[k - 1] * 1.0 / k;
        for (int i = k; i < nums.Length; i++)
        {
            result = Math.Max(result, (sum[i] - sum[i - k]) * 1.0 / k);
        }

        return result;
    }

    // 643. Maximum Average Subarray I
    public double FindMaxAverage2(int[] nums, int k)
    {
        double sum = 0;
        for (int i = 0; i < k; i++)
        {
            sum += nums[i];
        }

        double result = sum;

        for (int i = k; i < nums.Length; i++)
        {
            sum += nums[i] - nums[i - k];
            result = Math.Max(result, sum);
        }

        return result / k;
    }

    // 1004. Max Consecutive Ones III
    // Given a binary array nums and an integer k,
    // return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
    // Example 1:
    // Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
    // Output: 6
    // Explanation: [1,1,1,0,0,1,1,1,1,1,1]
    // Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
    // Example 2:
    // Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
    // Output: 10
    // Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
    // Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
    //     Constraints:
    // 1 <= nums.length <= 105
    // nums[i] is either 0 or 1.
    // 0 <= k <= nums.length
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0;
        int right;
        for (right = 0; right < nums.Length; right++)
        {
            // If we included a zero in the window we reduce the value of k.
            // Since k is the maximum zeros allowed in a window.
            if (nums[right] == 0)
            {
                k--;
            }

            // A negative k denotes we have consumed all allowed flips and window has
            // more than allowed zeros, thus increment left pointer by 1 to keep the window size same.
            if (k < 0)
            {
                // If the left element to be thrown out is zero we increase k.
                k += 1 - nums[left];
                left++;
            }
        }

        return right - left;
    }
}