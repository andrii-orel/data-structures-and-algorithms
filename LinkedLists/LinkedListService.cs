namespace LinkedLists;

public interface ILinkedListService
{
    Node MiddleNode(Node head);
    Node DeleteDuplicates(Node head);
    Node ReverseList(Node head);
    Node SwapPairs(Node head);
    Node ReverseBetween(Node head, int left, int right);
    bool HasCycle(Node head);
    Node MergeTwoLists(Node list1, Node list2);
    Node2 CopyRandomList(Node2 head);
    ListNode RotateRight(ListNode head, int k);
    ListNode DeleteDuplicates2(ListNode head);
    ListNode Partition(ListNode head, int x);
}

public class LinkedListService : ILinkedListService
{
    

    // 86. Partition List
    // Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
    // You should preserve the original relative order of the nodes in each of the two partitions.
    // Example 1:
    // Input: head = [1,4,3,2,5,2], x = 3
    // Output: [1,2,2,4,3,5]
    // Example 2:
    // Input: head = [2,1], x = 2
    // Output: [1,2]
    // Constraints:
    // The number of nodes in the list is in the range [0, 200].
    // -100 <= Node.Val <= 100
    //     -200 <= x <= 200
    public ListNode Partition(ListNode head, int x)
    {
        var beforeHead = new ListNode(0);
        var before = beforeHead;
        var afterHead = new ListNode(0);
        var after = afterHead;
        while (head != null)
        {
            if (head.Val < x)
            {
                before.Next = head;
                before = before.Next;
            }
            else
            {
                after.Next = head;
                after = after.Next;
            }

            head = head.Next;
        }

        after.Next = null;
        before.Next = afterHead.Next;

        return beforeHead.Next;
    }

    // 82. Remove Duplicates from Sorted List II
    // Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.
    // Example 1:
    // Input: head = [1,2,3,3,4,4,5]
    // Output: [1,2,5]
    // Example 2:
    // Input: head = [1,1,1,2,3]
    // Output: [2,3]
    // Constraints:
    // The number of nodes in the list is in the range [0, 300].
    // -100 <= Node.Val <= 100
    // The list is guaranteed to be sorted in ascending order.
    public ListNode DeleteDuplicates2(ListNode head)
    {
        // sentinel
        ListNode sentinel = new ListNode(0, head);
        // predecessor = the last node
        // before the sublist of duplicates
        ListNode predecessor = sentinel;
        while (head != null)
        {
            // If it's a beginning of duplicates sublist
            // skip all duplicates
            if (head.Next != null && head.Val == head.Next.Val)
            {
                // Skip all duplicates
                // move till the end of duplicates sublist
                while (head.Next != null && head.Val == head.Next.Val)
                {
                    head = head.Next;
                }

                // otherwise, move predecessor
                predecessor.Next = head.Next;
            }
            else
            {
                predecessor = predecessor.Next;
            }

            // move forward
            head = head.Next;
        }

        return sentinel.Next;
    }

    // 61. Rotate List
    // Given the head of a linked list, rotate the list to the right by k places.
    // Example 1:
    // Input: head = [1,2,3,4,5], k = 2
    // Output: [4,5,1,2,3]
    // Example 2:
    // Input: head = [0,1,2], k = 4
    // Output: [2,0,1]
    // Constraints:
    // The number of nodes in the list is in the range [0, 500].
    // -100 <= Node.Val <= 100
    // 0 <= k <= 2 * 109
    public ListNode RotateRight(ListNode head, int k)
    {
        // base cases
        if (head == null)
            return null;

        if (head.Next == null)
            return head;

        // close the linked list into the ring
        ListNode oldTail = head;
        int n;
        for (n = 1; oldTail.Next is not null; n++)
        {
            oldTail = oldTail.Next;
        }

        oldTail.Next = head;

        // find new tail : (n - k % n - 1)th node
        // and new head : (n - k % n)th node
        ListNode newTail = head;
        for (int i = 0; i < n - k % n - 1; i++)
        {
            newTail = newTail.Next;
        }

        ListNode newHead = newTail.Next;

        // break the ring
        newTail.Next = null;

        return newHead;
    }

