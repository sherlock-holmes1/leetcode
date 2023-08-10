public class Solution {
    public int Search(int[] nums, int target) {
        int res = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                res = i;
                break;
            }
            if (nums[i] > target)
            {
                break;
            }
        } 

        return res;
    }
}