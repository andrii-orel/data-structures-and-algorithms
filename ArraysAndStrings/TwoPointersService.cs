namespace ArraysAndStrings;

public interface ITwoPointersService
{
    void ReverseString(char[] s);
    char[] ReverseStringDefault(char[] s);
    int[] SortedSquares(int[] nums);
}

public class TwoPointersService : ITwoPointersService
{
    // 344
    // Write a function that reverses a string. The input string is given as an array of characters s.
    // You must do this by modifying the input array in-place with O(1) extra memory.
    // Example 1:
    // Input: s = ["h","e","l","l","o"]
    // Output: ["o","l","l","e","h"]
    // Example 2:
    // Input: s = ["H","a","n","n","a","h"]
    // Output: ["h","a","n","n","a","H"]
    // Constraints:
    // 1 <= s.length <= 105
    // s[i] is a printable ascii character.
    // https://leetcode.com/problems/reverse-string/description/
    public void ReverseString(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            char tmp = s[left];

            s[left++] = s[right];
            s[right--] = tmp;
        }
    }
    
    public char[] ReverseStringDefault(char[] s)
    {
        return s.Reverse().ToArray();
    }

    // 977
    // Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
    // Example 1:
    // Input: nums = [-4,-1,0,3,10]
    // Output: [0,1,9,16,100]
    // Explanation: After squaring, the array becomes [16,1,0,9,100].
    // After sorting, it becomes [0,1,9,16,100].
    // Example 2:
    // Input: nums = [-7,-3,2,3,11]
    // Output: [4,9,9,49,121]
    // Constraints:
    // 1 <= nums.length <= 104
    // -104 <= nums[i] <= 104
    // nums is sorted in non-decreasing order.
    // Follow up: Squaring each element and sorting the new array is very trivial, could you find an O(n) solution using a different approach?
    // https://leetcode.com/problems/squares-of-a-sorted-array/description/
    public int[] SortedSquares(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] *= nums[i];
        }

        int n = nums.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    int temp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = temp;
                }
            }
        }

        return nums;
    }
}