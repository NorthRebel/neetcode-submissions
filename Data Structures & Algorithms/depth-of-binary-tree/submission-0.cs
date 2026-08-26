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
    public int MaxDepth(TreeNode node) {
        if (node == null) {
            return 0;
        }

        var left = MaxDepth(node.left);
        var right = MaxDepth(node.right);

        return Math.Max(left, right) + 1;
    }
}
