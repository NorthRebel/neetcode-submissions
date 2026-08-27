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
    public int GoodNodes(TreeNode root) =>
        GetGoodNodesCount(root, root.val);

    private static int GetGoodNodesCount(TreeNode node, int maxNodeValue) {
        if (node == null) {
            return 0;
        }

        var isGood = node.val >= maxNodeValue ? 1 : 0;
        maxNodeValue = Math.Max(maxNodeValue, node.val);

        var leftNodesCount = GetGoodNodesCount(node.left, maxNodeValue);
        var rightNodesCount = GetGoodNodesCount(node.right, maxNodeValue);

        return isGood + leftNodesCount + rightNodesCount;
    }
}
