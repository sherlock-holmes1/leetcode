# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
        
from typing import List, Optional


class Solution:    
    def postorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        result = []

        self.processNode(root, result)

        return result

    def processNode(self, node:TreeNode, result):
        if not node:
            return
        
        self.processNode(node.left, result)
        self.processNode(node.right, result)
        result.append(node.val)

class Solution2:
    
    def postorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        cur:TreeNode = root
        main = []
        right = []
        result = []


        while len(main) > 0 or cur:
            if cur:
                if cur.right:
                    right.append(cur.right)
                
                main.append(cur)
                cur = cur.left

            else:
                cur = main[-1]

                if len(right) > 0 and cur.right == right[-1]:
                    cur = right.pop()

                else:
                    result.append(cur.val)
                    cur = None
                    main.pop()

        return result


tr = TreeNode(1, right=TreeNode(2, left=TreeNode(3)))
tr1 = TreeNode(1)
r = Solution2().postorderTraversal(tr)

print(r)