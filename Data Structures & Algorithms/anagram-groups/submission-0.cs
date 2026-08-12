public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var storage = new Dictionary<string, List<string>>();

        foreach (var str in strs){
            var alphabet = new int[26];

            for (var i = 0; i < str.Length; i++){
                alphabet[str[i] - 'a']++;
            }

            var strHash = string.Join('#', alphabet);

            if (!storage.ContainsKey(strHash)){
                storage.Add(strHash, new List<string>() { str });
            }
            else{
                storage[strHash].Add(str);
            }
        }

        var result = new List<List<string>>();

        foreach (var innerList in storage.Values){
            result.Add(innerList);
        }

        return result;
    }
}
