import java.util.Arrays;

class Solution {
    public boolean canChoose(int[][] groups, int[] nums) {
        var numsAsString = replacePars(Arrays.toString(nums));
        int firstOccurrence = 0;

        for (int[] group : groups) {
            String groupAsString = replacePars(Arrays.toString(group));
            var index = numsAsString.indexOf(groupAsString, firstOccurrence);

            if (index < 0)
                return false;

            firstOccurrence = index + groupAsString.length();
        }


        return true;
    }

    private static String replacePars(String numsAsString) {
        return numsAsString.replace('[', ' ').substring(0, numsAsString.length() - 1);
    }
}