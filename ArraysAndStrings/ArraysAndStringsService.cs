namespace ArraysAndStrings;

public interface IArraysAndStringsService
{
    void ReverseString(char[] s);
    char[] ReverseStringDefault(char[] s);
    int[] SortedSquares(int[] nums);
    bool IsAcronym(IList<string>? words, string s);
    void Merge(int[] nums1, int m, int[] nums2, int n);
    int RemoveElement(int[] nums, int val);
    int RemoveDuplicates(int[] nums);
    int RemoveDuplicates2(int[] nums);
    void Rotate(int[] nums, int k);
    int LengthOfLastWord(string s);
    string ReverseWords(string s);
    string LongestCommonPrefix(string[] strs);
}

public class ArraysAndStringsService : IArraysAndStringsService
{
    // 14. Longest Common Prefix
    // Write a function to find the longest common prefix string amongst an array of strings.
    //
    //     If there is no common prefix, return an empty string "".
    // Example 1:
    //
    // Input: strs = ["flower","flow","flight"]
    // Output: "fl"
    // Example 2:
    //
    // Input: strs = ["dog","racecar","car"]
    // Output: ""
    // Explanation: There is no common prefix among the input strings.
    //     Constraints:
    //
    // 1 <= strs.length <= 200
    // 0 <= strs[i].length <= 200
    // strs[i] consists of only lowercase English letters.
    public string LongestCommonPrefix(string[] strs)
    {
        var result = string.Empty;
        switch (strs.Length)
        {
            case 0:
                return result;
            case 1:
                return strs[0];
        }
        var minLength = strs.Min(str => str.Length);
        var isPrefix = true;
        for (var i = 0; i < minLength; i++)
        {
            for (var j = 1; j < strs.Length; j++)
            {
                if (strs[j].Length >= result.Length && strs[j][i] == strs[0][i])
                    continue;

                isPrefix = false;
                break;
            }
            
            if (isPrefix)
                result += strs[0][i];
            else
                break;
        }

        return result;
    }

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

    // 2828. Check if a String Is an Acronym of Words
    // Given an array of strings words and a string s, determine if s is an acronym of words.
    // The string s is considered an acronym of words if it can be formed by concatenating
    // the first character of each string in words in order. For example,
    // "ab" can be formed from ["apple", "banana"], but it can't be formed from ["bear", "aardvark"].
    // Return true if s is an acronym of words, and false otherwise.
    //     Example 1:
    // Input: words = ["alice","bob","charlie"], s = "abc"
    // Output: true
    // Explanation: The first character in the words "alice", "bob", and "charlie" are 'a', 'b', and 'c', respectively. Hence, s = "abc" is the acronym. 
    //     Example 2:
    // Input: words = ["an","apple"], s = "a"
    // Output: false
    // Explanation: The first character in the words "an" and "apple" are 'a' and 'a', respectively. 
    //     The acronym formed by concatenating these characters is "aa". 
    // Hence, s = "a" is not the acronym.
    //     Example 3:
    // Input: words = ["never","gonna","give","up","on","you"], s = "ngguoy"
    // Output: true
    // Explanation: By concatenating the first character of the words in the array, we get the string "ngguoy". 
    // Hence, s = "ngguoy" is the acronym.
    //     Constraints:
    // 1 <= words.length <= 100
    // 1 <= words[i].length <= 10
    // 1 <= s.length <= 100
    // words[i] and s consist of lowercase English letters.
    public bool IsAcronym(IList<string>? words, string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;

        char[] abbr = s.ToCharArray();
        if (words == null || words.Count == 0 || abbr.Length != words.Count)
            return false;


        for (int i = 0; i < words.Count; i++)
        {
            char[] word = words[i].ToCharArray();
            if (!word[0].Equals(abbr[i]))
            {
                return false;
            }
        }

        return true;
    }

    // 88. Merge Sorted Array
    // You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
    //
    //     Merge nums1 and nums2 into a single array sorted in non-decreasing order.
    //
    //     The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
    //     Example 1:
    //
    // Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    // Output: [1,2,2,3,5,6]
    // Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
    // The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
    //     Example 2:
    //
    // Input: nums1 = [1], m = 1, nums2 = [], n = 0
    // Output: [1]
    // Explanation: The arrays we are merging are [1] and [].
    // The result of the merge is [1].
    // Example 3:
    //
    // Input: nums1 = [0], m = 0, nums2 = [1], n = 1
    // Output: [1]
    // Explanation: The arrays we are merging are [] and [1].
    // The result of the merge is [1].
    // Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
    //     Constraints:
    //
    // nums1.length == m + n
    //     nums2.length == n
    // 0 <= m, n <= 200
    // 1 <= m + n <= 200
    // -109 <= nums1[i], nums2[j] <= 109
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // Two get pointers for nums1 and nums2
        int p1 = m - 1;
        int p2 = n - 1;
        // Set pointer for nums1
        int p = m + n - 1;

