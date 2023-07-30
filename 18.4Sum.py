from typing import List


class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        if len(nums) < 4:
            return []
        
        nums.sort()
        res = set()
        sum = 0

        for i in range(len(nums)):
            for j in range (i + 1, len(nums)):

                p_second = j + 1
                p_third = len(nums) - 1

                while p_second < p_third:
                    sum = nums[i] + nums[j] + nums[p_second] + nums[p_third]
                    
                    if sum == target:
                        res.add((nums[i], nums[j], nums[p_second], nums[p_third])) 
                        p_second += 1
                        p_third -= 1

                    if sum > target:
                        p_third -= 1
                    if sum < target:
                        p_second += 1
            

        return list(res)

s = Solution()
r = s.fourSum([1,0,-1,0,-2,2], 0)
print(r)

r = s.fourSum([-3,-1,0,2,4,5], 2)
print(r)

r = s.fourSum([-3,-2,-1,0,0,1,2,3], 0)
print(r)
