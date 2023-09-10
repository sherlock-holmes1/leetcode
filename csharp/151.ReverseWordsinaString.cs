public class Solution {
    public string ReverseWords(string s) {
        string result = "";
        string[] words = s.Trim().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        for (int i = words.Length - 1; i >= 0; i--) 
        {
            result += words[i] + " ";
        }
        
        return result.Trim();
    }
}