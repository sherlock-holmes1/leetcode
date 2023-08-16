public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        
        if (this.IsValidParentheses(s)) 
        {
            return new List<string> { s };
        }

        HashSet<string> result = new ();

        var queue = new Queue<(string s, int i)>();
        queue.Enqueue((s, 0));
        int iter_prev = 0;

        while(queue.Count > 0) 
        {
            var elem = queue.Dequeue();
            string str = elem.s;
            int iter = elem.i;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '(' && str[i] != ')')
                {
                    continue;
                }

                var minus_par = str.Remove(i, 1);

                if (this.IsValidParentheses(minus_par))
                {
                    result.Add(minus_par);
                    continue;
                }
                else
                {
                     queue.Enqueue((minus_par, iter + 1));
                }              
            }

            if (result.Count > 0 && iter_prev != iter)
            {
               break;
            }  

            iter_prev = iter;
        }
        
        if (result.Count == 0)
            result.Add("");
        return new List<string>(result);
    }
    public bool IsValidParentheses(string s) {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s) 
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count <= 0)
                    return false;

                var p = stack.Pop();
                if (p != '(')
                    return false;
            }
            else
                continue;
        }
        
        return stack.Count == 0;
    }
}