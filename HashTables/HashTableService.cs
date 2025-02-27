using System.Text;

namespace HashTables;

public interface IHashTableService
{
    int MajorityElement(int[] nums);
    bool CanConstruct(string ransomNote, string magazine);
    bool IsIsomorphic(string s, string t);
    bool WordPattern(string pattern, string s);
    bool IsAnagram(string s, string t);
    bool IsAnagram2(string s, string t);
    IList<IList<string>> GroupAnagrams(string[] strs);
    IList<IList<string>> GroupAnagrams2(string[] strs);
    IList<IList<string>> GroupAnagrams3(string[] strs);
    bool IsHappy(int n);
    bool IsHappy2(int n);
    bool ContainsNearbyDuplicate(int[] nums, int k);
    bool ContainsNearbyDuplicate2(int[] nums, int k);
    int LongestConsecutive(int[] nums);
}

public class HashTableService : IHashTableService
{
    // 128. Longest Consecutive Sequence
    // Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
    // You must write an algorithm that runs in O(n) time.
    // Example 1:
    // Input: nums = [100,4,200,1,3,2]
    // Output: 4
    // Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
    //     Example 2:
    // Input: nums = [0,3,7,2,5,8,4,6,0,1]
    // Output: 9
    // Constraints:
    // 0 <= nums.length <= 105
    //     -109 <= nums[i] <= 109
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> numSet = new HashSet<int>(nums);
        int longestStreak = 0;
        foreach (int num in numSet)
        {
            if (!numSet.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;
                while (numSet.Contains(currentNum + 1))
                {
                    currentNum += 1;
                    currentStreak += 1;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }

        return longestStreak;
    }

    // 219. Contains Duplicate II
    // Easy
    // Topics
    // Companies
    // Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    //     Example 1:
    // Input: nums = [1,2,3,1], k = 3
    // Output: true
    // Example 2:
    // Input: nums = [1,0,1,1], k = 1
    // Output: true
    // Example 3:
    // Input: nums = [1,2,3,1,2,3], k = 2
    // Output: false
    // Constraints:
    // 1 <= nums.length <= 105
    //     -109 <= nums[i] <= 109
    // 0 <= k <= 105
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var set = new HashSet<int>();
        for (int i = 0; i < nums.Length; ++i)
        {
            if (set.Contains(nums[i]))
                return true;

            set.Add(nums[i]);

            if (set.Count > k)
            {
                set.Remove(nums[i - k]);
            }
        }

        return false;
    }

    public bool ContainsNearbyDuplicate2(int[] nums, int k)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>(nums.Length); // Value : Index
        int i = 0;
        while (i < nums.Length)
        {
            if (!dict.TryAdd(nums[i], i))
            {
                if (i - dict[nums[i]] <= k)
                    return true;

                dict[nums[i]] = i;
            }

            i++;
        }

