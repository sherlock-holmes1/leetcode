class Solution {
    public ListNode insertionSortList(ListNode head) {
        ListNode newHead = null;
        ListNode next = head;

        while (next != null)
        {
            if (newHead == null)
            {
                newHead = new ListNode(next.val);
            }
            else
            {
                ListNode iter = newHead;
                ListNode prev = newHead;

                while (iter != null && iter.val < next.val) {
                    prev = iter;
                    iter = iter.next;
                }

                ListNode nextCopy = new ListNode(next.val);
                if (iter == newHead)
                {
                    nextCopy.next = newHead;
                    newHead = nextCopy;
                }
                else
                {
                    prev.next = nextCopy;
                    nextCopy.next = iter;
                }
            }

            next = next.next;
        }

        return newHead;
    }
};

//  head = [4,2,1,3]
// next = 4, result = 4, newHead = 4
// next = 2, result = 2, 4, newHead = 2
// next = 1, result = 1, 2, 4, newHead = 1
// next = 3, result