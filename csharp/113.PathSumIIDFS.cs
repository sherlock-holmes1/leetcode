public class Solution {
    private int target = 0;
    public bool PathSum(TreeNode root, int targetSum) 
    {
        this.target = targetSum;
        List<IList<int>> result = new();
        if (root == null) 
        {
            return false;
        }

        var stack = new Stack<(TreeNode node, int sum)> ();
        stack.Push((root, root.val));

        while (stack.Count > 0) 
        {
            var p = stack.Pop ();
            var node = p.node;
            var psum = p.sum;


            if (node.right != null)
            {
                stack.Push((node.right, node.right.val + psum));
            }

            if (node.left != null)
            {
                stack.Push((node.left, node.left.val + psum));
            }

            if (node.left == null && node.right == null && psum == targetSum)
            {
                return true;
            }
        }
        
        return false;
    }

    public bool isLeaf(TreeNode node)
    {
        return node.left == null && node.right == null;
    }
}