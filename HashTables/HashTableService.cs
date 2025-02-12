using System.Text;

namespace HashTables;

public interface IHashTableService
{
    int MajorityElement(int[] nums);
    bool CanConstruct(string ransomNote, string magazine);
    bool IsIsomorphic(string s, string t);
}

public class HashTableService : IHashTableService
{
    // 205. Isomorphic Strings
    // Given two strings s and t, determine if they are isomorphic.
    // Two strings s and t are isomorphic if the characters in s can be replaced to get t.
    // All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.
    // Example 1:
    // Input: s = "egg", t = "add"
    // Output: true
    // Explanation:
    // The strings s and t can be made identical by:
    // Mapping 'e' to 'a'.
    // Mapping 'g' to 'd'.
    // Example 2:
    // Input: s = "foo", t = "bar"
    // Output: false
    // Explanation:
    // The strings s and t can not be made identical as 'o' needs to be mapped to both 'a' and 'r'.
    // Example 3:
    // Input: s = "paper", t = "title"
    // Constraints:
    // 1 <= s.length <= 5 * 104
    // t.length == s.length
    // s and t consist of any valid ascii character.
    public bool IsIsomorphic(string s, string t)
    {
        return TransformString(s).Equals(TransformString(t));
        // int[] mapStoT = new int[256];
        // int[] mapTtoS = new int[256];
        //
        // for(int i=0;i<s.Length;i++) {
        //     char c1 = s[i];
        //     char c2 = t[i];
        //
        //     if(mapStoT[c1] == 0 && mapTtoS[c2] == 0) {
        //         mapStoT[c1] = c2;
        //         mapTtoS[c2] = c1;
        //     } else if(!(mapStoT[c1] == c2 && mapTtoS[c2] == c1)) {
        //         return false;
        //     }
        // }
        //
        // return true;
    }

    private string TransformString(string s)
    {
        const string empty = " ";
        var indexMapping = new Dictionary<char, int>();
        var builder = new StringBuilder();

        for (int i = 0; i < s.Length; ++i)
        {
            var c = s[i];

            if (!indexMapping.ContainsKey(c))
            {
                indexMapping.TryAdd(c, i);
            }

            builder.Append(indexMapping[c].ToString());
            builder.Append(empty);
        }

        return builder.ToString();
    }

    // 169. Majority Element
    // Given an array nums of size n, return the majority element.
    //     The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.
    //     Example 1:
    // Input: nums = [3,2,3]
    // Output: 3
    // Example 2:
    //
    // Input: nums = [2,2,1,1,1,2,2]
    // Output: 2
    // Constraints:
    // n == nums.length
    // 1 <= n <= 5 * 104
    // -109 <= nums[i] <= 109
    public int MajorityElement(int[] nums)
    {
        // var counts = new Dictionary<int, int>();
        // foreach (int num in nums) {
        //     if (!counts.ContainsKey(num)) {
        //         counts.Add(num, 1);
        //     } else {
        //         counts[num]++;
        //     }
        // }
        // foreach (var count in counts) {
        //     if (count.Value > nums.Length / 2)
        //         return count.Key;
        // }
        //
        // return 0;

        // For O(n) time and 0(1) space use Boyer-Moore Voting Algorithm
        int candidate = nums[0];
        int count = 0;

        // Phase 1: Find a candidate for majority element
        foreach (var num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }

            count += (num == candidate) ? 1 : -1;
        }

        // Phase 2: Verify the candidate (optional based on constraints)
        // Assuming the majority element always exists as per the problem.
        return candidate;
    }

    // 383. Ransom Note
    // Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.
    //
    //     Each letter in magazine can only be used once in ransomNote.
    //     Example 1:
    //
    // Input: ransomNote = "a", magazine = "b"
    // Output: false
    // Example 2:
    //
    // Input: ransomNote = "aa", magazine = "ab"
    // Output: false
    // Example 3:
    //
    // Input: ransomNote = "aa", magazine = "aab"
    // Output: true
    // Constraints:
    //
    // 1 <= ransomNote.length, magazine.length <= 105
    // ransomNote and magazine consist of lowercase English letters.
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (ransomNote.Length > magazine.Length)
            return false;

        var ransomNoteDictionary = StrToDictionary(ransomNote);
        // Easy to understand but need improvements
        // var magazineDictionary = StrToDictionary(magazine);
        // foreach (var note in ransomNoteDictionary)
        // {
        //     if (!magazineDictionary.ContainsKey(note.Key) || note.Value > magazineDictionary[note.Key])
        //         return false;
        // }
        // return true;
        foreach (var letter in magazine)
        {
            var l = letter;
            if (ransomNoteDictionary.ContainsKey(l) && ransomNoteDictionary[l] > 0)
            {
                ransomNoteDictionary[l] -= 1;
                if (ransomNoteDictionary[l] == 0)
                    ransomNoteDictionary.Remove(l);
            }

            if (ransomNoteDictionary.Count == 0)
                return true;
        }

        return false;
    }

    private Dictionary<char, int> StrToDictionary(string str)
    {
        var dictionary = new Dictionary<char, int>();
        for (int i = 0; i < str.Length; i++)
        {
            if (!dictionary.ContainsKey(str[i]))
            {
                dictionary.Add(str[i], 1);
            }
            else
            {
                dictionary[str[i]]++;
            }
        }

        return dictionary;
    }

    // 13. Roman to Integer
    // Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    //
    //     Symbol       Value
    // I             1
    // V             5
    // X             10
    // L             50
    // C             100
    // D             500
    // M             1000
    // For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
    //
    //     Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
    //
    // I can be placed before V (5) and X (10) to make 4 and 9. 
    // X can be placed before L (50) and C (100) to make 40 and 90. 
    // C can be placed before D (500) and M (1000) to make 400 and 900.
    // Given a roman numeral, convert it to an integer.
    //     Example 1:
    // Input: s = "III"
    // Output: 3
    // Explanation: III = 3.
    // Example 2:
    // Input: s = "LVIII"
    // Output: 58
    // Explanation: L = 50, V= 5, III = 3.
    // Example 3:
    // Input: s = "MCMXCIV"
    // Output: 1994
    // Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
    //         Constraints:
    //     1 <= s.length <= 15
    // s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
    readonly Dictionary<char, int> _dictionary = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    public int RomanToInt(string s)
    {
        int result = 0;
        int prev = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            var curr = _dictionary[s[i]];
            result += curr < prev ? -curr : curr;
            prev = curr;
        }

        return result;
    }

    public string IntToRoman(int num)
    {
        if (num == 0)
        {
            return string.Empty;
        }

        var result = new StringBuilder();
        int prev = 0;


        return result.ToString();
    }
}