import java.util.LinkedList;
import java.util.Queue;

class Solution {
    public int findTheWinner(int n, int k) {
        Queue<Integer> queue = new LinkedList<>();

        for (int i = 1; i <= n; i++)
        {
            queue.add(i);
        }

        while (queue.size() > 1)
        {
            for (int j = 1; j < k; j++)
            {
                var elem = queue.poll();
                queue.add(elem);
            }

            queue.poll();
        }

        return queue.peek();
    }
}