public class Solution 
{
    public void SortColors(int[] nums) 
    {
        int left = 0;
        int right = nums.Length - 1;

        for (int i = 0; i < nums.Length; i++)
        {
            while ((nums[i] == 0 && i > left) || (nums[i] == 2 && i < right)) 
            {
                if (nums[i] == 0)
                {
                    (nums[i], nums[left]) = (nums[left], 0);
                    left++;
                }
                else
                {
                    (nums[i], nums[right]) = (nums[right], 2);
                    right--;
                }
            }
        }
    }
}