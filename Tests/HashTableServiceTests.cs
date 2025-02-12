using HashTables;

namespace Tests;

public class HashTableServiceTests
{
    private readonly IHashTableService _hashTableService;

    public HashTableServiceTests()
    {
        _hashTableService = new HashTableService();
    }

    [Fact]
    public void IsIsomorphic_Example1_Success()
    {
        // Arrange
        var s = "egg";
        var t = "add";

        // Act
        var result = _hashTableService.IsIsomorphic(s, t);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void MajorityElement_Example1_Success()
    {
        // Arrange
        int[] nums = [3, 2, 3];
        int expected = 3;

        // Act
        var result = _hashTableService.MajorityElement(nums);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void CanConstruct_Example1_Success()
    {
        // Arrange
        string ransomNote = "a";
        string magazine = "b";

        // Act
        var result = _hashTableService.CanConstruct(ransomNote, magazine);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanConstruct_Example2_Success()
    {
        // Arrange
        string ransomNote = "aa";
        string magazine = "ab";

        // Act
        var result = _hashTableService.CanConstruct(ransomNote, magazine);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanConstruct_Example3_Success()
    {
        // Arrange
        string ransomNote = "aa";
        string magazine = "aab";

        // Act
        var result = _hashTableService.CanConstruct(ransomNote, magazine);

        // Assert
        Assert.True(result);
    }
}