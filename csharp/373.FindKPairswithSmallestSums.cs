using System.Diagnostics.CodeAnalysis;

public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) 
    {
        PriorityQueue<(int sum, int pos), int> pq =  new ();
        List<IList<int>> result = new List<IList<int>>();

        var pos2 = 0;
        foreach (var num in nums1)
        {
            var sum = num + nums2[pos2];
            pq.Enqueue ((sum, pos2), sum);
        }

        while (k > 0 && pq.Count > 0)
        {
            k--;

            (int sum, int pos) = pq.Dequeue();
            result.Add(new int[] {sum - nums2[pos], nums2[pos]});

            if (pos + 1 < nums2.Length)
            {
                int newSum = sum - nums2[pos] + nums2[pos + 1];
                pq.Enqueue((newSum, pos + 1), newSum);
            }
        }

        return result;
    }
}