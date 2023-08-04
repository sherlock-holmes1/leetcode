from typing import List


class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        def generate(A=[], opened = 0, closed = 0):
            if len(A) == 2 * n:
                output.append(''.join(A))
                return
            
            if opened < n:
                A.append('(')
                generate(A, opened+1, closed)
                A.pop()

            if closed < opened:
                A.append(')')
                generate(A, opened, closed+1)
                A.pop()

        output = []
        generate()
        return output 
           
s = Solution()
r = s.generateParenthesis(2)
print(r)