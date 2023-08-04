# Definition for singly-linked list.
from typing import Optional

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def print_list(lst: ListNode):
    print(f'[{lst.val}', end="")

    while lst.next:
        lst = lst.next
        print(f",{lst.val}", end="")

    print(']')

class Solution:
    def mergeTwoLists(self, list1: Optional[ListNode], list2: Optional[ListNode]) -> Optional[ListNode]:
        if not list1:
            return list2
        if not list2:
            return list1

        if not list1 and not list2:
            return ListNode()
        
        head = ListNode()
        tail = head

        while list1 or list2:
            val1 = list1.val if list1 else None
            val2 = list2.val if list2 else None

            if val1 is None:
                tail.val = val2
                list2 = list2.next
                tail = self.move_tail_if_needed(list1, list2, tail)
                continue

            if val2 is None:
                tail.val = val1
                list1 = list1.next
                tail = self.move_tail_if_needed(list1, list2, tail)
                continue

            if val1 <= val2:
                tail.val = val1
                list1 = list1.next
                tail = self.move_tail_if_needed(list1, list2, tail)

            else:
                tail.val = val2
                list2 = list2.next
                tail = self.move_tail_if_needed(list1, list2, tail)

        return head

    def move_tail_if_needed(self, list1, list2, tail):
        if list1 or list2:
            tail.next = ListNode()
            tail = tail.next
        return tail
        
    
s = Solution()
# [-10,-9,-6,-4,1,9,9]
list1 = ListNode(-10, ListNode(-9, ListNode(-6, ListNode(-4, ListNode(1, ListNode(9, ListNode(9)))))))
# [-5,-3,0,7,8,8]
list2 = ListNode(-5, ListNode(-3, ListNode(0, ListNode(7, ListNode(8, ListNode(8))))))
r = s.mergeTwoLists(list1, list2)

print_list(list1)
print_list(list2)
print_list(r)
