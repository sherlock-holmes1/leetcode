class Solution:
    def checkInclusion(self, s1: str, s2: str) -> bool:
        window_size = len(s1)
        str_size = len(s2)
        if str_size < window_size:
            return False
        
        window = ''

        for i in range(str_size):
            window += s2[i]

            while len(window) >= window_size:
                if self.strings_equal(window, s1):
                    return True
                
                window = window[1:]
        
        return False

    def strings_equal(self, str1:str, str2:str):
        return sorted(str1) == sorted(str2)

s = Solution()
r = s.checkInclusion("ba", "abcad")
print(r)