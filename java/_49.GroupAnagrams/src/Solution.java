import java.util.*;

class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        List<List<String>> result = new ArrayList<>();
        Hashtable<String, List<String>> dict = new Hashtable<>();

        for (String s: strs) {
            var chars = s.toCharArray();
            Arrays.sort(chars);
            var newS = new String(chars);

            dict.computeIfAbsent(newS, k -> new ArrayList<>());

            var ar = dict.get(newS);

            ar.add(s);
        }

        for (String key: dict.keySet())
        {
            result.add(dict.get(key));
        }

        return result;
    }
}