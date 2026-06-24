namespace ArraysAndStrings;

public interface ITwoPointersService
{
    bool IsPalindrome(string s);
    bool IsSubsequence(string s, string t);
}

public class TwoPointersService : ITwoPointersService
{

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
}