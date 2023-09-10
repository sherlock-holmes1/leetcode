public class Solution {
    public long WaysToBuyPensPencils(int total, int cost1, int cost2) 
    {
        long result = 0;
        int maxNumPens = total / cost1;
        int maxNumPensils = total / cost2;
        int maxPrice = Math.Max(cost1, cost2);
        int maxBigger;
        int costOfLower;
        int lowerInBigger;

        if (maxPrice == cost1)
        {
            maxBigger = maxNumPens;
            lowerInBigger = cost1 / cost2;
            costOfLower = cost2;
        }
        else
        {
            maxBigger = maxNumPensils;
            lowerInBigger = cost2 / cost1; 
            costOfLower = cost1;           
        }

        // lower = total / costOfLower - lowerInBigger * bigger
        int numLower;
        int numBigger = 0;

        while(numBigger <= maxBigger)
        {
            numLower = total / costOfLower - lowerInBigger * numBigger;
            
            while (numLower * costOfLower + numBigger * maxPrice > total)
            {
                numLower--;
            }
            
            result += numLower + 1;
            numBigger++;
        }

        return result;    
    }
}

// Input: total = 20, cost1 = 10, cost2 = 5
// Output: 9
// maxNumPens = 2
// maxNumPensils = 4
// pensilsInPen = 2
// options = 
// (0): (maxNumPensils + 1)  = 5
// (1): (maxNumPensils - pensilsInPen + 1) = 4 - 2 + 1 = 3
// (2): (maxNumPensils - pensilsInPen*2 + 1) = 1


// cost1 * NumPens + cost2 * NumPensils < total
// pensilsInPen = cost1 / cost2 => cost1 = lowerInBigger * cost2
// pensilsInPen * cost2 * NumPens + cost2 * NumPensils < total
// cost2 (pensilsInPen * NumPens + NumPensils) <= total
// pensilsInPen * NumPens + NumPensils <= total / cost2
// maxNumPens = 2
// maxNumPensils = 4
// pensilsInPen = 2
// Input: total = 20, cost1 = 10, cost2 = 5
// Output: 9
// 2 * NumPens + NumPensils <= 20 / 5 = 4
// 2 * NumPens + NumPensils <= 4
// (0;[0..4]); => 5
// (1;[0..2]); => 3
// (2;0) => 1

// Input: total = 10, cost1 = 2 (pens / costOfLower), cost2 = 5 (pensils)
// Output: 10
// maxNumPens = 5 (lower)
// maxNumPensils = 2 (bigger)
// lowerInBigger = 2
// options = 
// (0): (maxNumPens + 1) = 6
// (1): (maxNumPens - lowerInBigger*1 + 1) = 5 - 2 + 1 = 4
// (2): (maxNumPens - lowerInBigger*2 + 1) = 5 - 2 * 2 + 1
// lowerInBigger * bigger + lower <= total / costOfLower
// 2.5 * bigger + lower <= 10 / 2 = 5
// lower <= (floor?)5 - 2.5 * bigger
// (0;[0..5]) => 6
// (1;[0..2]) => 3
// (2;0) => 1


