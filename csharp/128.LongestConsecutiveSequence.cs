public class Solution {
    public int LongestConsecutive(int[] nums) {
        int result = 0;
        HashSet<int> set = new (nums);
        
        foreach (int x in set) 
        {
            bool isSeqStart = !set.Contains(x - 1);

            if (isSeqStart)
            {
                int seqStart = x;
                int seqLen = 0;

                while(set.Contains(seqStart))
                {
                    seqLen++;
                    seqStart++;
                }

                result = Math.Max(result, seqLen);
            }
        }

        return result;
    }
}