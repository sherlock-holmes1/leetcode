from collections import defaultdict

class Solution:
    def longestSubstring(self, s: str, k: int) -> int:
        res = 0

        for letter in range(1, len(set(s)) + 1):
            left = 0
            right = 0
            num = 0
            freq = defaultdict(int)

            while right < len(s):
                freq[s[right]] += 1
                cur_uniq = len(freq)
                if freq[s[right]] == k: 
                    num += 1

                while cur_uniq > letter:
                    freq[s[left]] -= 1
                    if freq[s[left]] == k - 1:
                        num -= 1
                    
                    if  freq[s[left]] == 0:
                        cur_uniq -= 1
                        del freq[s[left]]
                    left += 1

                if num == cur_uniq:
                    res = max (res, right - left + 1)
                
                right += 1

        return res

# r = Solution().longestSubstring("aaabbb", 3)
# print(r)

# r = Solution().longestSubstring("ababbc", 2)
# print(r)

r = Solution().longestSubstring("bbaaacbd", 3)
print(r)