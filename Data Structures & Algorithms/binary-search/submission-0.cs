public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0, right = nums.Length;

        while (right - left > 1) {
            var middle = left + (right - left) / 2;

            if (nums[middle] <= target) {
                left = middle;
            }
            else {
                right = middle;
            }
        }

        return nums[left] == target ? left : -1;
    }
}
