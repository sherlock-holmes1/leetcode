public class Solution {
    public int MaxProfit(int[] prices) {
        int left = 0;
        int profit = 0;
        int buy = prices[left];
        int sell;

        for (left = 1; left <= prices.Length - 1; left++)
        {
            sell = prices[left];
            
            if (sell > buy)
            {
                profit += sell - buy;
                buy = sell;
            } 
            else // buy < sell
            {
                buy = sell;
            }
        }

        return profit;    
    }
}