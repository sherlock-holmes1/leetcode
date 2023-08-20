from collections import defaultdict
from typing import List


class Solution:
    def findLength(self, nums1: List[int], nums2: List[int]) -> int:
        res = 0
        nums2_pos = defaultdict(list)
        for ind2, elem2 in enumerate(nums2):
            nums2_pos[elem2].append(ind2)

        for i, elem1 in enumerate(nums1):
            for j in nums2_pos[elem1]:
                k = 0
                while i + k < len(nums1) and j + k < len(nums2) and nums1[i + k] == nums2[j + k]:
                    k += 1

                res = max(res, k)
        
        return res
    
r = Solution().findLength(nums1 = [70,39,25,40,7], nums2 = [52,20,67,5,31])
r1 = Solution().findLength(nums1 = [5,14,53,80,48], nums2 = [50,47,3,80,83])
r2 = Solution().findLength(nums1 = [37,75,25,76,29,1,78,91,8,28], nums2 = [41,18,89,74,38,23,99,54,7,86])
r3 = Solution().findLength(nums1 = [0,0,0,0,1], nums2 = [1,0,0,0,0])
r4 = Solution().findLength(nums1 = [1,2,3,2,1], nums2 = [3,2,1,4,7])
r5 = Solution().findLength(nums1 = [0,0,0,0,0,0,1,0,0,0], nums2 = [0,0,0,0,0,0,0,1,0,0])

#r1 = Solution().is_sublist([80], [50,47,3,80,83])
print (r)
print (r1)
print (r2)
print (r3)
print (r4)
print (r5)