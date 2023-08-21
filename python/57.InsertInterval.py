from typing import List


class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        
        intervals.append(newInterval)
        intervals = sorted(intervals, key=lambda x: x[0])
        
        i = 1
        
        while i < len(intervals):
            if intervals[i - 1][1] >= intervals[i][0]:
                intervals[i - 1][1] = max(intervals[i - 1][1], intervals[i][1])
                del intervals[i]
            else:
                i += 1

        return intervals
    

r = Solution().insert(intervals = [[1,3],[6,9]], newInterval = [2,5])
r1 = Solution().insert(intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8])
r2 = Solution().insert(intervals = [[1,5]], newInterval = [2,3])
r3 = Solution().insert(intervals = [[1,5]], newInterval = [6,8])
r4 = Solution().insert(intervals = [[1,5]], newInterval = [0,3])
r5 = Solution().insert(intervals = [[1,5]], newInterval = [0,0])
r6 = Solution().insert(intervals = [[3,5],[12,15]], newInterval = [6,6])
r7 = Solution().insert(intervals = [[1,5]], newInterval = [0,1])

print(r)
print(r1)
print(r2)
print(r3)
print(r4)
print(r5)
print(r6)
print(r7)