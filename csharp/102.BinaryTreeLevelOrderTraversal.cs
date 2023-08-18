public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) {
            return new List<IList<int>>();
        }

        Dictionary<int, IList<int>> dict = new ();

        var queue = new Queue<(TreeNode node, int level)> ();
        dict.Add(0, new List<int> () { root.val });
        queue.Enqueue ((root, 0));

        while (queue.Count > 0) {
            var elem = queue.Dequeue ();
            var node = elem.node;
            var l = elem.level;

            if (node == null) {
                continue;
            }

            List<int> r = new List<int>();
            
            if (node.left != null) 
            {
                if (!dict.ContainsKey(l + 1))
                {
                    dict.Add(l + 1, new List<int>());
                }

                dict[l + 1].Add(node.left.val);
                queue.Enqueue ((node.left, l + 1));
            }

            if (node.right != null) 
            {
                if (!dict.ContainsKey(l + 1))
                {
                    dict.Add(l + 1, new List<int>());
                }

                dict[l + 1].Add(node.right.val);
                queue.Enqueue((node.right, l + 1));
            }
        }

        return dict.Values.ToList();
    }
}