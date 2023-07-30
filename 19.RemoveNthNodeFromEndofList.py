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
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        first = head
        second = head
        
        for _ in range(n):
            first = first.next

        if not first:
            return head.next
        
        while first.next:
            first = first.next
            second = second.next

        second.next = second.next.next

        return head
    
s = Solution()
l1 = ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5, ListNode(6))))))
print_list(l1)
r = s.removeNthFromEnd(l1, 2)
print_list(r)