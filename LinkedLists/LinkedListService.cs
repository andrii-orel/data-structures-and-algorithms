namespace LinkedLists;

public interface ILinkedListService
{
    LeetcodeListNode MiddleNode(LeetcodeListNode head);
    LeetcodeListNode DeleteDuplicates(LeetcodeListNode head);
    LeetcodeListNode ReverseList(LeetcodeListNode head);
    LeetcodeListNode SwapPairs(LeetcodeListNode head);
    LeetcodeListNode ReverseBetween(LeetcodeListNode head, int left, int right);
}

public class LinkedListService : ILinkedListService
{
    // 876. Middle of the Linked List
    // Given the head of a singly linked list, return the middle node of the linked list.
    //     If there are two middle nodes, return the second middle node.
    //     Example 1:
    // Input: head = [1,2,3,4,5]
    // Output: [3,4,5]
    // Explanation: The middle node of the list is node 3.
    //     Example 2:
    // Input: head = [1,2,3,4,5,6]
    // Output: [4,5,6]
    // Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
    //     Constraints:
    // The number of nodes in the list is in the range [1, 100].
    // 1 <= Node.val <= 100
    public LeetcodeListNode MiddleNode(LeetcodeListNode head)
    {
        var slowPointer = head;
        var fastPointer = head;
        while (fastPointer != null && fastPointer.Next != null)
        {
            slowPointer = slowPointer.Next;
            fastPointer = fastPointer.Next.Next;
        }

        return slowPointer;
    }

    // 83. Remove Duplicates from Sorted List
    // Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.
    //     Example 1:
    // Input: head = [1,1,2]
    // Output: [1,2]
    // Example 2:
    // Input: head = [1,1,2,3,3]
    // Output: [1,2,3]
    // Constraints:
    // The number of nodes in the list is in the range [0, 300].
    //     -100 <= Node.val <= 100
    // The list is guaranteed to be sorted in ascending order.
    public LeetcodeListNode DeleteDuplicates(LeetcodeListNode head)
    {
        if (head is null)
            return null;

        var current = head;

        while (current.Next != null)
        {
            if (current.Val == current.Next.Val)
                current.Next = current.Next.Next;
            else
                current = current.Next;
        }

        return head;
    }

    // 206. Reverse Linked List
    // Given the head of a singly linked list, reverse the list, and return the reversed list.
    //     Example 1:
    // Input: head = [1,2,3,4,5]
    // Output: [5,4,3,2,1]
    //     Example 2:
    // Input: head = [1,2]
    // Output: [2,1]
    //     Example 3:
    // Input: head = []
    // Output: []
    // Constraints:
    // The number of nodes in the list is the range [0, 5000].
    //     -5000 <= Node.val <= 5000
    public LeetcodeListNode ReverseList(LeetcodeListNode head)
    {
        LeetcodeListNode prev = null;
        LeetcodeListNode curr = head;
        while (curr != null)
        {
            var next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    // 24. Swap Nodes in Pairs
    // Given a linked list, swap every two adjacent nodes and return its head.
    // You must solve the problem without modifying the values in the list's nodes
    // (i.e., only nodes themselves may be changed.)
    // Example 1:
    // Input: head = [1,2,3,4]
    // Output: [2,1,4,3]
    // Explanation:
    // Example 2:
    // Input: head = []
    // Output: []
    // Example 3:
    // Input: head = [1]
    // Output: [1]
    // Example 4:
    // Input: head = [1,2,3]
    // Output: [2,1,3]
    // Constraints:
    // The number of nodes in the list is in the range [0, 100].
    //     0 <= Node.val <= 100
    public LeetcodeListNode SwapPairs(LeetcodeListNode head)
    {
        // Check edge case: linked list has 0 or 1 nodes, just return
        if (head == null || head.Next == null)
        {
            return head;
        }

        LeetcodeListNode result = head.Next; // Step 5
        LeetcodeListNode prev = null; // Initialize for step 3
        while (head != null && head.Next != null)
        {
            if (prev != null)
            {
                prev.Next = head.Next; // Step 4
            }

            prev = head; // Step 3
            var nextNode = head.Next.Next; // Step 2
            head.Next.Next = head; // Step 1
            head.Next = nextNode; // Step 6
            head = nextNode; // Move to next pair (Step 3)
        }

        return result;
    }

    // 92. Reverse Linked List II
    // Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.
    //     Example 1:
    // Input: head = [1,2,3,4,5], left = 2, right = 4
    // Output: [1,4,3,2,5]
    // Example 2:
    // Input: head = [5], left = 1, right = 1
    // Output: [5]
    // Constraints:
    // The number of nodes in the list is n.
    // 1 <= n <= 500
    // -500 <= Node.val <= 500
    // 1 <= left <= right <= n
    public LeetcodeListNode ReverseBetween(LeetcodeListNode head, int left, int right)
    {
        var temp = new LeetcodeListNode(0, head);
        var before = temp;

        for (var i = 1; i < left; i++)
        {
            before = before.Next;
        }
        
        var prev = before;
        var curr = before.Next;

        for (int i = left; i <= right; i++)
        {
            var next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
        }

        before.Next.Next = curr;
        before.Next = prev;
        
        return temp.Next;
    }
}