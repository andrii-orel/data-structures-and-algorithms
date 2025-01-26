using LinkedLists;

namespace Tests;

public class SinglyLinkedListTests
{
    private readonly ISinglyLinkedList _singlyLinkedList = new SinglyLinkedList();

    [Fact]
    public void LinkedList_Add_Success()
    {
        // Arrange
        var expected = 3;

        // Act
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddByIndex(1, "Test3");

        // Assert
        Assert.Equal(expected: expected, actual: _singlyLinkedList.Count);
    }

    [Fact]
    public void LinkedList_Remove_Success()
    {
        // Arrange
        var expected = 2;
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");

        // Act
        _singlyLinkedList.RemoveByIndex(1);

        // Assert
        Assert.Equal(expected: expected, actual: _singlyLinkedList.Count);
    }

    [Fact]
    public void LinkedList_Clear_Success()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");

        // Act
        _singlyLinkedList.Clear();

        // Assert
        Assert.True(_singlyLinkedList.IsEmpty);
    }

    [Fact]
    public void LinkedList_IndexOf_Success()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");
        var expected = 1;

        // Act
        var result = _singlyLinkedList.IndexOf("Test2");

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void LinkedList_IndexOf_NotFound()
    {
        // Arrange
        var expected = _singlyLinkedList.NotFoundIndex;
        
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");
        
        // Act
        var result = _singlyLinkedList.IndexOf("Test4");

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void LinkedList_Contains_Success()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");

        // Act
        var result = _singlyLinkedList.Contains("Test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void LinkedList_Contains_NotFound()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");

        // Act
        var result = _singlyLinkedList.Contains("Test4");

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void LinkedList_GetByIndex_NotFound()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");
        _singlyLinkedList.AddToNail("Test4");

        // Act
        var result = _singlyLinkedList.GetByIndex(2);

        // Assert
        Assert.Equal(expected: "Test3", actual: result);
    }
    
    [Fact]
    public void LinkedList_Index_NotFound()
    {
        // Arrange
        _singlyLinkedList.AddToNail("Test1");
        _singlyLinkedList.AddToNail("Test2");
        _singlyLinkedList.AddToNail("Test3");
        _singlyLinkedList.AddToNail("Test4");

        // Act
        var result = _singlyLinkedList[2];

        // Assert
        Assert.Equal(expected: "Test3", actual: result);
    }
}