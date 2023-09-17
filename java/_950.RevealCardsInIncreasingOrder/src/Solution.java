import java.util.*;

class Solution {
    public int[] deckRevealedIncreasing(int[] deck) {
        int[] result = new int[deck.length];
        Arrays.sort(deck);
        LinkedList<Integer> queue = new LinkedList<>();

        for(int i = deck.length - 1; i >=0; i--)
        {
            if (queue.isEmpty()) {
                queue.add(deck[i]);
            }
            else
            {
                var el = queue.poll();
                queue.add(el);
                queue.add(deck[i]);
            }
        }

        for(int i = deck.length - 1; i >=0; i--)
        {
            result[i] = queue.poll();
        }

        return result;
    }
}