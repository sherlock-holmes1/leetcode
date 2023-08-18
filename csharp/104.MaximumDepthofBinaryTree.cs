public class Solution {
    int depth = 0;
    public int MaxDepth(TreeNode root) 
    {
        if (root == null)
        {
            return depth;
        }

        var queue = new List<(TreeNode node, int dist)>
        {
            (root, 1)
        };
        
        while (queue.Count > 0)
        {
            var elem = queue[0];
            queue.RemoveAt(0);

            var dist = elem.dist;
            var node = elem.node;

            if (node.left == null && node.right == null)
            {
                if (depth < dist)
                {
                    depth = dist;
                }
            }
            
            if (node.left != null)
            {   
                queue.Add((node.left, dist + 1));
            }
            
            if (node.right != null)
            {
                queue.Add((node.right, dist + 1));
            }            
        }

        return depth;
    }
}