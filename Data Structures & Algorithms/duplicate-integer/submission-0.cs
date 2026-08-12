public class Solution {
    public bool hasDuplicate(int[] nums) {
        var uniqueItems = new HashSet<int>();

        foreach (var num in nums) {
            if (!uniqueItems.Add(num)) {
                return true;
            }
        }

        return false;
    }
}