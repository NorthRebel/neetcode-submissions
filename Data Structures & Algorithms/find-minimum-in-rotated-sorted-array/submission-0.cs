public class Solution {
    public int FindMin(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right) {
            var mid = left + (right - left) / 2;
            var current = nums[mid];
            var pivot = nums[right];

            if (current > pivot) {
                left = mid + 1;
            }
            else if (current < pivot) {
                right = mid;
            }
            else {
                right--;
            }
        }

        return nums[left];
    }
}
