import heapq
from typing import List

class Solution:
    def findKthLargest(self, nums: List[int], k: int) -> int:

        if len(nums) < k:
            return 0;

        pq = nums[0:k]
        heapq.heapify(pq)
        
        for i in range(k, len(nums)):
            if nums[i] > pq[0]:
                heapq.heapreplace(pq, nums[i])

        return pq[0]
    
r = Solution().findKthLargest([3,2,1,5,6,4], 2)
print(r)