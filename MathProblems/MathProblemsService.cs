namespace MathProblems;

public interface IMathProblemsService
{
    double MyPow(double x, int n);
    int TrailingZeroes(int n);
    int Factorial(int n);
}

public class MathProblemsService : IMathProblemsService
{
    public int Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        
        var factorial = n * Factorial(n - 1);
        return factorial;
    }
    // 172. Factorial Trailing Zeroes
    // Given an integer n, return the number of trailing zeroes in n!.
    // Note that n! = n * (n - 1) * (n - 2) * ... * 3 * 2 * 1.
    // Example 1:
    // Input: n = 3
    // Output: 0
    // Explanation: 3! = 6, no trailing zero.
    // Example 2:
    // Input: n = 5
    // Output: 1
    // Explanation: 5! = 120, one trailing zero.
    // Example 3:
    // Input: n = 0
    // Output: 0
    // Constraints:
    // 0 <= n <= 104
    public int TrailingZeroes(int n)
    {
        var str = Factorial(n).ToString();
        var strLength = str.Length;
        str = str.Replace("0", string.Empty);
        
        return strLength - str.Length;
        // var count = 0;
        // for (var i = 5; i <= n; i *= 5)
        //     count += n / i;
        //
        // return count;

        // int zeroCount = 0;
        // while (n > 0) {
        //     n /= 5;
        //     zeroCount += n;
        // }
        //
        // return zeroCount;
    }
    
    public int[] PlusOne(int[] digits)
    {
        int n = digits.Length;
        // Move along the input array starting from the end
        for (int idx = n - 1; idx >= 0; --idx)
        {
            // Set all the nines at the end of the array to zeros
            if (digits[idx] == 9)
            {
                digits[idx] = 0;
            }
            // Here we have the rightmost not-nine
            else
            {
                // Increase this rightmost not-nine by 1
                digits[idx]++;
                // and the job is done
                return digits;
            }
        }

        // We're here because all the digits are nines
        int[] newDigits = new int[n + 1];
        newDigits[0] = 1;
        
        return newDigits;
    }

    // 69. Sqrt(x)
    //     Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.
    //     You must not use any built-in exponent function or operator.
    // For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
    //     Example 1:
    // Input: x = 4
    // Output: 2
    // Explanation: The square root of 4 is 2, so we return 2.
    //     Example 2:
    // Input: x = 8
    // Output: 2
    // Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
    //     Constraints:
    // 0 <= x <= 231 - 1
    public int MySqrt(int x)
    {
        // return (int)Math.Sqrt(x);
        var left = 1;
        var right = x;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if ((long)mid * mid == x)
            {
                return mid;
            }

            if ((long)mid * mid < x)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return right;
    }

    private double BinaryExp(double x, long n)
    {
        if (n == 0)
            return 1;

        if (x == 1)
            return x;

        if (x == -1)
        {
            var k = n % 2 == 0 ? -1 : 1;
            return x * k;
        }

        // Handle case where, n < 0.
        if (n < 0)
        {
            n = -1 * n;
            x = 1.0 / x;
        }

        // Perform Binary Exponentiation.
        double result = 1;
        while (n != 0)
        {
            // If 'n' is odd we multiply result with 'x' and reduce 'n' by '1'.
            if (n % 2 == 1)
            {
                result *= x;
                n -= 1;
            }

            // We square 'x' and reduce 'n' by half, x^n => (x^2)^(n/2).
            x *= x;
            n /= 2;
        }

        return result;
    }

    public double MyPow(double x, int n)
    {
        return BinaryExp(x, (long)n);
        // Cannot pass Leetcode
        // if (n == 0)
        //     return 1;
        // if (x == 1 || x == -1)
        //     return x;
        // double result = x;
        // int stepAbs = n;
        // if (n < 0)
        //     stepAbs *= -1;
        // for (var i = 1; i < stepAbs; i++)
        // {
        //     result *= x;
        // }
        //
        // return n < 0 ? 1 / result : result;
    }
}