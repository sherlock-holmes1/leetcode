public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int k = nums.Length;
        int oldNum = int.MinValue;
        int cnt = 0;
        int i = 0;

        while (i < k)
        {
            if (nums[i] != oldNum)
            {
                oldNum = nums[i];
                cnt = 0;
            }

            if (nums[i] == oldNum)
            {
                cnt++;

                if (cnt > 2)
                {
                    // looking for a last position with the same number
                    int pos = i;
                    int increase = 1;
                    
                    while (pos < k && nums[pos] == oldNum)
                    {
                        pos += increase;
                        increase *= 2;
                    }

                    int left = pos - increase;
                    int right = pos;
                    int med = (left + right) / 2;
                    while (left < right && med + 1 < k)
                    {
                        if (nums[med] == oldNum && nums[med + 1] == oldNum)
                        {// last pos of the number is to the right
                            left = med;
                            med = (left + right) / 2;
                        }
                        else if (nums[med] != oldNum && nums[med + 1] != oldNum)
                        {
                            right = med;
                            med = (left + right) / 2;
                        }
                        else
                        {
                            // med is last post with the number
                            break;
                        }
                    }

                    Array.Copy(nums, med + 1, nums, i, nums.Length - med - 1);
                    k = k - (med - i + 1);
                    i--;
                }
            }
            i++;
        }
        return k;
    }
}