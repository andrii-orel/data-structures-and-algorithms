﻿using ArraysAndStrings;

namespace Tests;

public class ArraysAndStringsServiceTests
{
    private readonly IArraysAndStringsService _arraysAndStringsService;

    public ArraysAndStringsServiceTests()
    {
        _arraysAndStringsService = new ArraysAndStringsService();
    }
[Fact]
    public void GetAverages_Example1_Success()
    {
        // Arrange
        var input = new[] { 7,4,3,9,1,8,5,2,6 };
        var k = 3;
        var expected = new[] { -1,-1,-1,5,4,4,-1,-1,-1 };

        // Act
        var result = _arraysAndStringsService.GetAverages(input, k);

        // Assert
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Fact]
    public void MinStartValue_Example1_Success()
    {
        // Arrange
        var input = new[] { -3, 2, -3, 4, 2 };
        var expected = 5;

        // Act
        var result = _arraysAndStringsService.MinStartValue(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GameOfLife_Example1_Success()
    {
        // Arrange
        var input = new int[][]
        {
            new int[] { 0, 1, 0 },
            new int[] { 0, 0, 1 },
            new int[] { 1, 1, 1 },
            new int[] { 0, 0, 0 }
        };
        var expected = new int[][]
        {
            new int[] { 0, 0, 0 },
            new int[] { 1, 0, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 0, 1, 0 }
        };

        // Act
        var result = _arraysAndStringsService.GameOfLife(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                // Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    [Fact]
    public void MaxArea_Example1_Success()
    {
        // Arrange
        var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        ;
        var expected = 49;

        // Act
        var result = _arraysAndStringsService.MaxArea(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Pangrams_Example1_Success()
    {
        // Arrange
        var input = "We promptly judged antique ivory buckles for the next prize";
        var expected = "pangram";

        // Act
        var result = _arraysAndStringsService.Pangrams(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void RunningSum_Example1_Success()
    {
        //Input: nums = [1,2,3,4]
        //Output: [1,3,6,10]
        // Arrange
        var input = new int[] { 1, 2, 3, 4 };
        var expected = new int[] { 1, 3, 6, 10 };

        // Act
        var result = _arraysAndStringsService.RunningSum(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void SortedSquares2_Example1_Success()
    {
        //Input: nums = [1,2,3,4]
        //Output: [1,3,6,10]
        // Arrange
        var input = new int[] { -7, -3, 2, 3, 11 };
        var expected = new int[] { 4, 9, 9, 49, 121 };

        // Act
        var result = _arraysAndStringsService.SortedSquares2(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void LongestCommonPrefix_Example1_Success()
    {
        // Arrange
        string[] input = ["flower", "flow", "flight"];
        string expected = "fl";

        // Act
        var result = _arraysAndStringsService.LongestCommonPrefix(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void LongestCommonPrefix_Example2_Success()
    {
        // Arrange
        string[] input = ["dog", "racecar", "car"];
        string expected = "";

        // Act
        var result = _arraysAndStringsService.LongestCommonPrefix(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void ReverseString_Example1_Success()
    {
        // Arrange
        char[] input = ['h', 'e', 'l', 'l', 'o'];
        char[] expected = ['o', 'l', 'l', 'e', 'h'];

        // Act
        _arraysAndStringsService.ReverseString(input);

        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: input[i]);
        }
    }

    [Fact]
    public void ReverseString_Example2_Success()
    {
        // Arrange
        char[] input = ['H', 'a', 'n', 'n', 'a', 'h'];
        char[] expected = ['h', 'a', 'n', 'n', 'a', 'H'];

        // Act
        _arraysAndStringsService.ReverseString(input);

        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: input[i]);
        }
    }

    [Fact]
    public void ReverseStringDefault_Example1_Success()
    {
        // Arrange
        char[] input = ['h', 'e', 'l', 'l', 'o'];
        char[] expected = ['o', 'l', 'l', 'e', 'h'];

        // Act
        var result = _arraysAndStringsService.ReverseStringDefault(input);

        // Assert
        Assert.NotNull(result);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void ReverseStringDefault_Example2_Success()
    {
        // Arrange
        char[] input = ['H', 'a', 'n', 'n', 'a', 'h'];
        char[] expected = ['h', 'a', 'n', 'n', 'a', 'H'];

        // Act
        var result = _arraysAndStringsService.ReverseStringDefault(input);

        // Assert
        Assert.NotNull(result);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void SortedSquares_Example1_Success()
    {
        // Arrange
        int[] input = [-4, -1, 0, 3, 10];
        int[] expected = [0, 1, 9, 16, 100];

        // Act
        var result = _arraysAndStringsService.SortedSquares(input);

        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void SortedSquares_Example2_Success()
    {
        // Arrange
        int[] input = [-7, -3, 2, 3, 11];
        int[] expected = [4, 9, 9, 49, 121];

        // Act
        var result = _arraysAndStringsService.SortedSquares(input);

        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void Merge_Example1_Success()
    {
        // Arrange int[] nums1, int m, int[] nums2, int n
        int[] nums1 = [0];
        int m = 0;
        int[] nums2 = [1];
        int n = 1;
        int[] expected = [1];

        // Act
        _arraysAndStringsService.Merge(nums1, m, nums2, n);

        // Assert
        Assert.NotNull(nums1);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: nums1[i]);
        }
    }

    [Fact]
    public void Merge_Example2_Success()
    {
        // Arrange int[] nums1, int m, int[] nums2, int n
        int[] nums1 = [1];
        int m = 1;
        int[] nums2 = [];
        int n = 0;
        int[] expected = [1];

        // Act
        _arraysAndStringsService.Merge(nums1, m, nums2, n);

        // Assert
        Assert.NotNull(nums1);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: nums1[i]);
        }
    }

    [Fact]
    public void Merge_Example3_Success()
    {
        // Arrange int[] nums1, int m, int[] nums2, int n
        int[] nums1 = [2, 0];
        int m = 1;
        int[] nums2 = [1];
        int n = 1;
        int[] expected = [1, 2];

        // Act
        _arraysAndStringsService.Merge(nums1, m, nums2, n);

        // Assert
        Assert.NotNull(nums1);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: nums1[i]);
        }
    }

    [Fact]
    public void RemoveElement_Example1_Success()
    {
        // Arrange
        int[] nums = [3, 2, 2, 3];
        int val = 3;

        int expected = 2;
        int[] expectedNums = [2, 2];

        // Act
        var result = _arraysAndStringsService.RemoveElement(nums, val);

        // Assert
        Assert.Equal(expected: expected, actual: result);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void RemoveElement_Example2_Success()
    {
        // Arrange
        int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
        int val = 2;

        int expected = 5;
        int[] expectedNums = [0, 1, 3, 0, 4];

        // Act
        var result = _arraysAndStringsService.RemoveElement(nums, val);

        // Assert
        Assert.Equal(expected: expected, actual: result);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void RemoveDuplicates_Example1_Success()
    {
        // Arrange
        int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];

        int expected = 5;
        int[] expectedNums = [0, 1, 2, 3, 4];

        // Act
        var result = _arraysAndStringsService.RemoveDuplicates(nums);

        // Assert
        Assert.Equal(expected: expected, actual: result);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void RemoveDuplicates2_Example1_Success()
    {
        // Arrange
        int[] nums = [1, 1, 1, 1, 2, 2, 3];

        int expected = 5;
        int[] expectedNums = [1, 1, 2, 2, 3];

        // Act
        var result = _arraysAndStringsService.RemoveDuplicates2(nums);

        // Assert
        Assert.Equal(expected: expected, actual: result);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void RemoveDuplicates2_Example2_Success()
    {
        // Arrange
        int[] nums = [0, 0, 1, 1, 1, 1, 2, 3, 3];

        int expected = 7;
        int[] expectedNums = [0, 0, 1, 1, 2, 3, 3];

        // Act
        var result = _arraysAndStringsService.RemoveDuplicates2(nums);

        // Assert
        Assert.Equal(expected: expected, actual: result);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void Rotate_Example1_Success()
    {
        // Arrange
        int[] nums = [1, 2, 3, 4, 5, 6, 7];
        int k = 3;

        int[] expectedNums = [5, 6, 7, 1, 2, 3, 4];

        // Act
        _arraysAndStringsService.Rotate(nums, k);

        // Assert
        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void Rotate_Example2_Success()
    {
        // Arrange
        int[] nums = [-1, -100, 3, 99];
        int k = 2;

        int[] expectedNums = [3, 99, -1, -100];

        // Act
        _arraysAndStringsService.Rotate(nums, k);

        // Assert
        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }

    [Fact]
    public void Rotate_Example3_Success()
    {
        // Arrange
        int[] nums = [1, 2];
        int k = 3;

        int[] expectedNums = [2, 1];

        // Act
        _arraysAndStringsService.Rotate(nums, k);

        // Assert
        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(expected: expectedNums[i], actual: nums[i]);
        }
    }
}