class Solution:
    def intToRoman(self, num: int) -> str:
        int_to_roman = {1000:'M', 500:'D',  100:'C', 50:'L', 10:'X', 5:'V', 1:'I'}
        res = ''

        for k, v in int_to_roman.items():
            div = num // k
            if div > 0:
                for _ in range(div):
                    res += v 
            num -= div * k 
        
        res = res.replace('VIIII', 'IX').replace('IIII', 'IV').replace('LXXXX', 'XC').replace('XXXX', 'XL') \
            .replace('DCCCC', 'CM').replace('CCCC', 'CD')
        
        return res
    
s = Solution()
r = s.intToRoman(1994)
print(r)

