from typing import List
import sys

class Solution:
    def findMaxAverage(self, nums: List[int], k: int) -> float:
        window = []
        window_sum = 0
        average = -sys.float_info.max

        for i in range(len(nums)):
            window.append(nums[i])
            window_sum += nums[i]

            while len(window) >= k:
                win_avg = window_sum / len(window)
                average = max(average, win_avg)
                window_sum -= window[0]
                window = window[1:]

        return average
    
r = Solution().findMaxAverage(nums = [1,12,-5,-6,50,3], k = 4)
print(r)