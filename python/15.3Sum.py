from typing import List


class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        res = []
        length = len(nums)
        for i in range(length - 1):
            first_num = nums[i]
            second = i + 1
            third =  length - 1

            while second < third:
                
                summa = first_num + nums[second] + nums[third]
                if summa > 0:
                    third -= 1
                
                elif summa < 0:
                    second += 1

                else:
                    try:
                        ind = res.index([first_num, nums[second], nums[third]])
                    except:
                        res.append([first_num, nums[second], nums[third]])
                    second += 1

        return res
    
s = Solution()
r = s.threeSum([-1,0,1,2,-1,-4])

print(r)