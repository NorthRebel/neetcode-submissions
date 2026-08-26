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
    private const int FalseResult = -1;

    public bool IsBalanced(TreeNode root) {
        return CheckHeight(root) != FalseResult;
    }

    private static int CheckHeight(TreeNode node) {
        if (node == null) {
            return 0;
        }

        var left = CheckHeight(node.left);

        if (left == FalseResult) {
            return FalseResult;
        }

        var right = CheckHeight(node.right);

        if (right == FalseResult) {
            return FalseResult;
        }

        if (Math.Abs(left - right) > 1) {
            return FalseResult;
        }

        return Math.Max(left, right) + 1;
    }
}
