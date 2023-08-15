public class Solution113 {
    private int target = 0;
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) 
    {
        this.target = targetSum;
        List<IList<int>> result = new();
        if (root == null) 
        {
            return result;
        }

        List<int> path = new();
        var stack = new Stack<(TreeNode node, int sum, int index)> ();
        stack.Push((root, root.val, 0));

        while (stack.Count > 0) 
        {
            var p = stack.Pop ();
            var node = p.node;
            var psum = p.sum;
            var index = p.index;

            if (index < path.Count)
            {
                path[index] = node.val;
            } 
            else
            {
                path.Add (node.val);
            }

            if (node.right != null)
            {
                stack.Push((node.right, node.right.val + psum, index+1));
            }

            if (node.left != null)
            {
                stack.Push((node.left, node.left.val + psum, index + 1));
            }

            if (node.left == null && node.right == null && psum == targetSum)
            {
                result.Add(path);
            }
        }

        return result;
    }

    public bool isLeaf(TreeNode node)
    {
        return node.left == null && node.right == null;
    }
}