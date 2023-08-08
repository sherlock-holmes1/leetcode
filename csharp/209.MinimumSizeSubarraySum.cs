public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        Array.Sort(nums);

        int right = nums.Length - 1;
        int left = right - 1;
        int sum = nums[right];
        int res = 0;
        int numCounter = 1;

        if (nums[right] >= target)
        {
            res = numCounter;
        }
        
        while (right >= 0)
        {
            while (left >= 0)
            {
                sum += nums[left];
                numCounter++;

                if (sum < target)
                {
                    left--;
                }
                else if (sum >= target)
                {
                    if (res == 0 || res > numCounter)
                    {
                        res = numCounter;
                    }

                    numCounter--;
                    sum -= nums[left];
                    left--;
                }
            }

            right--;
            
            if (right < 0)
            {
                break;
            }

            left = right - 1;
            sum = nums[right];
            numCounter = 1;
        }

        return res;    
    }
}