        // While there are still elements to compare
        while (p1 >= 0 && p2 >= 0)
        {
            // Compare two elements from nums1 and nums2 
            // and add the largest one in nums1 
            nums1[p--] = nums1[p1] < nums2[p2] ? nums2[p2--] : nums1[p1--];
        }

        // Add missing elements from nums2
        Array.Copy(nums2, 0, nums1, 0, p2 + 1);
    }

    // 27. Remove Element
    // Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
    //
    //     Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
    //
    // Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
    //     Return k.
    //     Custom Judge:
    //
    // The judge will test your solution with the following code:
    //
    // int[] nums = [...]; // Input array
    // int val = ...; // Value to remove
    // int[] expectedNums = [...]; // The expected answer with correct length.
    // // It is sorted with no values equaling val.
    //
    // int k = removeElement(nums, val); // Calls your implementation
    //
    // assert k == expectedNums.length;
    // sort(nums, 0, k); // Sort the first k elements of nums
    //     for (int i = 0; i < actualLength; i++) {
    //     assert nums[i] == expectedNums[i];
    // }
    // If all assertions pass, then your solution will be accepted.
    //
    //
    //
    //     Example 1:
    //
    // Input: nums = [3,2,2,3], val = 3
    // Output: 2, nums = [2,2,_,_]
    // Explanation: Your function should return k = 2, with the first two elements of nums being 2.
    // It does not matter what you leave beyond the returned k (hence they are underscores).
    // Example 2:
    //
    // Input: nums = [0,1,2,2,3,0,4,2], val = 2
    // Output: 5, nums = [0,1,4,0,3,_,_,_]
    // Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
    // Note that the five elements can be returned in any order.
    //     It does not matter what you leave beyond the returned k (hence they are underscores).
    //
    //
    // Constraints:
    //
    // 0 <= nums.length <= 100
    // 0 <= nums[i] <= 50
    // 0 <= val <= 100
    public int RemoveElement(int[] nums, int val)
    {
        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    // 26. Remove Duplicates from Sorted Array
    // Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.
    //
    //     Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:
    //
    // Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
    //     Return k.
    //     Custom Judge:
    //
    // The judge will test your solution with the following code:
    //
    // int[] nums = [...]; // Input array
    // int[] expectedNums = [...]; // The expected answer with correct length
    //
    // int k = removeDuplicates(nums); // Calls your implementation
    //
    // assert k == expectedNums.length;
    // for (int i = 0; i < k; i++) {
    //     assert nums[i] == expectedNums[i];
    // }
    // If all assertions pass, then your solution will be accepted.
    //
    //
    //
    //     Example 1:
    //
    // Input: nums = [1,1,2]
    // Output: 2, nums = [1,2,_]
    // Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
    //     It does not matter what you leave beyond the returned k (hence they are underscores).
    // Example 2:
    //
    // Input: nums = [0,0,1,1,1,2,2,3,3,4]
    // Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
    // Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
    //     It does not matter what you leave beyond the returned k (hence they are underscores).
    //
    //
    // Constraints:
    //
    // 1 <= nums.length <= 3 * 104
    // -100 <= nums[i] <= 100
    // nums is sorted in non-decreasing order.
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int k = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] != nums[i])
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    // 80. Remove Duplicates from Sorted Array II
    // Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.
    //
    //     Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
    //
    //     Return k after placing the final result in the first k slots of nums.
    //
    //     Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    //
    //     Custom Judge:
    //
    // The judge will test your solution with the following code:
    //
    // int[] nums = [...]; // Input array
    // int[] expectedNums = [...]; // The expected answer with correct length
    //
    // int k = removeDuplicates(nums); // Calls your implementation
    //
    // assert k == expectedNums.length;
    // for (int i = 0; i < k; i++) {
    //     assert nums[i] == expectedNums[i];
    // }
    // If all assertions pass, then your solution will be accepted.
    //
    //
    //
    //     Example 1:
    //
    // Input: nums = [1,1,1,2,2,3]
    // Output: 5, nums = [1,1,2,2,3,_]
    // Explanation: Your function should return k = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
    //     It does not matter what you leave beyond the returned k (hence they are underscores).
    // Example 2:
    //
    // Input: nums = [0,0,1,1,1,1,2,3,3]
    // Output: 7, nums = [0,0,1,1,2,3,3,_,_]
    // Explanation: Your function should return k = 7, with the first seven elements of nums being 0, 0, 1, 1, 2, 3 and 3 respectively.
    //     It does not matter what you leave beyond the returned k (hence they are underscores).
    //
    //
    // Constraints:
    //
    // 1 <= nums.length <= 3 * 104
    // -104 <= nums[i] <= 104
    // nums is sorted in non-decreasing order.
    public int RemoveDuplicates2(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int k = 0;
        int j = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            int current = nums[k];
            int next = nums[i];

            if (current != next)
            {
                j = 0;
            }

            if (current != next || (current == next && j < 2))
            {
                k++;
                j++;
                nums[k] = next;
            }
        }

        return k + 1;
    }

    // 189. Rotate Array
    // Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    //     Example 1:
    //
    // Input: nums = [1,2,3,4,5,6,7], k = 3
    // Output: [5,6,7,1,2,3,4]
    // Explanation:
    // rotate 1 steps to the right: [7,1,2,3,4,5,6]
    // rotate 2 steps to the right: [6,7,1,2,3,4,5]
    // rotate 3 steps to the right: [5,6,7,1,2,3,4]
    // Example 2:
    //
    // Input: nums = [-1,-100,3,99], k = 2
    // Output: [3,99,-1,-100]
    // Explanation: 
    // rotate 1 steps to the right: [99,-1,-100,3]
    // rotate 2 steps to the right: [3,99,-1,-100]
    //
    //
    // Constraints:
    //
    // 1 <= nums.length <= 105
    // -231 <= nums[i] <= 231 - 1
    // 0 <= k <= 105
    public void Rotate(int[] nums, int k)
    {
        if (nums.Length != 0 && k != 0)
        {
            int step = k > nums.Length ? k % nums.Length : k;
            int startIndex = nums.Length - step;
            int[] tmp = new int[nums.Length];
            Array.Copy(nums, 0, tmp, 0, nums.Length);
            Array.Copy(tmp, startIndex, nums, 0, step);
            for (int i = step; i < nums.Length; i++)
            {
                int val = tmp[i - step];
                nums[i] = val;
            }
        }
    }

    // 58. Length of Last Word
    // Given a string s consisting of words and spaces, return the length of the last word in the string.
    //
    // A word is a maximal 
    // substring
    //     consisting of non-space characters only.
    //     Example 1:
    //
    // Input: s = "Hello World"
    // Output: 5
    // Explanation: The last word is "World" with length 5.
    // Example 2:
    //
    // Input: s = "   fly me   to   the moon  "
    // Output: 4
    // Explanation: The last word is "moon" with length 4.
    // Example 3:
    //
    // Input: s = "luffy is still joyboy"
    // Output: 6
    // Explanation: The last word is "joyboy" with length 6.
    public int LengthOfLastWord(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int result = words.Last().Length;
        return result;

        // s = s.Trim();
        // int li = s.LastIndexOf(' ');
        // return (s.Substring(li+1, s.Length-1 - li)).Length;
    }

    // 151. Reverse Words in a String
    // Given an input string s, reverse the order of the words.
    //
    //     A word is defined as a sequence of non-space characters. The words in s will be separated by at least one space.
    //
    //     Return a string of the words in reverse order concatenated by a single space.
    //
    //     Note that s may contain leading or trailing spaces or multiple spaces between two words. The returned string should only have a single space separating the words. Do not include any extra spaces.
    //     Example 1:
    //
    // Input: s = "the sky is blue"
    // Output: "blue is sky the"
    // Example 2:
    //
    // Input: s = "  hello world  "
    // Output: "world hello"
    // Explanation: Your reversed string should not contain leading or trailing spaces.
    //     Example 3:
    //
    // Input: s = "a good   example"
    // Output: "example good a"
    // Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
    //
    //
    // Constraints:
    //
    // 1 <= s.length <= 104
    // s contains English letters (upper-case and lower-case), digits, and spaces ' '.
    // There is at least one word in s.
    public string ReverseWords(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", words.Reverse());
    }
}