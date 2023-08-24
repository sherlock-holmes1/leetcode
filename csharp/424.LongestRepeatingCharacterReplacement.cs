using System.Runtime.InteropServices;
using System.Linq;

public class Solution {
    public int CharacterReplacement(string s, int k) 
    {
        string window = string.Empty;
        int res = 0;
        Dictionary<char, int> map = new ();
        int max = 0;

        for (int i = 0; i < s.Length; i++)
        {
            window += s[i];
            map[s[i]] = map.ContainsKey(s[i]) ? map[s[i]] + 1 : 1;
            max = CountMaxRep(map);

            if (window.Length - max <= k)
            {
                res = Math.Max(res, window.Length);
            }

            while (window.Length - max > k)
            {
                res = Math.Max(res, window.Length - 1);
                char zeroPos = window[0]; 
                map[zeroPos] -= 1;

                if (map[zeroPos] == 0)
                { 
                    map.Remove(zeroPos);
                }

                window = window.Remove(0, 1);

                max = CountMaxRep(map);
            }
        }

        return res; 
    }

    private static int CountMaxRep(Dictionary<char, int> map)
    {
        int max = 0;

        foreach (var key in map.Keys.Where(key => map[key] > max))
        {
            max = map[key];
        }

        return max;
    }
}