from typing import List


class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        res = []
        map = {2:'abc',
               3:'def',
               4:'ghi',
               5:'jkl',
               6:'mno',
               7:'pqrs',
               8:'tuv',
               9:'wxyz'}
        
        ln = len(digits)
        comb = ''

        for i in range(ln - 1): # digits
            ltrs = map[int(digits[i])]
            
            for j in range(len(ltrs) - 1): # letters for a digit
                comb += ltrs[j]
