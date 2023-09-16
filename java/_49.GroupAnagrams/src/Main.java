import java.util.StringJoiner;

public class Main {
    public static void main(String[] args)
    {
        var s = new Solution();
        var r = s.groupAnagrams(new String[] {"a"});
        StringJoiner joiner = new StringJoiner(",");
        r.forEach(item -> joiner.add(item.toString()));
        System.out.println(joiner);
    }
}