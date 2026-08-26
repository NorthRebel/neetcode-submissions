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
    private int _diameter;

    public int DiameterOfBinaryTree(TreeNode root) {
        Dfs(root);

        return _diameter;
    }

    private int Dfs(TreeNode node) {
        if (node == null) {
            return 0;
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        _diameter = Math.Max(_diameter, left + right);

        return Math.Max(left, right) + 1;
    }
}
