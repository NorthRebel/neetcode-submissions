public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        ProcessQuckSort(nums, 0, nums.Length - 1);

        var pivot = 0;
        var result = new List<List<int>>();

        while (pivot < nums.Length - 1) {
            var left = pivot + 1;
            var right = nums.Length - 1;

            var target = -nums[pivot];

            while (left < right) {
                var sum = nums[left] + nums[right];

                if (sum > target) {
                    right--;
                    continue;
                }

                if (sum < target) {
                    left++;
                    continue;
                }

                result.Add(new() { nums[pivot], nums[left], nums[right] });
                left++;
                right--;

                while (left < right && nums[left] == nums[left - 1]) {
                    left++;
                }

                while (left < right && nums[right] == nums[right + 1]) {
                    right--;
                }
            }

            while (pivot + 1 < nums.Length && nums[pivot] == nums[pivot + 1]) {
                pivot++;
            }

            pivot++;
        }

        return result;
    }

    private static void ProcessQuckSort(int[] array, int left, int right) {
        if (left >= right) {
            return;
        }

        var (begin, end) = ProcessPartition(array, left, right);

        ProcessQuckSort(array, left, end);
        ProcessQuckSort(array, begin, right);
    }

    private static (int, int) ProcessPartition(int[] array, int left, int right) {
        var pivotIdx = left + (right - left) / 2;
        var pivot = array[pivotIdx];

        while (left <= right) {
            while (array[left] < pivot) {
                left++;
            }

            while (array[right] > pivot) {
                right--;
            }

            if (left <= right) {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }

        return (left, right);
    }
}