    // 19. Remove Nth Node From End of List
    // Medium
    // Given the head of a linked list, remove the nth node from the end of the list and return its head.
    // Example 1:
    // Input: head = [1,2,3,4,5], n = 2
    // Output: [1,2,3,5]
    // Example 2:
    // Input: head = [1], n = 1
    // Output: []
    // Example 3:
    // Input: head = [1,2], n = 1
    // Output: [1]
    // Constraints:
    // The number of nodes in the list is sz.
    // 1 <= sz <= 30
    // 0 <= Node.Val <= 100
    // 1 <= n <= sz
    // Follow up: Could you do this in one pass?
    public Node RemoveNthFromEnd(Node head, int n)
    {
        var dummy = new Node
        {
            Next = head
        };

        var first = dummy;
        var second = dummy;
        // Advances first pointer so that the gap between first and second is n
        // nodes apart
        for (int i = 1; i <= n + 1; i++)
        {
            first = first.Next;
        }

        // Move first to the end, maintaining the gap
        while (first != null)
        {
            first = first.Next;
            second = second.Next;
        }

        second.Next = second.Next.Next;

        return dummy.Next;
    }

    // 138. Copy List with Random Pointer
    // Medium
    // A linked list of length n is given such that each node contains an additional random pointer, which could point to any node in the list, or null.
    // Construct a deep copy of the list. The deep copy should consist of exactly n brand new nodes, where each new node has its value set to the value of its corresponding original node. Both the next and random pointer of the new nodes should point to new nodes in the copied list such that the pointers in the original list and copied list represent the same list state. None of the pointers in the new list should point to nodes in the original list.
    //     For example, if there are two nodes X and Y in the original list, where X.Random --> Y, then for the corresponding two nodes x and y in the copied list, x.Random --> y.
    //     Return the head of the copied linked list.
    //     The linked list is represented in the input/output as a list of n nodes. Each node is represented as a pair of [val, random_index] where:
    // val: an integer representing Node.Val
    // random_index: the index of the node (range from 0 to n-1) that the random pointer points to, or null if it does not point to any node.
    //     Your code will only be given the head of the original linked list.
    //     Example 1:
    // Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
    // Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]
    // Example 2:
    // Input: head = [[1,1],[2,1]]
    // Output: [[1,1],[2,1]]
    // Example 3:
    // Input: head = [[3,null],[3,0],[3,null]]
    // Output: [[3,null],[3,0],[3,null]]
    // Constraints:
    // 0 <= n <= 1000
    //     -104 <= Node.Val <= 104
    // Node.Random is null or is pointing to some node in the linked list.
    public Node2 CopyRandomList(Node2 head)
    {
        if (head == null)
        {
            return null;
        }

        // Creating a new weaved list of original and copied nodes.
        Node2 ptr = head;
        while (ptr != null)
        {
            // Cloned node
            Node2 newNode = new Node2(ptr.Val)
            {
                // Inserting the cloned node just next to the original node.
                // If A->B->C is the original linked list,
                // Linked list after weaving cloned nodes would be
                // A->A'->B->B'->C->C'
                Next = ptr.Next
            };

            ptr.Next = newNode;
            ptr = newNode.Next;
        }

        ptr = head;

        // Now link the random pointers of the new nodes created.
        // Iterate the newly created list and use the original nodes' random
        // pointers, to assign references to random pointers for cloned nodes.
        while (ptr != null)
        {
            ptr.Next.Random = ptr.Random?.Next;
            ptr = ptr.Next.Next;
        }

        // Unweave the linked list to get back the original linked list and the
        // cloned list. i.e. A->A'->B->B'->C->C' would be broken to A->B->C and
        // A'->B'->C'
        Node2 ptrOldList = head; // A->B->C
        Node2 ptrNewList = head.Next; // A'->B'->C'
        Node2 result = head.Next;
        while (ptrOldList != null)
        {
            ptrOldList.Next = ptrOldList.Next.Next;
            ptrNewList.Next = ptrNewList.Next?.Next;
            ptrOldList = ptrOldList.Next;
            ptrNewList = ptrNewList.Next;
        }

        return result;
    }

