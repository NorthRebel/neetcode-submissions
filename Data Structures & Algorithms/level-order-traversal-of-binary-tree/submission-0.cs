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
    public List<List<int>> LevelOrder(TreeNode root) {
        var result = new List<List<int>>();

        if (root == null) {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var levelSize = queue.Count;
            var levelValues = new List<int>(levelSize);

            for (var _ = 0; _ < levelSize; _++) {
                var currentNode = queue.Dequeue();
                levelValues.Add(currentNode.val);

                if (currentNode.left != null) {
                    queue.Enqueue(currentNode.left);
                }

                if (currentNode.right != null) {
                    queue.Enqueue(currentNode.right);
                }
            }

            result.Add(levelValues);
        }

        return result;
    }
}
