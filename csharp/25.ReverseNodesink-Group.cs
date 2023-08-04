// public class ListNode {
//     public int val;
//     public ListNode next;
//     public ListNode(int val=0, ListNode next=null) {
//         this.val = val;
//         this.next = next;
//     }
// }
 
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        int len = 1;
        ListNode next = head.next;
        ListNode newHead;

        // check if the list has k elements
        while (next != null) {
            next = next.next;
            len++;
        }

        if (len < k)
            return head;

        // else do the magic
        ListNode prev = null;
        newHead = ReverseK(head, prev, k);
        ListNode prev1;
        
        while (head.next != null) 
        {
            prev = head;
            prev1 = prev;
            next = head.next;
            head = head.next; 
            len = 0;
            
            while (next != null) {
                next = next.next;
                len++;  
            }

            if (len < k)
            {
                return newHead;
            }

            ListNode r = ReverseK(head, prev, k);
            prev1.next = r;
        }

        return newHead;
    }

    public ListNode ReverseK(ListNode start, ListNode prev, int k)
    {
        ListNode curr = start;
        ListNode next = curr.next;
        int len = 0;
        while (len < k)
        {
            curr.next = prev;
            prev = curr;
            curr = next;
            
            if (curr != null)
                next = curr.next;
            else
                break;

            len++;
        }
        
        start.next = curr;

        return prev;
    }
}