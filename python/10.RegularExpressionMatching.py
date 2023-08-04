import re

class Solution:
    def isMatch(self, s: str, p: str) -> bool:
        
        return self.get_match(s, p) is not None

    def get_match(self, s: str, p: str):
        
        try:
            m = re.match(fr"^{p}$", s)
        
            return m
        except:

            return None
    
s = Solution()
r = s.isMatch("abc", "a***abc")
print(r)