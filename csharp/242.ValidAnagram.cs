public class Solution {
    public bool IsAnagram(string s, string t) {
        Dictionary<char, int> letters = new();

        foreach(char c in s)
        {
            if (letters.ContainsKey(c))
            {
                letters[c]++;    
            }
            else
            {
                letters.Add(c, 1);
            }
        }

        foreach(char c in t)
        {
            if (!letters.ContainsKey(c))
            {
                return false;
            }
            if (letters[c] == 0)
            {
                return false;
            }

            letters[c]--;
        }
        foreach (char c in letters.Keys)
        {
            if (letters[c] > 0)
                return false;
        }

        return true;    
    }
}