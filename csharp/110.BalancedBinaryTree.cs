public class Solution110 {
    bool isBalanced = true;
    public bool IsBalanced(TreeNode root) {
        int h = Height(root);
//        Console.WriteLine(h);
        return isBalanced;
    }
    public int Height (TreeNode node) 
    {
        if (node == null)
            return 0;
        
        // if (node.left == null && node.right == null)
        // {
        //     return 0;
        // }
        
        int l_height = Height(node.left);
        int r_height = Height(node.right);

        if (Math.Abs(l_height - r_height) >= 2)
            isBalanced = false;

        return Math.Max(r_height, l_height) + 1;
    }
}