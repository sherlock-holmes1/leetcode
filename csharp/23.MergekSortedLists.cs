public class Solution {
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
            return null;

        if (lists.Length == 1 && lists[0] == null)
            return null;
        
        if (IfAllNull(lists))
            return null;

        ListNode resulto;
        ListNode resulto_pointer;
        ListNode[] pointers = lists;
        int min_pos;

        min_pos = FindMinAndIndex(pointers);
        resulto = pointers[min_pos];
        resulto_pointer = resulto;
        pointers[min_pos] = pointers[min_pos].next;
        bool allNull = false;

        while (!allNull)
        {
            min_pos = FindMinAndIndex(pointers);
            resulto_pointer.next = pointers[min_pos];
            resulto_pointer = resulto_pointer.next;

            if (pointers[min_pos] != null)
                pointers[min_pos] = pointers[min_pos].next;

            allNull = IfAllNull(pointers);
        }

        return resulto;
    }

    private static bool IfAllNull(ListNode[] pointers)
    {
        bool allNull = true;
        foreach (ListNode pointer in pointers)
        {
            if (pointer != null)
            {
                allNull = false;
                break;
            }
        }

        return allNull;
    }

    private int FindMinAndIndex(ListNode[] lists)
    {
        ListNode min = null; 
        int position = 0;

        for (int i = 0; i < lists.Length; i++)        
        {
            if (lists[i] != null)
            {
                min = lists[i];
                position = i;
                break;
            }
        }

        for (int i = 0; i < lists.Length; i++)
        {
            ListNode node = lists[i];

            if (node == null)
                continue;

            if (node.val < min.val)
            {
                min = node;
                position = i;
            }
        }

        return position;
    }
}