from typing import List


class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        combined_length = len(nums1) + len(nums2)
        half_rem = combined_length % 2
        half = combined_length // 2 + half_rem
        i1 = 0
        i2 = 0
        res = []
        med = 0

        while i1 < len(nums1) or i2 < len(nums2):
            if i1 < len(nums1) and i2 < len(nums2):
                if nums1[i1] < nums2[i2]:
                    res.append(nums1[i1])
                    i1 += 1

                else:
                    res.append(nums2[i2])
                    i2 += 1
            elif i1 < len(nums1):
                res.append(nums1[i1])
                i1 += 1
            else:
                res.append(nums2[i2])
                i2 += 1

            if  len(res) == half:
                med = res[-1]

                if half_rem == 1:
                    break

            if half_rem == 0 and len(res) == half + 1:
                med += res[-1]
                med = med / 2
                break

        return med
    
s = Solution()
r = s.findMedianSortedArrays([1,2], [3,4])
print(r)
