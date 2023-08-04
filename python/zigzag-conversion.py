class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows == 0:
            return ''
        
        vertical_line = [None] * numRows
        lines = []
        str_pointer = 0
        arr_pointer = 0

        while str_pointer < len(s):
            # enter as many letters as we can in the first line
            while str_pointer < len(s):
                vertical_line[arr_pointer] = s[str_pointer]
                
                str_pointer += 1
                arr_pointer += 1
                if arr_pointer == numRows: 
                    arr_pointer -= 1
                    break

            # enter only one letter in each line
            while str_pointer < len(s):
                lines.append(vertical_line)
                vertical_line = [None] * numRows
                
                arr_pointer -= 1
                if arr_pointer < 1:
                   arr_pointer = 0
                   break

                vertical_line[arr_pointer] = s[str_pointer]
                str_pointer += 1
            
        if len(vertical_line) > 0:
            lines.append(vertical_line)

        result = ''
        for i in range(numRows):
            for l in lines:
                if l[i]:
                    result += l[i]

        return result

s = Solution()
r = s.convert("PAYPALISHIRING", 4)
print (r)