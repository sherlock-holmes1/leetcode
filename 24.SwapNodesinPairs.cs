
// Definition for singly-linked list.
public class ListNode 
{
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) 
    {
          this.val = val;
          this.next = next;
    }
}
 
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if (head == null) { return head; }
        if (head.next == null) { return head; } 

        ListNode pointer1 = head;
        ListNode pointer2;
        ListNode res = SwapTwo(pointer1);
        pointer1 = res;
        
        while (pointer1.next.next != null)
        {
            pointer2 = pointer1.next.next;
            
            ListNode r = SwapTwo(pointer2);
            pointer1.next.next = r;
            pointer1 = r;
            
            if (pointer1.next == null)
                break;
        }

        return res;
    }
    private ListNode SwapTwo(ListNode one) {
        if (one.next == null) { return one; }

        ListNode? two = one.next;
        ListNode after_two = two.next;
        two.next = one;
        one.next = after_two;
        return two;
    }

    public static void PrintList(ListNode head) {
        Console.Write("[");
        
        while(head != null) 
        {
            Console.Write($"{head.val},");
            head = head.next;
        }

        Console.WriteLine("]");
    }
}