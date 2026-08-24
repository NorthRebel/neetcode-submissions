public class LRUCache {
    private readonly int _capacity;
    private readonly Dictionary<int, ListNode> _storage;
    private readonly ListNode _tail;
    private readonly ListNode _head;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _storage = new(capacity);

        _tail = new(0, 0);
        _head = new(0, 0);

        _head.Next = _tail;
        _tail.Prev = _head;
    }
    
    public int Get(int key) {
        if (_storage.TryGetValue(key, out var node))
        {
            Promote(node);

            return node.Value;
        }

        return -1;
    }
    
    public void Put(int key, int value) {
        if (_storage.TryGetValue(key, out var node))
        {
            node.Value = value;
        }
        else
        {
            if (_storage.Count == _capacity)
            {
                if (_storage.ContainsKey(_tail.Prev!.Key))
                {
                    _storage.Remove(_tail.Prev.Key);
                    Detach(_tail.Prev);
                }
            }

            node = new(key, value);
            _storage.Add(node.Key, node);
        }

        Promote(node);
    }

    private void Promote(ListNode node) {
        if (node.Prev != null)
        {
            Detach(node);
        }

        node.Next = _head.Next;
        node.Prev = _head;

        node.Next.Prev = node;
        node.Prev.Next = node;
    }

    private static void Detach(ListNode node) {
        var prev = node.Prev;
        var next = node.Next;

        prev.Next = next;
        next.Prev = prev;
    }

    private class ListNode {
        public int Key;
        public int Value;
        public ListNode Next;
        public ListNode Prev;

        public ListNode(int key, int value) {
            Key = key;
            Value = value;
        }
    }
}
