public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        var chars = new Dictionary<char, int>();

        foreach (var i in s) {
            if (!chars.ContainsKey(i)){
                chars.Add(i, 1);
            }
            else {
                chars[i]++;
            }
        }

        foreach (var i in t) {
            if (!chars.TryGetValue(i, out var count) || count == 0) {
                return false;
            }

            chars[i]--;
        }

        return true;
    }
}
