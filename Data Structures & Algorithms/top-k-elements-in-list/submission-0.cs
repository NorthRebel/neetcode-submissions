public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var frequences = new Dictionary<int, int>();
        var buckets = new List<int>[nums.Length + 1];

        foreach (var num in nums){
            if (frequences.ContainsKey(num)){
                frequences[num]++;
            }
            else {
                frequences.Add(num, 1);
            }
        }

        foreach (var kvp in frequences){
            buckets[kvp.Value] ??= new();
            buckets[kvp.Value].Add(kvp.Key);
        }

        var result = new int[k];

        for (int i = buckets.Length - 1, j = 0; i >= 0 && j < k; i--){
            var bucket = buckets[i];

            if (bucket == null){
                continue;
            }

            foreach (var item in bucket){
                if (j == k){
                    break;
                }

                result[j] = item;
                j++;
            }
        }

        return result;
    }
}
