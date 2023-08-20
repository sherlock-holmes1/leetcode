# Definition for a binary tree node.
from typing import List, Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:

    def inorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        result = []
        stack = []
        cur = root
        while len(stack) > 0 or cur:
            if cur:
                stack.append(cur)
                cur = cur.left

            else:
                cur = stack.pop()
                result.append(cur.val)
                cur = cur.right

        return result
    

class Solution2:
    stack = []
    result = []

    def inorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        self.append(root)

        return self.result
    
    def append(self, node:TreeNode):
        if not node:
            return
        
        self.append(node.left)
        self.result.append(node.val)
        self.append(node.right)
    
tr = TreeNode(1, right=TreeNode(2, left=TreeNode(3)))
r = Solution2().inorderTraversal(tr)

print(r)