/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        var current = head;

        while (current != null) {
            var originalNext = current.next;
            var copy = new Node(current.val);
            copy.next = originalNext;
            current.next = copy;

            current = originalNext;
        }

        current = head;

        while (current != null) {
            if (current.next != null && current.random != null) {
                current.next.random = current.random.next;
            }

            current = current.next?.next;
        }

        var result = new Node(0);
        current = head;
        var currentNew = result;

        while (current != null) {
            currentNew.next = current.next;
            current.next = current.next?.next;

            current = current.next;
            currentNew = currentNew.next;
        }

        return result.next;
    }
}
