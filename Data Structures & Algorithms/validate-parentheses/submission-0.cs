public class Solution {
    public bool IsValid(string s) {
        var charMap = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
        };

        var storage = new Stack<char>();

        foreach (var character in s) {
            if (charMap.TryGetValue(character, out var closingChar)) {
                storage.Push(closingChar);
            }
            else if (storage.TryPeek(out closingChar) && closingChar == character) {
                storage.Pop();
            }
            else {
                return false;
            }
        }

        return storage.Count == 0;
    }
}
