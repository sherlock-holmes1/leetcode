from typing import Optional
import sys

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    result = True

    def isValidBST(self, root: Optional[TreeNode]) -> bool:
        self.result = True

        self.process(root, -sys.maxsize, sys.maxsize)

        return self.result
    
    def process (self, node:TreeNode, lower, upper):
        if not node:
            return
        
        if self.result == False:
            return
        
        if node.left:
            if lower < node.left.val < node.val:
                self.process(node.left, lower, node.val)
            else:
                self.result = False
                return 
            
        if node.right:
            if node.val < node.right.val < upper:
                self.process(node.right, node.val, upper)
            else:
                self.result = False
                return
            
tr = TreeNode(2, right=TreeNode(1, left=TreeNode(3)))
tr2 = TreeNode(2, left=TreeNode(1), right=TreeNode(3))
tr3 = TreeNode(5, left=TreeNode(1), right=TreeNode(4, left=TreeNode(3), right=TreeNode(6)))
tr4 = TreeNode(2, left=TreeNode(2), right=TreeNode(2))
tr5 = TreeNode(5, left=TreeNode(4), right=TreeNode(6, left=TreeNode(3), right=TreeNode(7)))

r = Solution().isValidBST(tr)
r2 = Solution().isValidBST(tr2)
r4 = Solution().isValidBST(tr4)
r5 = Solution().isValidBST(tr5)

print(r)
print(r2)
print(r4)
print(r5)
