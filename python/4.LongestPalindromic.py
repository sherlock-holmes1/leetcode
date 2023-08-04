#Input: s = "babad"
#Output: "aba"
#
class Solution:
    stri = ''
    def longestPalindrome(self, s: str) -> str:    
        input_strlen = len(s)
        longest_palindrome = ""
        self.stri = s

        if input_strlen == 0:
            return longest_palindrome
        
        for index in range(input_strlen):            
            longest_palindrome = max(longest_palindrome, 
                                     self.return_longest_palindrome(index, index),
                                     self.return_longest_palindrome(index, index + 1), key=len)

        return longest_palindrome
    
    def return_longest_palindrome(self, left:int, right:int) -> str:
        while left >= 0 and right < len(self.stri) and self.stri[left] == self.stri[right]:
            left -= 1
            right += 1

        return self.stri[left + 1:right]

s = Solution()
res = s.longestPalindrome("cbbd")
print(res)