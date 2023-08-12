public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> result = new ();
        // Queue<int> sliding_window = new();
        List<int> sliding_max_indices = new();
        int max = nums[0];

        for (int i = 0; i < k; i++)
        {
            updateSlidingMaxIndices(nums, sliding_max_indices, i);

            sliding_max_indices.Add(i);
            max = nums[sliding_max_indices[0]];
        }

        result.Add(max);

        for (int i = k; i < nums.Length; i++)
        {
            if (sliding_max_indices[0] < i - k + 1)
            {
                sliding_max_indices.RemoveAt(0);
            }

            updateSlidingMaxIndices(nums, sliding_max_indices, i);
            sliding_max_indices.Add(i); 
            max = nums[sliding_max_indices[0]];           
            result.Add(max);
        }

        return result.ToArray();
    }

    private static void updateSlidingMaxIndices(int[] nums, List<int> sliding_max_indices, int i)
    {
        int lst = sliding_max_indices.Count - 1;

        while (sliding_max_indices.Count > 0 && nums[sliding_max_indices[lst]] < nums[i])
        {
            sliding_max_indices.RemoveAt(lst);
            lst = sliding_max_indices.Count - 1;
        }
    }
}