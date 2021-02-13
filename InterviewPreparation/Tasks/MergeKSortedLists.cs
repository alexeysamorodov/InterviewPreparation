using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparation.Tasks
{
    public class MergeKSortedLists
    {
        public static ListNode CreateLinkedList(IEnumerable<int> collection)
        {
            ListNode head = null;
            var current = head;
            foreach (var item in collection)
            {
                if (head == null)
                {
                    head = current = new ListNode(item);
                }
                else
                {
                    current.next = new ListNode(item);
                    current = current.next;
                }
            }
            return head;
        }

        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }

            public int[] ToArray()
            {
                var result = new List<int>();
                var current = this;
                while (current != null)
                {
                    result.Add(current.val);
                    current = current.next;
                }
                return result.ToArray();
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];
            var head = GetMinNodeAndMovePointer(lists);
            var current = head;
            while (true)
            {
                var min = GetMinNodeAndMovePointer(lists);
                if (min == null)
                    break;
                current.next = min;
                current = min;
            }
            return head;
        }

        public ListNode GetMinNodeAndMovePointer(ListNode[] lists)
        {
            ListNode min = null;
            var minIndex = -1;
            for (var i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null && (min == null || min.val > lists[i].val))
                {
                    min = lists[i];
                    minIndex = i;
                }
            }
            if (minIndex > -1)
            {
                lists[minIndex] = lists[minIndex].next;
            }
            return min;
        }
    }
}
