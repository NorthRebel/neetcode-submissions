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
    public int KthSmallest(TreeNode root, int k) {
        var count = 0;
        var result = 0;

        Traverse(root, k, ref count, ref result);

        return result;
    }

    private static void Traverse(TreeNode node, int k, ref int count, ref int result) {
        if (node == null || count == k) {
            return;
        }

        Traverse(node.left, k, ref count, ref result);

        if (++count == k) {
            result = node.val;
            return;
        }

        Traverse(node.right, k, ref count, ref result);
    }
}
