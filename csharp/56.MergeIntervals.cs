public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> result = new ();
        
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
        result.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++)
        {
            int last = result.Count - 1;

            if (result[last][1] >= intervals[i][0])
            {
                if (result[last][1] < intervals[i][1])
                    result[last][1] = intervals[i][1];
            }
            else
            {
                result.Add(intervals[i]);
            }
        }

        return result.ToArray();
    }
}