public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var left = 1;
        var right = FindMax(piles);

        while (left < right)
        {
            var middle = left + (right - left) / 2; // Middle means K

            if (CanEatAll(piles, h, middle))
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    private static int FindMax(int[] piles)
    {
        var maxValue = 0;

        foreach (var item in piles)
        {
            if (item > maxValue)
            {
                maxValue = item;
            }
        }

        return maxValue;
    }

    private static bool CanEatAll(int[] piles, int totalHours, int k)
    {
        var requiredHours = 0L;

        for (int i = 0; i < piles.Length; i++)
        {
            var hoursPerPile = (piles[i] + k - 1) / k;
            requiredHours += hoursPerPile;

            if (requiredHours > totalHours)
            {
                return false;
            }
        }

        return true;
    }
}
