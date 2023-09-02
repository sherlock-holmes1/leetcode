public class Solution {
    public bool CanJump(int[] nums) 
    {
        int i = nums.Length - 1;
        while (i > 0)
        { 
            int j = i - 1;

            while(nums[j] + j < i)
            {
                j--;

                if (j < 0)
                    return false;
            }

            i = j;
        }

        return true;
    }
}

// 3,2,1,0,4
// we would need to compare jump distance from each position with the jump distance from previous position
// i1 = 3 and we would land on pos 3
// i2 = 2 and we would land on pos 3
// we would need to find endpos = max (nums[i], 1 + nums[i+1])
// and remember the end position i = endpos
// and newEndpos = max (nums[endpos], 1 + nums[endpos+1])
// all is in the loop, in case if nums[endpos] > 0, if not then stop => return false
// 2,3,1,1,4
// approach above does not work.
// another approach is to go from the back to start.
// search if there are any opportunities (numbers) to reach the end of the array.
// ---
// array Length = 5
// [1,2,3,4,5]
// First iteration
// -> 4 
// i = 4 + 4 > 5
// ---
// if there is an opportunity(array element) then do the search again in order to find a number to 
// ---
// 4 works for us
// we need to look for an element which allows us to reach 4
// -> 3
// reach this element. And so fourth 