public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        for (int i = 0; i < nums.Length; i++)
        {
            int j = i + 1;
            while(j < nums.Length && Math.Abs(i - j) <= k)
            {
                if (nums[j] == nums[i])
                {
                    return true;
                }

                j++;
            }
        }
        
        return false;
    }
}