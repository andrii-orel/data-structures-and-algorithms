namespace LinkedLists;
/* Constructor:
[x] Node(object data, Node Next)

Private Fields:
[x] object data contain the data of the node, what we want to store in the list
[x] Node Next reference to the Next node in the list

Public Properties:

[x] Data get/set the data field
[x] Next get/set the Next field
*/
public class SinglyLinkedListNode
{
    private object _data;
    private SinglyLinkedListNode _next;

    public SinglyLinkedListNode(object data, SinglyLinkedListNode next)
    {
        _data = data;
        _next = next;
    }

    public object Data
    {
        get => _data;
        set => _data = value;
    }

    public SinglyLinkedListNode Next
    {
        get => _next;
        set => _next = value;
    }
}