public class Solution {
    public int FindDuplicate(int[] nums) {
        var slow = nums[0];
        var fast = nums[slow];

        while (slow != fast) {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }

        slow = 0;

        while (slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}
