public class Solution {
    public long[] SumOfThree(long num) {
        var result = new List<long>();
        
        if (num % 3 == 0)
        {
            var third = num / 3;
            
            result.Add(third - 1);
            result.Add(third);
            result.Add(third + 1);  
        }

        return result.ToArray();
    }
}