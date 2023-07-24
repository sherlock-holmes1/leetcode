from typing import List


class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        nums.sort()
        closest = nums[0] + nums[1] + nums[2]
        length = len(nums)

        for i in range(length - 1):
            first_num = nums[i]
            second = i + 1
            third =  length - 1

            while second < third:

                summa = first_num + nums[second] + nums[third]
                if abs(summa - target) < abs(closest - target):
                    closest = summa

                if summa > target:
                    third -= 1
                
                else:
                    second += 1

        return closest
    
s = Solution()
r = s.threeSumClosest([0,0,0], 1)
print(r)