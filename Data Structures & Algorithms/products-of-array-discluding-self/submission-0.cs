public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var prefixResults = new int[nums.Length];
        var leftProduct = 1;

        for (var i = 0; i < nums.Length; i++) {
            prefixResults[i] = leftProduct;
            leftProduct *= nums[i];
        }

        var rightProduct = 1;

        for (var i = nums.Length - 1; i >= 0; i--) {
            prefixResults[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return prefixResults;
    }
}
