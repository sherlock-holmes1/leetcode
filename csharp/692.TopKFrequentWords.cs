public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        Dictionary<string, int> map = new ();
        int max = 0;
        Dictionary<int, List<string>> reverse = new Dictionary<int, List<string>>();

        foreach (string word in words) 
        {
            if (!map.ContainsKey(word))
            {
                map.Add (word, 1);
                if (!reverse.ContainsKey(1))
                {
                    reverse.Add(1, new List<string>());
                }
                
                if (max < 1)
                    max = 1;

                reverse[1].Add(word);
            }
            else
            {
                int freq = ++map[word];

                if (freq > max)
                {
                    max = freq;
                }

                if (!reverse.ContainsKey(freq))
                {
                    reverse.Add(freq, new List<string>());
                }

                reverse[freq].Add(word);

                reverse[freq - 1].Remove(word);
            }
        }

        List<string> res = new();
        bool sorted = false;
        for (int j = 0; j < k; j++)
        {
            while (reverse[max].Count == 0)
            {
                max--;
                sorted = false;
            }

            if (!sorted)
            {
                reverse[max].Sort();
                sorted = true;
            }
            
            string l = reverse[max][0];

            res.Add(l);
            reverse[max].RemoveAt(0);
        }

        return res;      
    }
}