/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public List<int> RightSideView(TreeNode root) {
        var result = new List<int>();

        if (root == null) {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var currentTreeLevelSize = queue.Count;
            var topRightNodeValue = 0;

            for (var _ = 0; _ < currentTreeLevelSize; _++) {
                var node = queue.Dequeue();
                topRightNodeValue = node.val;

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(topRightNodeValue);
        }

        return result;
    }
}
