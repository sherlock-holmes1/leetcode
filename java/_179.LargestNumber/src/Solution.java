import java.util.*;

class Solution {
    public String largestNumber(int[] nums) {
        StringJoiner joiner = new StringJoiner("");
        ArrayList<String> numsAsStrings = new ArrayList<>();

        for (int num: nums) {
            numsAsStrings.add(Integer.toString(num));
        }

        numsAsStrings.sort((o1, o2) -> (o2 + o1).compareTo(o1 + o2));

        for (String str: numsAsStrings) {
            joiner.add(str);
        }

        String res = joiner.toString();
        return res.startsWith("0") ? "0" : res;
    }
}