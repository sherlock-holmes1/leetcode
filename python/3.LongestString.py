#Input: s = "abcabcbb"
#Output: 3
#Explanation: The answer is "abc", with the length of 3.
#
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        strlen = len(s)
        
        if strlen == 0:
            return 0
        
        longest_str = 1

        for i in range(strlen):
            len_from_i = 1
            str_from_i = s[i]
            for j in range(i + 1, strlen):
                if s[j] not in str_from_i:
                    str_from_i += s[j]
                    len_from_i += 1
                else:
                    break
            
            if len_from_i > longest_str:
                longest_str = len_from_i

        return longest_str
    


s = Solution()
length = s.lengthOfLongestSubstring("pwwkew")
print(length)