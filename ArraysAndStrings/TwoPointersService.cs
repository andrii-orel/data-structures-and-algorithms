namespace ArraysAndStrings;

public interface ITwoPointersService
{
    int[] TwoSum(int[] numbers, int target);
    int[] TwoSum2(int[] nums, int target);
    IList<IList<int>> ThreeSum(int[] nums);
    bool IsPalindrome(string s);
    bool IsSubsequence(string s, string t);
}

public class TwoPointersService : ITwoPointersService
{
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
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var value))
            {
                return new[] { value, i };
            }

            map[nums[i]] = i;
        }

        // Return an empty array if no solution is found
        return [];
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

    // 125. Valid Palindrome
    // A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
    //
    //     Given a string s, return true if it is a palindrome, or false otherwise.
    //
    //     Example 1:
    //
    // Input: s = "A man, a plan, a canal: Panama"
    // Output: true
    // Explanation: "amanaplanacanalpanama" is a palindrome.
    //     Example 2:
    //
    // Input: s = "race a car"
    // Output: false
    // Explanation: "raceacar" is not a palindrome.
    //     Example 3:
    //
    // Input: s = " "
    // Output: true
    // Explanation: s is an empty string "" after removing non-alphanumeric characters.
    //     Since an empty string reads the same forward and backward, it is a palindrome.
    //
    //
    //     Constraints:
    //
    // 1 <= s.length <= 2 * 105
    // s consists only of printable ASCII characters.
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        var origin = s.ToLower().ToCharArray()
            .Where(x => ((int)x >= 48 && (int)x <= 57) || ((int)x >= 97 && (int)x <= 122))
            .ToArray();

        if (origin.Length == 1)
            return true;

        int left = 0;
        int right = origin.Length - 1;
        while (left < right)
        {
            if (origin[left] != origin[right])
                return false;
            left++;
            right--;
        }

        return true;
    }

    // 392. Is Subsequence
    // Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
    //
    //     A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
    // Example 1:
    //
    // Input: s = "abc", t = "ahbgdc"
    // Output: true
    // Example 2:
    //
    // Input: s = "axc", t = "ahbgdc"
    // Output: false
    //
    //
    // Constraints:
    //
    // 0 <= s.length <= 100
    // 0 <= t.length <= 104
    // s and t consist only of lowercase English letters.
    public bool IsSubsequence(string s, string t)
    {
        var result = false;

        if (s.Length > t.Length)
            return result;
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return true;
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            result = false;
            if (index == t.Length)
                return false;
            for (int j = index; j < t.Length; j++)
            {
                index = j + 1;
                if (s[i] == t[j])
                {
                    result = true;
                    break;
                }
            }
        }

        return result;

        // for(int i = 0; i < t.Length && index < s.Length; i++){
        //     if(t[i] == s[index]){
        //         index++;
        //     }
        // }
        // return (index == s.Length);
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