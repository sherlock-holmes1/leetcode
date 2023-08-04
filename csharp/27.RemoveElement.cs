
using System.Reflection;

public class Solution 
{
    public int RemoveElement(int[] nums, int val) {
        if (nums == null)
            return 0;

        int pointer = 0;
        int i = 0;

        while (i < nums.Length) 
        {
            if (nums[i] != val)
            {
                nums[pointer] = nums[i];
                pointer+=1;
                i+=1;
            }
            else
            {
                i+=1;
                if (i == nums.Length)
                    return pointer;
                nums[pointer] = nums[i];
            }
        }

        return pointer;
    }
}