public class Solution {
    private const char Delimiter = '~';
    private const string EmptyString = "`";

    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();

        var enumerator = strs.GetEnumerator();

        while (enumerator.MoveNext()){
            if (string.IsNullOrEmpty(enumerator.Current)){
                sb.Append(EmptyString);
            }
            else{
                sb.Append(enumerator.Current);
            }

            sb.Append($"{Delimiter}");
        }

        return sb.ToString();
    }

    public List<string> Decode(string s) {
        var result = new List<string>();

        if (string.IsNullOrEmpty(s)){
            return result;
        }

        var strSpan = s.AsSpan();
        var begin = 0;

        for (var end = 0; end < strSpan.Length; end++){
            if (strSpan[end] != Delimiter){
                continue;
            }

            var length = end - begin;
            var decodedStr = strSpan.Slice(begin, length).ToString();

            if (decodedStr == EmptyString){
                decodedStr = string.Empty;
            }

            result.Add(decodedStr);

            end++;
            begin = end;
        }

        return result;
   }
}
