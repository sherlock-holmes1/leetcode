// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class Solution {
    public Node Connect(Node root) {
        var levels = new Dictionary<int, List<Node>>();
        var queue = new List<(Node node, int level)>()
        {
            (root, 0)
        };

        while (queue.Count > 0)
        {
            var el = queue[0];
            queue.RemoveAt(0);

            var node = el.node;

            if (node == null)
            {
                continue;
            }

            var lvl = el.level;

            if (!levels.ContainsKey(lvl))
            {
                levels[lvl] = new List<Node>();
            }

            levels[lvl].Add(node);

            if (node.left != null)
            {
                queue.Add((node.left, lvl + 1));
            }

            if (node.right != null)
            {
                queue.Add((node.right, lvl + 1));
            }
        }

        foreach (var level in levels.Keys)
        {
            for(int i = 0; i < levels[level].Count; i++)
            {
                if (i == levels[level].Count - 1)
                {
                    levels[level][i].next = null;
                }
                else
                {
                    levels[level][i].next = levels[level][i + 1]; 
                }
            }
        }

        return root;
    }
}