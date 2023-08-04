public class Solution
{
    public static int RemoveDuplicates(int[] nums) {
        int same = nums[0];
        int i = 0;
        int p_no_dupes = 0;

        while (i < nums.Length)
        {
            if (same != nums[i])
            {
                same = nums[i];
                p_no_dupes++;
                nums[p_no_dupes] = nums[i];
            }

            i++;
        }

        return p_no_dupes + 1;
    }
}