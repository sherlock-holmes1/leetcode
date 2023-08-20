class Solution:
    def divisorSubstrings(self, num: int, k: int) -> int:
        res = 0
        s_num = str(num)
        if k > len(s_num):
            return res
        
        # if k > 1:
        #     s_num = '0'*(k-1) + s_num

        right = 0
        window = ''

        while right < len(s_num):
            window += s_num[right]

            while len(window) >= k:
                if int(window) == 0:
                    window = window[1:]
                    continue

                if num % int(window) == 0:
                    res += 1

                window = window[1:]

            right += 1
        
        return res

r = Solution().divisorSubstrings(430043, 2)
print(r)