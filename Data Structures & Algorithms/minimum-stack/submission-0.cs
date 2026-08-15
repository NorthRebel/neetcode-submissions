public class MinStack {
    private readonly Stack<int> _mainStack;
    private readonly Stack<int> _extraStack;

    public MinStack() {
        _mainStack = new();
        _extraStack = new();
    }
    
    public void Push(int val) {
        if (_extraStack.Count == 0 || _extraStack.TryPeek(out var min) && min >= val) {
            _extraStack.Push(val);
        }

        _mainStack.Push(val);
    }
    
    public void Pop() {
        if (_mainStack.Count == 0) {
            return;
        }

        var value = _mainStack.Pop();

        if (_extraStack.TryPeek(out var min) && min == value) {
            _extraStack.Pop();
        }
    }
    
    public int Top() {
        return _mainStack.Count > 0 ? _mainStack.Peek() : 0;
    }
    
    public int GetMin() {

        return _extraStack.Count > 0 ? _extraStack.Peek() : 0;
    }
}
