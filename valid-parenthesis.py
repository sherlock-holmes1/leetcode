class Solution:
    def isValid(self, s: str) -> bool:
        if len(s) < 2:
            return False
        
        par_dict = {'[':']', '{':'}', '(':')'}
        par_open = ['[', '{', '(']
        par_close = [']', '}', ')']
        par_stack = []

        for c in s:
            if c in par_open:
                par_stack.append(c)

            if c in par_close:
                if len(par_stack) == 0:
                    return False
                
                in_stack = par_stack.pop()

                if par_dict[in_stack] != c:
                    return False
        
        if len(par_stack) > 0:
            return False
        
        return True
    
s = Solution()
r = s.isValid('))')
print(r)


