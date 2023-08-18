public class Solution {
    int depth = int.MaxValue;
    public int MinDepth(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        Queue<(TreeNode node, int dist)> queue = new ();
        queue.Enqueue((root, 1));
        while (queue.Count > 0) {
            var elem = queue.Dequeue ();
            var node = elem.node;
            var dist = elem.dist;

            if (node.right == null && node.left == null) 
            {
                if (dist < depth)
                {
                    depth = dist;
                }
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, dist + 1));
            }

            if (node.left != null)
            {
                queue.Enqueue((node.left, dist + 1));
            }
        }  

        return depth;
    }
}