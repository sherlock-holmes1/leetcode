class Solution:
    def romanToInt(self, s: str) -> int:
        roman_to_int = {'I':1,'V':5, 'X':10, 'L':50, 'C':100, 'D':500, 'M':1000}
        res = 0
        c_prev = ''
        mul = 1

        for c in s[::-1]:
            if c_prev == '':
                mul = 1
            elif roman_to_int[c_prev] > roman_to_int[c]:
                mul = -1
            else:
                mul = 1

            res += mul*roman_to_int[c]
            c_prev = c

        return res
    
s = Solution()
r = s.romanToInt('III')
print(r)