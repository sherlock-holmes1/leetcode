public class Solution {
    public double[] MedianSlidingWindow(int[] nums, int k) 
    {
        var result = new List<double>();
        List<int> meds = new();
        int med = k / 2;
        
        if (k % 2 == 0) 
        {   
            meds.Add(med);
            meds.Add(med + 1);
        }
        else
        {
            meds.Add(med + 1);
        }

        List<int> window = new ();
        for (int i = 0; i < k; i++)
        {
            window.Add (nums[i]);
        }

        window.Sort();

        InsertMedian(result, meds, window);

        for (int m = 1; m <= nums.Length - k; m++)
        {
            int left = nums[m - 1];
            int right = nums[m + k - 1];
            window.Remove(left);
            int index = window.BinarySearch(right);

            if (index < 0)
            {
                index = ~index;
            }

            window.Insert(index, right);

            InsertMedian(result, meds, window);
        }

        return result.ToArray();
    }

    private static void InsertMedian(List<double> result, List<int> meds, List<int> window)
    {
        if (meds.Count == 1)
        {
            result.Add(window[meds[0] - 1]);
        }
        else if (meds.Count == 2)
        {
            result.Add((window[meds[0] - 1] + (double)window[meds[1] - 1]) / 2);
        }
    }
}