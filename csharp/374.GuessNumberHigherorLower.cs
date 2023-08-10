/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */
public class GuessGame
{
    public int guess(int num)
    {
        int n = 1;
        if (num > n)
            return -1;
        
        if (num < n)
            return 1;

        return 0;
    }
}
public class Solution : GuessGame {
    public int GuessNumber(int n) 
    {
        int high = n;
        int low = 1;

        int guess_num = n / 2;
        
        if (guess_num < 1)
        {
            return 1;
        }

        int res = guess(guess_num);

        while (res != 0)
        {
            int delta;

            if (res == -1) // guess is higher, we need to decrease
            {
                high = guess_num;
                delta = (high - low) / 2;
                
                if ((high - low) % 2 > 0)
                {
                    delta++;
                }

                guess_num -= delta;
            }
            else if (res == 1) // guess is lower, we need to increase
            {
                low = guess_num;
                delta = (high - low) / 2;
                
                if ((high - low) % 2 > 0)
                {
                    delta++;
                }
                
                guess_num += delta;
            }

            res = guess(guess_num);
        }

        return guess_num;
    }
}