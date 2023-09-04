using System.Diagnostics.CodeAnalysis;

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        var candidates1 = new List<int>(candidates);
        candidates1.Sort();
        var result = new List<IList<int>>();
        var queue = new List<(int sum, List<int> numbers)>();
        var possibleValues = new Dictionary<int, bool>();

        foreach (var candidate in candidates1)
        {
            queue.Add((candidate, new List<int> {candidate}));
            possibleValues.Add(candidate, true);
        }

        while (queue.Count > 0)
        {
            var element = queue[0];
            queue.RemoveAt(0);
            var sum = element.sum;
            var numbers = element.numbers;

            if (numbers.Count == 1)
            {
                var number = numbers[0]; 

                if (possibleValues[number] && number == target)
                {
                    result.Add(numbers.ToArray());
                }

                if (possibleValues.Keys.All(i => number + i > target))
                {
                    possibleValues[number] = false;
                }
            }

            foreach (var candidate in possibleValues.Keys)
            {
                if (possibleValues[candidate])
                {
                    if (sum + candidate == target)
                    {
                        numbers.Add(candidate);
                        numbers.Sort();
                        var numbersAsArray = numbers.ToArray();
                        if (!result.Contains(numbersAsArray, comparer:new ListComparer()))
                            result.Add(numbersAsArray);
                    }
                    if (sum + candidate < target)
                    {
                        var numbersCopy = new List<int>(numbers)
                        {
                            candidate
                        }; 
                        queue.Add((sum + candidate, numbersCopy));
                    }
                }
            }
            
        }

        return result;
    }
}
public class ListComparer : IEqualityComparer<IList<int>>
{
    public bool Equals(IList<int>? x, IList<int>? y)
    {
        if (x == null && y == null)
            return true;

        if (x == null || y == null)
            return false;

        if (x.Count != y.Count)
            return false;

        for (int i = 0; i < x.Count; i++)
        {   
            if (!x[i].Equals(y[i]))
                return false;
        }
        
        return true;
    }

    public int GetHashCode([DisallowNull] IList<int> obj)
    {
        return obj.GetHashCode();
    }
}


// Example 1:
// Input: candidates = [2,3,6,7], target = 7
// Output: [[2,2,3],[7]]
// Explanation:
// 2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
// 7 is a candidate, and 7 = 7.
// These are the only two combinations.

// Example 2:
// Input: candidates = [2,3,5], target = 8
// Output: [[2,2,2,2],[2,3,3],[3,5]]

// Example 3:
// Input: candidates = [2], target = 1
// Output: []
// 
// The solution idea
// I would use the queue for adding numbers from the candidates
// Each queue element will have the following attributes
// num, sum, list of elements for sum
// initial list of the candidates I would convert to the dict (num -> impossible), meaning that  this number 
// can not give target sum
// 1. put the each of the candidates to the queue, and the dict with the flag possible
// 2. while we have elements in the queue, do
// 3. get element from the queue
// 3.1 add it to the sum, add it to the list, mark as possible, 
// 3.2 go through the dictionary and try to add each element marked as possible to the sum
// 3.3 If for each element the sum with the current element is greater than the target, and this is the only element
// mark current element as impossible in the dict
// 3.4 put all sums with the curent element to the queue
// 3.5 if sum gives us the target add it to the result. And do not put it to the queue
// 3.5.1 check if result does not contain this list of elements already
// 3.6 if the sum is greater than the target and # of elements is more than one, do not put it to the queue
// 4. return result

// target = 7
// candidates = 2,3,6,7
// dict {2:false, 3:false, 6: false, 7: false}
// queue {(2, 2, <2>), (3, 3, <3>), (6, 6, <6>), (7, 7, <7>)}
// get 1 elem from the queue (2, 2, <2>)
// dict -> {2:false, 3:false, 6: false, 7: false} 
// new queue elements (2, 4, <2,2>), (2, 5, <2,3>)
/***************************/
// get 2 elem from the queue (3, 3, <3>)
// dict -> {2:false, 3:false, 6: false, 7: false}
// new queue elements (3, 5, <3,2>), (3, 6, <3,3>)
/***************************/
// get 3 elem from the queue (6, 6, <6>)
// mark 6 as impossible
// dict -> {2:false, 3:false, 6: true, 7: false} 
/***************************/
// get 4 elem from the queue (7, 7, <7>)
// result.add(<7>)
/***************************/
// get 5 elem from the queue (2, 4, <2,2>)
// dict -> {2:false, 3:false, 6: true, 7: false} 
// new queue elements (2, 6, <2,2,2>)
// result.add(<2,2,3>)
/***************************/
// get 6 elem from the queue (2, 5, <2,3>)
// dict -> {2:false, 3:false, 6: true, 7: false} 
// result already contains <2,2,3>
// another option <2,3,3> is bigger than target




