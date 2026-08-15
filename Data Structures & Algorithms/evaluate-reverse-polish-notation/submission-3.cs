public class Solution {
    public int EvalRPN(string[] tokens) {
        var storage = new Stack<int>();

        foreach (var token in tokens) {
            if (int.TryParse(token, out var number)) {
                storage.Push(number);
                continue;
            }

            var right = storage.Pop();
            var left = storage.Pop();
            var result = Evaluate(token[0], left, right);

            storage.Push(result);
        }

        return storage.Pop();
    }

    private static int Evaluate(char rawOperator, int leftOperand, int rightOperand) =>
        rawOperator switch
        {
            '+' => leftOperand + rightOperand,
            '-' => leftOperand - rightOperand,
            '*' => leftOperand * rightOperand,
            '/' => (int)(leftOperand / rightOperand)
        };
}
