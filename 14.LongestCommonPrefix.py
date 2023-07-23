from typing import List


class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        res = ''
        longest = max([len(s) for s in strs])
        i = 0
        c = ''
        same = True

        while i < longest:
            c = ''

            for s in strs:
                if len(s) <= i:
                    same = False
                    break
                
                if c == '':
                    c = s[i]

                if c != s[i]:
                    same = False
                    break

            i += 1
            if same:
                res += c

            if not same:
                break

        return res
    

s = Solution()
r = s.longestCommonPrefix(['aaabbb', 'aa'])
print(r)

r = s.longestCommonPrefix(["flower","flow","flight"])
print(r)

r = s.longestCommonPrefix(["dog","racecar","car"])
print(r)
