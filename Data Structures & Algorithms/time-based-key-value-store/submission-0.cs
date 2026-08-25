public class TimeMap {
    private readonly Dictionary<string, List<TimeBasedEntry>> _storage;

    public TimeMap() {
        _storage = new();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!_storage.ContainsKey(key)) {
            _storage[key] = new();
        }

        _storage[key].Add(new(timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        if (!_storage.TryGetValue(key, out var list)) {
            return string.Empty;
        }

        var left = 0;
        var right = list.Count - 1;
        var resultIdx = -1;

        while (left <= right) {
            var mid = left + (right - left) / 2;

            if (list[mid].Timestamp <= timestamp) {
                resultIdx = mid;
                left = mid + 1;
            }
            else {
                right = mid - 1;
            }
        }

        return resultIdx > -1 ? list[resultIdx].Value : string.Empty;
    }

    private record TimeBasedEntry(int Timestamp, string Value);
}
