public class Main {
    public static void main(String[] args)
    {
        var s = new Solution();
        var head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
        var r = s.insertionSortList(head);

        while (r != null)
        {
            System.out.print(r.val + ",");
            r = r.next;
        }
    }
}
