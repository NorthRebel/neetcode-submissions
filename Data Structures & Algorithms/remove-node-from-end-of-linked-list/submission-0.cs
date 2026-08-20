/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0, head);
        var first = dummy;
        var second = dummy;

        for (var i = 0; i <= n; i++) {
            first = first?.next;
        }

        while (first != null) {
            first = first.next;
            second = second?.next;
        }

        var nodeToRemove = second.next;
        second.next = nodeToRemove.next;

        return dummy.next;
    }
}
