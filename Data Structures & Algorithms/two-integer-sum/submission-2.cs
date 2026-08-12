public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var storage = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++){
            var num = nums[i];
            if (!storage.ContainsKey(num)){
                storage.Add(num, i);
            }
            else {
                storage[num] = i;
            }
        }

        for (var i = 0; i < nums.Length; i++){
            var secondArg = target - nums[i];
            if (storage.TryGetValue(secondArg, out var idx) && idx != i){
                return new int[] { i, idx };
            }
        }

        return Array.Empty<int>();
    }
}