        return false;
    }

    // 202. Happy Number
    // Easy
    // Topics
    // Companies
    // Write an algorithm to determine if a number n is happy.
    // A happy number is a number defined by the following process:
    // Starting with any positive integer, replace the number by the sum of the squares of its digits.
    // Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
    // Those numbers for which this process ends in 1 are happy.
    // Return true if n is a happy number, and false if not.
    // Example 1:
    // Input: n = 19
    // Output: true
    // Explanation:
    // 12 + 92 = 82
    // 82 + 22 = 68
    // 62 + 82 = 100
    // 12 + 02 + 02 = 1
    // Example 2:
    // Input: n = 2
    // Output: false
    // Constraints:
    // 1 <= n <= 231 - 1
    public bool IsHappy(int n)
    {
        HashSet<int> seen = new HashSet<int>();
        while (n != 1 && !seen.Contains(n))
        {
            seen.Add(n);
            n = GetNext(n);
        }

        return n == 1;
    }

    private int GetNext(int n)
    {
        int totalSum = 0;
        while (n > 0)
        {
            int d = n % 10;
            n /= 10;
            totalSum += d * d;
        }

        return totalSum;
    }

    public bool IsHappy2(int n)
    {
        if (n == 1 || n == 7)
        {
            return true;
        }

        if (n < 10)
        {
            return false;
        }

        int sum = 0;
        while (n > 0)
        {
            int temp = n % 10;
            sum += temp * temp;
            n /= 10;
        }

        return IsHappy(sum);
    }

    // 290. Word Pattern
    // Given a pattern and a string s, find if s follows the same pattern.
    // Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s. Specifically:
    // Each letter in pattern maps to exactly one unique word in s.
    // Each unique word in s maps to exactly one letter in pattern.
    // No two letters map to the same word, and no two words map to the same letter.
    // Example 1:
    // Input: pattern = "abba", s = "dog cat cat dog"
    // Output: true
    // Explanation:
    // The bijection can be established as:
    // 'a' maps to "dog".
    // 'b' maps to "cat".
    // Example 2:
    // Input: pattern = "abba", s = "dog cat cat fish"
    // Output: false
    // Example 3:
    // Input: pattern = "aaaa", s = "dog cat cat dog"
    // Output: false
    // Constraints:
    // 1 <= pattern.length <= 300
    // pattern contains only lower-case English letters.
    // 1 <= s.length <= 3000
    // s contains only lowercase English letters and spaces ' '.
    // s does not contain any leading or trailing spaces.
    // All the words in s are separated by a single space.
    public bool WordPattern(string pattern, string s)
    {
        if (s.Length == 0 || pattern.Length == 0)
            return false;

        var sentences = s.Split(' ');
        if (pattern.Length != sentences.Length)
            return false;

        var mapPatternToS = new Dictionary<char, string>();

        for (int i = 0; i < pattern.Length; i++)
        {
            char c1 = pattern[i];
            string c2 = sentences[i];
            if (!mapPatternToS.ContainsKey(c1) && !mapPatternToS.ContainsValue(c2))
            {
                mapPatternToS.TryAdd(c1, c2);
            }

            if (!mapPatternToS.ContainsKey(c1) || !mapPatternToS[c1].Equals(c2))
            {
                return false;
            }
        }

        return true;
    }

    // 49. Group Anagrams
    // Given an array of strings strs, group the 
    //     anagrams
    // together. You can return the answer in any order.
    //     Example 1:
    // Input: strs = ["eat","tea","tan","ate","nat","bat"]
    // Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
    // Explanation:
    // There is no string in strs that can be rearranged to form "bat".
    // The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
    //     The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
    //     Example 2:
    // Input: strs = [""]
    // Output: [[""]]
    // Example 3:
    // Input: strs = ["a"]
    // Output: [["a"]]
    // Constraints:
    // 1 <= strs.length <= 104
    // 0 <= strs[i].length <= 100
    // strs[i] consists of lowercase English letters.
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();

        foreach (var s in strs)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);

            string key = new string(chars);

            if (!groups.ContainsKey(key))
                groups.Add(key, new List<string>());

            groups[key].Add(s);
        }

        return new List<IList<string>>(groups.Values);
    }

    public IList<IList<string>> GroupAnagrams2(string[] strs)
    {
        var groups = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            int[] count = new int[26];

            foreach (var s in str)
            {
                count[s - 'a']++;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                sb.Append(count[i].ToString());
                sb.Append("#");
            }

            string key = sb.ToString();

            if (!groups.ContainsKey(key))
                groups.Add(key, new List<string>());

            groups[key].Add(str);
        }

        return new List<IList<string>>(groups.Values);
    }

    public IList<IList<string>> GroupAnagrams3(string[] strs)
    {
        /*
        Make dictionary where key is word and value is list of anagrams of that word

        Foreach word in strs...
        - if dictionary contains word with anagram of current word, add current word to its entry
        - if it does not contain, make a new entry with current word as key and add current word to value list

        Make result list of lists

        Foreach entry in dictionary...
        - Add value list of entry to result

        Return result
        */

        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

        foreach (string word in strs)
        {
            // Use sorted version of the word as the key (eat -> aet)
            string sortedWord = string.Concat(word.OrderBy(c => c));

            // Add the word to the appropriate group in the dictionary
            if (!anagrams.ContainsKey(sortedWord))
            {
                //group of words that are aet, for example
                anagrams[sortedWord] = new List<string>();
            }

            //add tea to aet group for example
            anagrams[sortedWord].Add(word);
        }

        // Convert dictionary values to result list
        return anagrams.Values.ToList<IList<string>>();
    }

    public bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var letters = new int[26];

        foreach (var ch in s)
            letters[ch - 'a']++;

        foreach (var ch in t)
            if (--letters[ch - 'a'] < 0)
                return false;

        return true;
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length == 0 || t.Length == 0 || t.Length != s.Length)
            return false;

        var map1 = new Dictionary<char, int>();
        // var map2 = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            char c1 = s[i];
            // char c2 = t[i];
            if (!map1.ContainsKey(c1))
            {
                map1.Add(c1, 1);
            }
            else
            {
                map1[c1]++;
            }

            // if (!map2.ContainsKey(c2))
            // {
            //     map2.Add(c2, 1);
            // }
            // else
            // {
            //     map2[c2]++;
            // }
        }

        // if (map1.Count != map2.Count)
        //     return false;

        foreach (var t1 in t)
        {
            if (!map1.ContainsKey(t1) || map1[t1] == 0)
                return false;

            map1[t1]--;
        }
        // foreach (var m1 in map1)
        // {
        //     if (map2.ContainsKey(m1.Key) || m1.Value != map2[m1.Key])
        //         return false;
        // }

        return true;
    }

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