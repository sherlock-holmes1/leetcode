class Solution:
    def isPalindrome(self, x: int) -> bool:
        s = str(x)
        head = 0
        tail = len(s) - 1
        while head <= tail:
            if s[head] != s[tail]:
                return False
            
            head += 1
            tail -= 1

        return True
    

s = Solution()
r = s.isPalindrome(-1221)

print(r)