public class Solution {
    public int[] TopKFrequent(int[] nums, int k) 
    {
        List<int> result = new();

        if (nums == null || nums.Length < k)
        {
            return result.ToArray();
        }

        Dictionary<int, int> freq = new();
        PriorityQueue<int, int> pq = new();

        for(int i = 0; i < nums.Length; i++)
        {
            if (!freq.ContainsKey(nums[i]))
            {
                freq.Add(nums[i], 1);
            }
            else
            {
                freq[nums[i]]++;
            }
        }
        
        pq.EnqueueRange(freq.Keys.Select(k => (k, freq[k])));
        int count = freq.Keys.Count;
        for(int j = 0; j < count; j++)
        {
            var el = pq.Dequeue();

            if (count - k <= j)
                result.Add(el);
        }

        return result.ToArray();    
    }
}