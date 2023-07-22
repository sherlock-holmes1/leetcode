from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        for i, elem1 in enumerate(nums):
            for j, elem2 in enumerate(nums):
                if i == j:
                    continue
                if elem1 + elem2 == target:
                    return [i,j]
                
        return [-1, -1]

s = Solution()

result = s.twoSum(nums=[3,2,4], target=6)

print(result)