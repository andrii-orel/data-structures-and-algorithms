namespace LinkedLists;

public class LeetcodeListNode
{
    public readonly int Val;
    public LeetcodeListNode Next;

    public LeetcodeListNode(int val = 0, LeetcodeListNode next = null)
    {
        Val = val;
        Next = next;
    }
}