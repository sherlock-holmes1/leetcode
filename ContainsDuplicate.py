from typing import List


class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        stack = set(nums)

        return len(stack) < len(nums)
    

s =  Solution()
r = s.containsDuplicate([1,1,1,3,3,4,3,2,4,2])

print(r)