public class Solution {
    public int NthUglyNumber(int n) 
    {
        if (n < 0)
        {
            return 0;
        }

        int multipleOf2 = 2;
        int i2 = 0;

        int multipleOf3 = 3;
        int i3 = 0;

        int multipleOf5 = 5;
        int i5 = 0;

        int[] ugly = new int [n];
        ugly[0] = 1;
        int result = 1;
        List<int> results = new();
        int i = 1;

        while (i < n) 
        {
            result = Math.Min(multipleOf2, Math.Min(multipleOf3, multipleOf5));
            ugly[i] = result;
            results.Add(result);

            if (result == multipleOf2)
            {
                i2++;
                multipleOf2 = ugly[i2] * 2;
            }
            
            if (result == multipleOf3)
            {
                i3++;
                multipleOf3 = ugly[i3] * 3;
            }
            
            if (result == multipleOf5)
            {
                i5++;
                multipleOf5 = ugly[i5] * 5;
            }

            i++;
        }

        return result;
    }
}