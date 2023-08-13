public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return Symmetric(root.right, root.left);
    }
    public bool Symmetric(TreeNode left, TreeNode right) 
    {
        if (left == right)
            return true;

        if (left == null || right == null)
            return false;

        if (left.val != right.val) 
            return false;

        return left.val == right.val && Symmetric(left.right, right.left) && Symmetric(right.right, left.left);
    }
}

// public class Solution {
//     bool isSymmetric = true;
//     public bool Symmetric(TreeNode right, TreeNode left)
//     {
//         if (right?.val != left?.val)
//         {
//             isSymmetric = false;
//             return isSymmetric;
//         }
//         if (right == null || left == null)
//         {
//             return isSymmetric;
//         }
//         Symmetric(right.right,left.left);
//         Symmetric(right.left, left.right);

//         return isSymmetric;
//     }
//     public bool IsSymmetric(TreeNode root)
//     {
//         return Symmetric(root.right,root.left);
//     }
// }