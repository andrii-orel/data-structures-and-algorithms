using LinkedLists;

namespace Tests;

public class LinkedListServiceTests
{
    private readonly ILinkedListService _linkedListService;

    public LinkedListServiceTests()
    {
        _linkedListService = new LinkedListService();
    }
    
    [Fact]
    public void MiddleNode_Example1_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(2, null);
        input.Next.Next = new Node(3, null);
        
        var expected = new Node(2, null);
        expected.Next = new Node(3, null);

        // Act
        var result = _linkedListService.MiddleNode(input);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
    
    [Fact]
    public void MiddleNode_Example2_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(2, null);
        input.Next.Next = new Node(3, null);
        input.Next.Next.Next = new Node(4, null);
        input.Next.Next.Next.Next = new Node(5, null);
        input.Next.Next.Next.Next.Next = new Node(6, null);
        
        var expected = new Node(4, null);
        expected.Next = new Node(5, null);
        expected.Next.Next = new Node(6, null);

        // Act
        var result = _linkedListService.MiddleNode(input);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
    
    [Fact]
    public void DeleteDuplicates_Example1_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(1, null);
        input.Next.Next = new Node(2, null);
        
        var expected = new Node(1, null);
        expected.Next = new Node(2, null);

        // Act
        var result = _linkedListService.DeleteDuplicates(input);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
    
    [Fact]
    public void ReverseList_Example1_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(2, null);
        input.Next.Next = new Node(3, null);
        input.Next.Next.Next = new Node(4, null);
        
        var expected = new Node(4, null);
        expected.Next = new Node(3, null);
        expected.Next.Next = new Node(2, null);
        expected.Next.Next.Next = new Node(1, null);

        // Act
        var result = _linkedListService.ReverseList(input);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
    
    [Fact]
    public void SwapPairs_Example1_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(2, null);
        input.Next.Next = new Node(3, null);
        input.Next.Next.Next = new Node(4, null);
        
        var expected = new Node(2, null);
        expected.Next = new Node(1, null);
        expected.Next.Next = new Node(4, null);
        expected.Next.Next.Next = new Node(3, null);

        // Act
        var result = _linkedListService.SwapPairs(input);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
    
    [Fact]
    public void ReverseBetween_Example1_Success()
    {
        // Arrange
        var input = new Node(1, null);
        input.Next = new Node(2, null);
        input.Next.Next = new Node(3, null);
        input.Next.Next.Next = new Node(4, null);
        input.Next.Next.Next.Next = new Node(5, null);
        
        var expected = new Node(1, null);
        expected.Next = new Node(4, null);
        expected.Next.Next = new Node(3, null);
        expected.Next.Next.Next = new Node(2, null);
        expected.Next.Next.Next.Next = new Node(5, null);

        // Act
        var result = _linkedListService.ReverseBetween(input, 2, 4);

        // Assert
        Assert.NotNull(result);
        while (result != null)
        {
            Assert.Equal(expected: expected.Val, actual: result.Val);
            result = result.Next;
            expected = expected.Next;
        }
    }
}