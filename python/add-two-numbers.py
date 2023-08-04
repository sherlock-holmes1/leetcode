# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
from typing import Optional

def print_list(lst: ListNode):
    print(f'[{lst.val}', end="")

    while lst.next:
        lst = lst.next
        print(f",{lst.val}", end="")

    print(']')

# def make_list(l1:ListNode) -> list:
#     lst = []
#     lst.append(l1.val)
    
#     while l1.next:
#         l1 = l1.next
#         lst.append(l1.val)

#     return lst

class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        lst1 = self.make_list(l1)
        lst2 = self.make_list(l2)

        max_len = max(len(lst1), len(lst2))
        long_lst = lst1 if max_len == len(lst1) else lst2
        short_lst = lst2 if max_len == len(lst1) else lst1
        res_lst = []
        remainder = 0

        for i in range(max_len):
            second = 0
            if i < len(short_lst):
                second = short_lst[i]

            sum = long_lst[i] + second + remainder
            remainder = 0

            if sum > 9:
                sum = sum - 10
                remainder = 1

            res_lst.append(sum)

        if remainder:
            res_lst.append(remainder)

        result_final = ListNode()
        result = result_final
        
        for i in range(len(res_lst)):
            result.val = res_lst[i]
            
            if i < len(res_lst) - 1:
                result.next = ListNode()
                result = result.next

        return result_final
    
    def make_list(self, l1:ListNode) -> list:
        lst = []
        lst.append(l1.val)
        
        while l1.next:
            l1 = l1.next
            lst.append(l1.val)

        return lst

s = Solution()
n1 = ListNode(2, ListNode(4, ListNode(3)))
n2 = ListNode(5, ListNode(6, ListNode(4)))
r = s.addTwoNumbers(n1, n2)
print_list(n1)
print_list(n2)
print_list(r)

# l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
s = Solution()
n1 = ListNode(9, ListNode(9, ListNode(9, ListNode(9))))
n2 = ListNode(9, ListNode(9, ListNode(9)))
r = s.addTwoNumbers(n1, n2)
print_list(n1)
print_list(n2)
print_list(r)
