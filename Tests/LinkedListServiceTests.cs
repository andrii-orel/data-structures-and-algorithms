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
    public void ReverseStringDefault_Example1_Success()
    {
        // Arrange
        var input = new LeetcodeListNode(1, null);
        input.Next = new LeetcodeListNode(2, null);
        input.Next.Next = new LeetcodeListNode(3, null);
        
        var expected = new LeetcodeListNode(2, null);
        expected.Next = new LeetcodeListNode(3, null);

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
    public void ReverseStringDefault_Example2_Success()
    {
        // Arrange
        var input = new LeetcodeListNode(1, null);
        input.Next = new LeetcodeListNode(2, null);
        input.Next.Next = new LeetcodeListNode(3, null);
        input.Next.Next.Next = new LeetcodeListNode(4, null);
        input.Next.Next.Next.Next = new LeetcodeListNode(5, null);
        input.Next.Next.Next.Next.Next = new LeetcodeListNode(6, null);
        
        var expected = new LeetcodeListNode(4, null);
        expected.Next = new LeetcodeListNode(5, null);
        expected.Next.Next = new LeetcodeListNode(6, null);

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
}