public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        int[] first = (int[])Array.CreateInstance(typeof(int), nums.Length); 
        Array.Copy(nums, first, nums.Length);
        List<IList<int>> result = new();
        
        NextPermutation(nums);
        int[] elem = (int[])Array.CreateInstance(typeof(int), nums.Length);
        Array.Copy(nums, elem, nums.Length);

        result.Add(elem);
        
        while(!Enumerable.SequenceEqual(first, nums))
        {
            NextPermutation(nums);
            elem = (int[])Array.CreateInstance(typeof(int), nums.Length);
            Array.Copy(nums, elem, nums.Length);
            result.Add(elem);
        }

        return result;
    }

    public void NextPermutation(int[] nums)
    {
        int n = nums.Length;
        int i;
        for (i = n - 2; i >= 0; i--)
        {
            if (nums[i] < nums[i + 1])
            {
                break;
            }
        }
        int repl;
        if (i < 0)
        {
            Reverse(nums, -1, n);

            return;
        }

        for (repl = n - 1; repl > i + 1; repl--)
        {
            if (nums[i] < nums[repl])
            {
                break;
            }
        }
        //swap
        Swap(nums, i, repl);
        // reverse
        Reverse(nums, i, n);

    }

    private static void Reverse(int[] nums, int smaller_index, int n)
    {
        int start = smaller_index + 1;
        int end = n - 1;
        while (start < end)
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }

    private static void Swap(int[] nums, int index1, int index2)
    {
        (nums[index2], nums[index1]) = (nums[index1], nums[index2]);
    }
}