namespace ArraysAndStrings;

public interface IGreedyService
{
    int MaxIceCream(int[] costs, int coins);
}
// 1833. Maximum Ice Cream Bars
// Medium
// It is a sweltering summer day, and a boy wants to buy some ice cream bars.
// At the store, there are n ice cream bars. You are given an array costs of length n, where costs[i] is the price of the ith ice cream bar in coins. The boy initially has coins coins to spend, and he wants to buy as many ice cream bars as possible. 
//     Note: The boy can buy the ice cream bars in any order.
//     Return the maximum number of ice cream bars the boy can buy with coins coins.
//     You must solve the problem by counting sort.
//     Example 1:
// Input: costs = [1,3,2,4,1], coins = 7
// Output: 4
// Explanation: The boy can buy ice cream bars at indices 0,1,2,4 for a total price of 1 + 3 + 2 + 1 = 7.
//     Example 2:
// Input: costs = [10,6,8,7,7,8], coins = 5
// Output: 0
// Explanation: The boy cannot afford any of the ice cream bars.
//     Example 3:
// Input: costs = [1,6,3,1,2,5], coins = 20
// Output: 6
// Explanation: The boy can buy all the ice cream bars for a total price of 1 + 6 + 3 + 1 + 2 + 5 = 18.
//     Constraints:
// costs.length == n
// 1 <= n <= 105
// 1 <= costs[i] <= 105
// 1 <= coins <= 108
public class GreedyService : IGreedyService
{
    public int MaxIceCreamV1(int[] costs, int coins)
    {
        var result = 0;
        var minCost = costs.Min();
        if (coins < minCost)
        {
            return result;
        }
        var map = new SortedDictionary<int, int>();
        for (int i = 0; i < costs.Length; i++)
        {
            if (map.ContainsKey(costs[i]))
            {
                map[costs[i]] += 1;
            }
            else
            {
                map[costs[i]] = 1;
            }
        }

        foreach (var item in map)
        {
            if (coins == 0)
                break;
            if (item.Value == 0)
                continue;

            var canBuy = Math.Min(
                item.Value,
                coins / item.Key);

            result += canBuy;
            coins -= canBuy * item.Key;
        }
        
        return result;
    }
    
    public int MaxIceCreamV2(int[] costs, int coins) {
        if (coins == 0) return 0;
        int maxCost = 0;
        foreach (int cost in costs) {
            if (cost > maxCost) maxCost = cost;
        }
        int[] count = new int[maxCost + 1];
        foreach (int cost in costs) {
            count[cost]++;
        }
        int total = 0;
        for (int i = 1; i <= maxCost; i++) {
            if (coins >= i) {
                int take = Math.Min(count[i], coins / i);
                total += take;
                coins -= take * i;
            } else {
                break;
            }
        }
        return total;
    }
    
    public int MaxIceCream(int[] costs, int coins)
    {
        int result = 0;
        int maxCost = costs.Max();
        int[] freq = new int[maxCost + 1];

        foreach (int cost in costs)
        {
            freq[cost]++;
        }

        for (int price = 1; price <= maxCost; price++)
        {
            if (freq[price] == 0)
                continue;

            int canBuy = Math.Min(
                freq[price],
                coins / price);

            result += canBuy;
            coins -= canBuy * price;
        }

        return result;
    }
}