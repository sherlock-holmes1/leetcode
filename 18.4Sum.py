from typing import List


class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        if len(nums) < 4:
            return []
        
        nums.sort()
        p_first = 0
        p_last = len(nums) - 1
        res = []
        sum = 0
        move_last = True

        while p_first < p_last:
            p_second = p_first + 1
            p_third = p_last - 1

            while p_second < p_third:
                sum = nums[p_first] + nums[p_second] + nums[p_third] + nums[p_last]
                
                if sum == target:
                    if [nums[p_first], nums[p_second], nums[p_third], nums[p_last]] not in res:
                        res.append([nums[p_first], nums[p_second], nums[p_third], nums[p_last]]) 

                    p_second += 1
                if sum > target:
                    p_third -= 1
                if sum < target:
                    p_second += 1
            
            if move_last:
                p_last -= 1
                move_last = False
            else:
                p_first += 1
                move_last = True

        return res

s = Solution()
r = s.fourSum([1,0,-1,0,-2,2], 0)
print(r)

r = s.fourSum([-3,-1,0,2,4,5], 2)
print(r)

r = s.fourSum([-3,-2,-1,0,0,1,2,3], 0)
print(r)
