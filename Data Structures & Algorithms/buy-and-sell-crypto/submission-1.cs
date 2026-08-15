public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;

        for (var left = 0; left < prices.Length; left++) {
            var maxPrice = 0;

            for (var right = left + 1; right < prices.Length; right++) {
                if (prices[right] > maxPrice) {
                    maxPrice = prices[right];
                }
            }

            var profit = maxPrice - prices[left];
            maxProfit = Math.Max(maxProfit, profit);
        }

        return maxProfit;
    }
}
