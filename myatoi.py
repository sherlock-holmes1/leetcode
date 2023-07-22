class Solution:
    def myAtoi(self, s: str) -> int:
        result_positive = 1
        lead_sign_found = False
        first_num_found = False
        result_num_str = ''
        max = 2147483647
        min = -2147483648

        for cha in s:
            if cha == ' ':
                if not lead_sign_found and not first_num_found:
                    continue
                else:
                    break
            
            if cha in '-+':
                if not lead_sign_found and not first_num_found:
                    lead_sign_found = True
                    result_positive = 1 if cha == '+' else -1
                    continue

                else:
                    break
            
            if cha == '0':
                if not first_num_found:
                    first_num_found = True
                    continue
                else:
                    result_num_str += cha
                    continue

            if cha in '123456789':
                first_num_found = True
                result_num_str += cha
                continue

            if cha not in '123456789':
                break

        if len(result_num_str) == 0:
            result_num = 0
        else:
            result_num = int(result_num_str)

        r = result_num * result_positive

        if r > max:
            r = max

        if r < min:
            r = min

        return r

    
s = Solution()
r = s.myAtoi("  +  413")
print(r)