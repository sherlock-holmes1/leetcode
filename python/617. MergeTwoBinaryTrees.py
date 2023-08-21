from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def mergeTrees(self, root1: Optional[TreeNode], root2: Optional[TreeNode]) -> Optional[TreeNode]:
        if root1 is None:
            return root2
        
        if root2 is None:
            return root1
        
        self.process(root1, root2)

        return root1
    
    def process(self, node1: TreeNode, node2: TreeNode):
        if not node1 and not node2:
            return

        if node1.left or node2.left:
            if node1.left is None:
                node1.left = TreeNode()
            if node2.left is None:
                node2.left = TreeNode()
            self.process(node1.left, node2.left)

        if node1 and node2:
            node1.val += node2.val

        if node1.right or node2.right:
            if node1.right is None:
                node1.right = TreeNode()
            if node2.right is None:
                node2.right = TreeNode()
            self.process(node1.right, node2.right)


#root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
root1 = TreeNode(1, left=TreeNode(3, left=TreeNode(5)), right=TreeNode(2))
root2 = TreeNode(2, left=TreeNode(1, right=TreeNode(4)), right=TreeNode(3, right=TreeNode(7)))

r = Solution().mergeTrees(root1, root2)

#Output: [3,4,5,5,4,null,7]
print(r)