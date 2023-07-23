from typing import List

class Solution:
    def maxArea(self, height: List[int]) -> int:
        self.position_left = 0
        self.position_right = len(height) - 1
        self.max_area = 0

        while self.position_left <= self.position_right:
            currentArea = min(height[self.position_left], height[self.position_right]) * (self.position_right - self.position_left)
            self.max_area = max(self.max_area, currentArea)

            if height[self.position_left] < height[self.position_right]:
                self.position_left += 1
            else:
                self.position_right -= 1

        return self.max_area
        
s = Solution()
r = s.maxArea([1,2,3,4,5,6,7,8,9,10])
print(r)

r = s.maxArea([1,8,100,2,100,4,8,3,7])
print(r)

r = s.maxArea([1,1])
print(r)

r = s.maxArea([1,8,6,2,5,4,8,3,7])
print(r)