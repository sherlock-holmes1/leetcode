class Solution:
    def reverse(self, x: int) -> int:
        min = -2**31
        max = 2**31 - 1
        less_than_zero = x < 0 
        x_abs = abs(x)
        x_str = str(x_abs)
        x_rev_str = x_str[::-1]
        x_rev = int(x_rev_str)

        res = x_rev if not less_than_zero else -x_rev
        if res > max or res < min:
            res = 0

        return res

    

s = Solution()
r = s.reverse(123)
print(r)