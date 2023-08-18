public class Solution {
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if (root == null)
        {
            return false;
        }

        var q = new Queue<(TreeNode node, int sum)>();
        q.Enqueue((root, root.val));

        while (q.Count > 0)
        {
            var el = q.Dequeue();
            var node = el.node;
            var sum = el.sum;

            if (sum == targetSum && node.right == null && node.left == null)
            {
                return true;
            }

            if (node.right != null)
            {
                q.Enqueue((node.right, sum + node.right.val));
            }

            if (node.left != null)
            {
                q.Enqueue((node.left, sum + node.left.val));
            }
        }

        return false;
    }
}