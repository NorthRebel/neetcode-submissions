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
    public void ReorderList(ListNode head) {
        if (head.next == null) {
            return;
        }

        var middleNode = GetMiddleNode(head);
        var secondListPart = ReverseList(middleNode.next);
        middleNode.next = null;

        var firstPartHead = head;
        var secondPartHead = secondListPart;

        while (secondPartHead != null)
        {
            var tempFirst = firstPartHead.next;
            var tempSecond = secondPartHead.next;

            firstPartHead.next = secondPartHead;
            secondPartHead.next = tempFirst;

            firstPartHead = tempFirst;
            secondPartHead = tempSecond;
        }
    }

    private static ListNode GetMiddleNode(ListNode head) {
        var slow = head;
        var fast = head;

        while (fast?.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private static ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        var current = head;

        while (current != null) {
            var temp = current;
            current = current.next;
            temp.next = prev;
            prev = temp;
        }

        return prev;
    }
}
