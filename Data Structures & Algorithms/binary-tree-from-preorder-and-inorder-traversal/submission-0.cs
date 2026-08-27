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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        var inorderDict = new Dictionary<int, int>(); // value -> index

        for (int i = 0; i < inorder.Length; i++)
        {
            inorderDict.Add(inorder[i], i);
        }

        return Construct(preorder, inorderDict,
            new(0, preorder.Length - 1),
            new(0, inorder.Length - 1));
    }

    private static TreeNode? Construct(int[] preorder,
        Dictionary<int, int> inorder,
        ArrayBounds preBounds,
        ArrayBounds inBounds)
    {
        if (inBounds.Left > inBounds.Right)
        {
            return null;
        }

        var nodeValue = preorder[preBounds.Left];
        var inorderIndex = inorder[nodeValue];

        var leftSubTreeSize = inorderIndex - inBounds.Left;

        var left = Construct(preorder, inorder,
            new(preBounds.Left + 1, preBounds.Left + leftSubTreeSize),
            new(inBounds.Left, inorderIndex - 1));

        var right = Construct(preorder, inorder,
            new(preBounds.Left + leftSubTreeSize + 1, preBounds.Right),
            new(inorderIndex + 1, inBounds.Right));

        return new(nodeValue, left, right);
    }

    private record struct ArrayBounds(int Left, int Right);
}
