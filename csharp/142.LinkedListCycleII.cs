public class Solution {
    public ListNode? DetectCycle(ListNode head) 
    {
        Dictionary<ListNode, int> nodesNumbers = new ();
        ListNode? pointer = head;
        int pos = 0;

        while (pointer != null) 
        {
            if (nodesNumbers.ContainsKey(pointer))
            {
                return pointer;
            }

            nodesNumbers.Add(pointer, pos);
            pos++;
            pointer = pointer.next;
        }

        return null;
    }
}
