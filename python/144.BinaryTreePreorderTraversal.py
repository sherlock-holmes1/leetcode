from typing import List, Optional
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def preorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        result = []
        self.process(root, result)

        return result
    
    def process(self, node:TreeNode, result):
        if not node:
            return
        
        result.append(node.val)
        self.process(node.left, result)
        self.process(node.right, result)

class Solution2:
    def preorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        stack = [root]
        result = []

        while len(stack) > 0:
            el = stack.pop()
            if el:
                result.append(el.val)
                stack.append(el.left)
                stack.append(el.right)

        return result


tr = TreeNode(1, right=TreeNode(2, left=TreeNode(3)))
tr1 = TreeNode(1)
r = Solution2().preorderTraversal(tr)

print(r)