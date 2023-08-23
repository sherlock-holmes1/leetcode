public class Solution {
    public ListNode? Partition(ListNode head, int x) {
        ListNode? one = null;
        ListNode? two = null;
        ListNode? headOfTwo = null;
        ListNode? headOfOne = null;

        ListNode pointer = head;

        while (pointer != null)
        {
            if (pointer.val < x)
            {
                if (one == null)
                {
                    one = new ListNode(pointer.val);
                    headOfOne = one;
                }
                else
                {
                    one.next = new ListNode(pointer.val);
                    one = one.next; 
                }
            }
            else if (pointer.val >= x)
            {
                if (two == null)
                {
                    two = new ListNode(pointer.val);
                    headOfTwo = two;
                }
                else
                {
                    two.next = new ListNode(pointer.val);
                    two = two.next; 
                }                
            }

            pointer = pointer.next;
        }

        if (one != null)
            one.next = headOfTwo;

        return headOfOne ?? headOfTwo;
    }
}