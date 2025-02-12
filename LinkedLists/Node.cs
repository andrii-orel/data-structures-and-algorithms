namespace LinkedLists;

// Leetcode liked list node
public class Node
{
    public readonly int Val;
    public Node Next;

    public Node(int val = 0, Node next = null)
    {
        Val = val;
        Next = next;
    }
}