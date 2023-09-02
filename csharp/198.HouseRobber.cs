public class Solution {
    public int Rob(int[] nums) 
    {
        if (nums == null)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        int[] dp = new int[nums.Length];
        
        dp[0] = nums[0];
        dp[1] = Math.Max(dp[0], nums[1]);
        
        for (int i = 2; i <= nums.Length - 1; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        } 

        return dp[^1];
    }
}


// 1_,2,3_,1
// 2_,7,9_,3,1_
// 2,7_,3,9_,1
// 2,7,11,9,1
// 2_,1,3,9_,4
// ^  ^ ^ -- first step is to find max from the first+third and two
// results array maxRob, robbedHouses
// max1 (first el), -> robbedHouses.add(first) 
// max2 (max (first+third, first+fourth and two)) -> robbedHouses.add(max)
// max3 (max (robbedHouses.last + nums[+2], robbedHouses.last + nums[+3], nums[+1])