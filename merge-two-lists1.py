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
        cur = dummy = ListNode()
        while list1 and list2:               
            if list1.val < list2.val:
                cur.next = list1
                list1 = list1.next
            else:
                cur.next = list2
                list2 = list2.next
            
            cur = cur.next

        if list1 or list2:
            cur.next = list1 if list1 else list2
            
        return dummy.next
    
s = Solution()
# [-10,-9,-6,-4,1,9,9]
#list1 = ListNode(-10, ListNode(-9, ListNode(-6, ListNode(-4, ListNode(1, ListNode(9, ListNode(9)))))))
list1 = ListNode(1, ListNode(3))
# [-5,-3,0,7,8,8]
#list2 = ListNode(-5, ListNode(-3, ListNode(0, ListNode(7, ListNode(8, ListNode(8))))))
list2 = ListNode(2, ListNode(4))
r = s.mergeTwoLists(list1, list2)

print_list(list1)
print_list(list2)
print_list(r)