namespace StackProblems;

public interface IStackService
{
}

public class StackService : IStackService
{
    // 20. Valid Parentheses
    // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    // An input string is valid if:
    // Open brackets must be closed by the same type of brackets.
    // Open brackets must be closed in the correct order.
    // Every close bracket has a corresponding open bracket of the same type.
    // Example 1:
    // Input: s = "()"
    // Output: true
    // Example 2:
    // Input: s = "()[]{}"
    // Output: true
    // Example 3:
    // Input: s = "(]"
    // Output: false
    // Example 4:
    // Input: s = "([])"
    // Output: true
    // Constraints:
    // 1 <= s.length <= 104
    // s consists of parentheses only '()[]{}'.
    public bool IsValid(string s)
    {
        Dictionary<char, char> matching = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        Stack<char> stack = new Stack<char>();
        foreach (var c in s)
        {
            if (matching.ContainsKey(c))
            {
                // if c is an opening bracket
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char previousOpening = stack.Pop();
                if (matching[previousOpening] != c)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
        
        /*
         Stack<char> strStack = new Stack<char>();
        
        foreach (char c in s) {
            if (c == '(' || c == '{' || c == '[') {
                strStack.Push(c);
            } else {
                if (strStack.Count == 0) return false; 
                char top = strStack.Pop();
                if ((c == ')' && top != '(') || 
                    (c == ']' && top != '[') || 
                    (c == '}' && top != '{')) {
                    return false;
                }
            }
        }
        
        return strStack.Count == 0; 
         */
    }
}