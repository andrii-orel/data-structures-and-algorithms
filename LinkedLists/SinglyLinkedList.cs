namespace LinkedLists;

/*
Definition for singly-linked list.

Constructor:
[x] SinglyLinkedListNode() Initializes the private fields

Private Fields:
[x] Node head Is a reference to the FIRST node in the list
[x] int size The current size of the list

Public Properties:
[x] IsEmpty If the list is empty
[x] Count How many items are in the list
[x] Indexer Access data like an array.

Methods:
[x] AddByIndex(int index, object o) Add an item to list at specified index
[x] AddToNail(object o) Add an item to the END of the list
[x] RemoveByIndex(int index) Remove the item in the list at the specified index
[x] Clear() Clear the list
[x] IndexOf(object o) gets the index of the item in the list, if not in list return -1
[x] Contains(object o) if the list contains the object
[x] GetByIndex(int index) Gets item at the specified index
*/
public interface ISinglyLinkedList
{
    bool IsEmpty { get; }
    int Count { get; }
    object this[int index] { get; }
    int NotFoundIndex { get; }
    
    object AddByIndex(int index, object o);
    object AddToNail(object o);
    object RemoveByIndex(int index);
    void Clear();
    int IndexOf(object o);
    bool Contains(object o);
    object GetByIndex(int index);
}

public class SinglyLinkedList : ISinglyLinkedList
{
    private SinglyLinkedListNode _head;
    private int _count;

    public SinglyLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public bool IsEmpty => _count == 0;
    public int Count => _count;
    public object this[int index] => GetByIndex(index);
    public int NotFoundIndex => -1;
    
    // 0  1  2  3  4
    // a->b->e->c->d
    public object AddByIndex(int index, object o)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("Index: " + index);

        if (index > _count)
            index = _count;

        SinglyLinkedListNode current = _head;
        if (IsEmpty || index == 0)
        {
            _head = new SinglyLinkedListNode(o, _head);
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            current.Next = new SinglyLinkedListNode(o, current.Next);
        }

        _count++;

        return o;
    }

    public object AddToNail(object o)
    {
        return AddByIndex(_count, o);
    }

    public object RemoveByIndex(int index)
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException("Index: " + index);

        if (IsEmpty)
            return null;

        if (index >= _count)
            index = _count - 1;

        var current = _head;

        object result = null;

        if (index == 0)
        {
            result = current.Data;
            _head = current.Next;
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            result = current.Next.Data;
            //a->b->[c->]d
            current.Next = current.Next.Next;
        }

        _count--;

        return result;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }
    
    public int IndexOf(object o)
    {
        var current = _head;
        for (int i = 0; i < _count; i++)
        {
            if (current.Data.Equals(o))
                return i;
            
            current = current.Next;
        }

        return NotFoundIndex;
    }
    
    public bool Contains(object o)
    {
        return IndexOf(o) != NotFoundIndex;
    }

    public object GetByIndex(int index)
    {
        if (index > _count || index < 0)
            throw new ArgumentOutOfRangeException("Index: " + index);
        
        var current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        
        return current.Data;
    }
}