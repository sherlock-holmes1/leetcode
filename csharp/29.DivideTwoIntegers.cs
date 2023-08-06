public class Solution {
    public int Divide(int dividend, int divisor)
    {
        long quotient = 0;
        long ldividend = dividend;
        long ldivisor = divisor;
        bool negative = !(dividend < 0 && divisor < 0) && !(dividend > 0 && divisor > 0);

        if (divisor == 0)
        {
            throw new ArgumentException("division by zero");
        }

        ldividend = Math.Abs(ldividend);
        ldivisor = Math.Abs(ldivisor);

        if (ldivisor == 1)
        {
            var res = this.checkMaxMin(negative, ldividend);

            if (res.Item1)
            {
                return res.Item2;
            }
            else
            {
                return this.CalcRes(negative, (int)ldividend);
            }
        }

        long incDivisor = ldivisor;
        while (ldividend - incDivisor >= 0)
        {
            long inc = 1;
            
            while (ldividend >= (incDivisor<<1))
            {
                incDivisor <<= 1;
                inc <<= 1;
            }

            ldividend -= incDivisor;
            quotient += inc;
            incDivisor = ldivisor;

            var res = this.checkMaxMin(negative, quotient);

            if (res.Item1)
            {
                return res.Item2;
            }
        }

        return this.CalcRes(negative, quotient);
    }

    private int CalcRes(bool negative, long number)
    {
        return (int)(negative ? -number : number);
    }

    private Tuple<bool, int> checkMaxMin(bool negative, long quotient)
    {
        if (negative && quotient > Math.Abs((long)int.MinValue))
        {
            return Tuple.Create(true, int.MinValue);
        }

        if (!negative && quotient > int.MaxValue)
        {
            return Tuple.Create(true, int.MaxValue);
        }

        return Tuple.Create(false, (int)quotient);
    }
}