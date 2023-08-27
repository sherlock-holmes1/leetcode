public class Solution103 {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return result;

        var levels = new Dictionary<int, List<int>>();
        var queue = new List<(TreeNode node, int level)>
        {
            (root, 0)
        };
        
        while (queue.Count > 0) {
            var elem = queue[0];
            queue.RemoveAt(0);
            var node = elem.node;
            var lvl = elem.level;

            if (!levels.ContainsKey(lvl)) 
                levels[lvl] = new List<int>(); 
                
            levels[lvl].Add(node.val);

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
            if (level % 2 == 0)
            {
                result.Add(levels[level]);
            }
            else
            {
                levels[level].Reverse();
                result.Add(levels[level]);
            }
        }

        return result;
    }
}