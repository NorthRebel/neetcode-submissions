public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];
        var indexes = new Stack<int>();

        for (var i = temperatures.Length - 1; i >= 0; i--) {
            while (indexes.TryPeek(out var rightIdx) && temperatures[rightIdx] <= temperatures[i]) {
                indexes.Pop();
            }

            if (indexes.TryPeek(out var idx)){
                var diff = idx - i;
                result[i] = diff;
            }
            else {
                result[i] = 0;
            }

            indexes.Push(i);
        }

        return result;
    }
}
