public class Solution {
    public IList<int> PartitionLabels(string s) {
        List<int> result = new ();
        Dictionary<char, int> dictPos = new ();
        for (int i = s.Length - 1; i >= 0; i--) {
            char c = s[i];

            if (!dictPos.ContainsKey (c)) 
                dictPos.Add (c,i);
            
            if (dictPos.Count > 26)
                break;
        }

        int partStart = 0;
        int partEnd;

        while (partStart <= s.Length - 1)
        {
            char c = s[partStart];
            partEnd = dictPos[c];

            for (int j = partStart; j <= s.Length - 1; j++)
            {
                if (dictPos[s[j]] > partEnd)
                {
                    partEnd = dictPos[s[j]];
                }
                if (j == partEnd)
                {
                    result.Add(partEnd - partStart + 1);
                    partStart = partEnd + 1;
                    break;
                }
            }
        }  

        return result;
    }
}