    // 21. Merge Two Sorted Lists
    // Easy
    // You are given the heads of two sorted linked lists list1 and list2.
    // Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
    // Return the head of the merged linked list.
    // Example 1:
    // Input: list1 = [1,2,4], list2 = [1,3,4]
    // Output: [1,1,2,3,4,4]
    // Example 2:
    // Input: list1 = [], list2 = []
    // Output: []
    // Example 3:
    // Input: list1 = [], list2 = [0]
    // Output: [0]
    // Constraints:
    // The number of nodes in both lists is in the range [0, 50].
    // -100 <= Node.Val <= 100
    // Both list1 and list2 are sorted in non-decreasing order.
    public Node MergeTwoLists(Node list1, Node list2)
    {
        var head = new Node();
        var tail = head;
        while (list1 != null && list2 != null)
        {
            if (list1.Val < list2.Val)
            {
                tail.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                tail.Next = list2;
                list2 = list2.Next;
            }

            tail = tail.Next;
        }

        tail.Next = list1 ?? list2;

        return head.Next;
    }

    // 141. Linked List Cycle
    // Given head, the head of a linked list, determine if the linked list has a cycle in it.
    // There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
    // Return true if there is a cycle in the linked list. Otherwise, return false.
    // Example 1:
    // Input: head = [3,2,0,-4], pos = 1
    // Output: true
    // Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
    //     Example 2:
    // Input: head = [1,2], pos = 0
    // Output: true
    // Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
    //     Example 3:
    // Input: head = [1], pos = -1
    // Output: false
    // Explanation: There is no cycle in the linked list.
    //     Constraints:
    // The number of the nodes in the list is in the range [0, 104].
    // -105 <= Node.Val <= 105
    // pos is -1 or a valid index in the linked-list.
    //     Follow up: Can you solve it using O(1) (i.e. constant) memory?
    public bool HasCycle(Node head)
    {
        var slowPointer = head;
        var fastPointer = head;
        while (fastPointer != null && fastPointer.Next != null)
        {
            slowPointer = slowPointer.Next;
            fastPointer = fastPointer.Next.Next;
            if (slowPointer == fastPointer)
                return true;
        }

        return false;
    }

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
    // 1 <= Node.Val <= 100
    public Node MiddleNode(Node head)
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
    //     -100 <= Node.Val <= 100
    // The list is guaranteed to be sorted in ascending order.
    public Node DeleteDuplicates(Node head)
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
    //     -5000 <= Node.Val <= 5000
    public Node ReverseList(Node head)
    {
        Node prev = null;
        Node curr = head;
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
    //     0 <= Node.Val <= 100
    public Node SwapPairs(Node head)
    {
        // Check edge case: linked list has 0 or 1 nodes, just return
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node result = head.Next; // Step 5
        Node prev = null; // Initialize for step 3
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
    // -500 <= Node.Val <= 500
    // 1 <= left <= right <= n
    public Node ReverseBetween(Node head, int left, int right)
    {
        var temp = new Node(0, head);
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

    // 2. Add Two Numbers
    // You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    //     You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    //     Example 1:
    // Input: l1 = [2,4,3], l2 = [5,6,4]
    // Output: [7,0,8]
    // Explanation: 342 + 465 = 807.
    // Example 2:
    // Input: l1 = [0], l2 = [0]
    // Output: [0]
    // Example 3:
    // Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    // Output: [8,9,9,9,0,0,0,1]
    // Constraints:
    // The number of nodes in each linked list is in the range [1, 100].
    //     0 <= Node.Val <= 9
    // It is guaranteed that the list represents a number that does not have leading zeros.
    public Node AddTwoNumbers(Node l1, Node l2)
    {
        var dummyHead = new Node(0);
        var curr = dummyHead;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0)
        {
            int x = l1 != null ? l1.Val : 0;
            int y = l2 != null ? l2.Val : 0;
            int sum = carry + x + y;
            carry = sum / 10;
            curr.Next = new Node(sum % 10);
            curr = curr.Next;
            if (l1 != null)
                l1 = l1.Next;
            if (l2 != null)
                l2 = l2.Next;
        }

        return dummyHead.Next;
    }

    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        LinkedList<int[]> merged = new LinkedList<int[]>();
        foreach (int[] interval in intervals)
        {
            // if the list of merged intervals is empty or if the current
            // interval does not overlap with the previous, append it
            if (merged.Count == 0 || merged.Last.Value[1] < interval[0])
            {
                merged.AddLast(interval);
            }
            // otherwise, there is overlap, so we merge the current and previous
            // intervals
            else
            {
                merged.Last.Value[1] =
                    Math.Max(merged.Last.Value[1], interval[1]);
            }
        }

        return merged.ToArray();
    }
}