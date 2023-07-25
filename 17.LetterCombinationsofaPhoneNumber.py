from typing import List


class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        if digits == '':
            return []
        
        map = {2:'abc',
               3:'def',
               4:'ghi',
               5:'jkl',
               6:'mno',
               7:'pqrs',
               8:'tuv',
               9:'wxyz'}

        if len(digits) == 1:
            return [c for c in map[int(digits[0])]]
        
        else: 
            cur_ltrs = [c for c in map[int(digits[0])]]
            letter_combs = self.letterCombinations(digits[1:])
            res = []
            for cur_c in cur_ltrs:
                for letter_comb in letter_combs:
                    res.append(cur_c+letter_comb)

            return res
        
s = Solution()
r = s.letterCombinations('234')
print(r)
