public class Solution {
    private int[] nums = new int[] {};
    private int target;
    public int[] SearchRange(int[] nums, int target)
    {
        this.nums = nums;
        this.target = target;
        int left_index = 0;
        int right_index = nums.Length - 1;
        int target_index = this.FindTargetIndex(left_index, right_index);

        if (target_index == -1)
        {
            return new int[] { -1, -1 };
        }
        // move left to identify left border
        int left_border = FindTargetAdjactentLeftIndex(0, target_index);

        if (left_border == -1)
        {
            left_border = target_index;
        }

        // move right to identify the right border

        int right_border = FindTargetAdjactentRightIndex(target_index, nums.Length - 1);

        if (right_border == -1)
        {
            right_border = target_index;
        }

        return new int[] {left_border, right_border};
    }

    private int FindTargetIndex(int left_index, int right_index)
    {
        if (left_index == right_index)
        {
            return (this.target == nums[left_index]) ? left_index : -1;
        }
    
        while (right_index - left_index >= 0)
        {
            if (right_index == left_index + 1)
            {
                if (this.target == nums[left_index])
                    return left_index;

                if (this.target == nums[right_index])
                    return right_index;

                return -1;
            }

            int mid_index = (right_index + left_index) / 2;

            if (target < nums[mid_index])
            {
                right_index = mid_index;
            }
            else if (target > nums[mid_index])
            {
                left_index = mid_index;
            }
            else if (target == nums[mid_index])
            {
                return mid_index;
            }
        }

        return -1;
    }
    private int FindTargetAdjactentLeftIndex(int left_index, int right_index)
    {
        if (left_index == right_index)
        {
            return (this.target == nums[left_index]) ? left_index : -1;
        }

        while (right_index - left_index >= 0)
        {
            if (right_index == left_index + 1)
            {                
                if (this.target == nums[left_index]) 
                    return left_index;

                if (this.target == nums[right_index]) 
                    return right_index;
            }

            int mid_index = (right_index + left_index) / 2;

            if (nums[mid_index] == target && nums[mid_index - 1] < target)
            {
                return mid_index;
            }

            if (nums[mid_index] == target && nums[mid_index - 1] == target)
            {
                right_index = mid_index;
            }

            if (nums[mid_index] < target)
            {
                left_index = mid_index;
            }

            if (right_index == left_index + 1)
            {
                return (this.target == nums[left_index]) ? left_index : -1;
            }
        }

        return -1;
    }
    private int FindTargetAdjactentRightIndex(int left_index, int right_index)
    {
        if (left_index == right_index)
        {
            return (this.target == nums[left_index]) ? left_index : -1;
        }

        while (right_index - left_index >= 0)
        {
            if (right_index == left_index + 1)
            {
                if (this.target == nums[right_index]) 
                    return right_index;
                
                if (this.target == nums[left_index]) 
                    return left_index;
            }

            int mid_index = (right_index + left_index) / 2;

            if (nums[mid_index] == target && nums[mid_index + 1] > target)
            {
                return mid_index;
            }

            if (nums[mid_index] == target && nums[mid_index - 1] == target)
            {
                left_index = mid_index;
            }

            if (nums[mid_index] > target)
            {
                right_index = mid_index;
            }
        }

        return -1;
    }
}