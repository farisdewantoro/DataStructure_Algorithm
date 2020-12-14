using System;
using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace DataStructures.Test
{
    public class LinkedListTest
    {
        [Fact]
        public void LinkedList_String()
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(CreateHeadNodeSinglyOfInt());
            var p = linkedList.printList();
            Assert.Equal("1->2->3->",p);
        }

        [Fact]
        public void LinkedList_Add_NodeSingly_At_Front()
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(CreateHeadNodeSinglyOfInt());

            linkedList.Push(new NodeSingly<int>(0));
            var p = linkedList.printList();
            Assert.Equal("0->1->2->3->", p);
        }

        [Fact]
        public void LinkedList_Add_NodeSingly_At_End()
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(CreateHeadNodeSinglyOfInt());

            linkedList.Append(new NodeSingly<int>(4));
            var p = linkedList.printList();
            Assert.Equal("1->2->3->4->", p);
        }

        [Fact]
        public void LinkedList_Reverse()
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(CreateHeadNodeSinglyOfInt());
            var current = linkedList.Head;
            NodeSingly<int> previous = null;
            NodeSingly<int> next = null;
          
            /*perlu ubah pointernya
             * 1. set 1 ke null
             * 2. set 2 ke 1
             * 3. set 3 ke 2
             * jadi 3->2->1->null
             * 
             * kuncinya ada di previous set ke current.next
             * tiap reverse di awal di iterasi pertama set current.nextnya jadi null
             * hasil akhir ada di previous sebagai head hasil reverse.
             * swap nya di bagian -> 
             *      1. current.next = previous 
             *      2. previous = next
             *      
             * no  previous    next    current.next    previous_list   current_updated 
             * 0   null        null    2               null            <--init 1           
             * 1   1           2       null            1->             2
             * 2   2           3       1               2->1->          3
             * 3   3           null    2               3->2->1->       null
             */

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            linkedList.Head = previous;
            
           
            var p = linkedList.printList();
            Assert.Equal("3->2->1->", p);
            
        }

        

        [Theory]
        [MemberData(nameof(TestInsertAtPosition))]
        public void LinkedList_Insert_At_Position(int position, NodeSingly<int> head, NodeSingly<int> new_data, string result)
        {
            //insert di 3
            //1->2->3->
            //1->2->6->3->

            if (position < 1) return;

            var tempHead = head;
            while (position-- != 0)
            {
                if (position == 1)
                {
                    new_data.Next = tempHead.Next;
                    tempHead.Next = new_data;
                }
                tempHead = tempHead.Next;
            }

            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(head);
            var p = linkedList.printList();
            Assert.Equal(result, p);
        }
        [Theory]
        [InlineData(new int[] {-3,-2,-1,0,1,2,3},0)]
        [InlineData(new int[] {-1, 0, 1, 2, 3 }, 1)]
        public void LinkedList_GetValue_At_MiddlePosition(int[] arr,int result)
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(new NodeSingly<int>(arr[0]));
            for (int i = 1; i < arr.Length; i++)
            {
                linkedList.Append(new NodeSingly<int>(arr[i]));
            }
            //-3,-2,-1,0,1,2,3;
            //return 1;
            var head = linkedList.Head;
            //
            NodeSingly<int> pointer1 = head;
            NodeSingly<int> pointer2 = head;
            while (pointer2 != null && pointer2.Next != null)
            {
                pointer1 = pointer1.Next;
                pointer2 = pointer2.Next.Next;
            }

            Assert.Equal(result, pointer1.Data);
        }
        [Theory]
        [MemberData(nameof(TestGetValueAtPosition))]
        public void LinkedList_GetValue_At_Position(int position, NodeSingly<int> head,  int result)
        {
            if (position == 0)
            {
                Assert.Equal(result, head.Data);
                return;
            }

            if(position < 0)
            {
                return;
            }

            var tempHead = head;
            while (position-- > 0)
            {
                tempHead = tempHead.Next;
            }

            Assert.Equal(result, tempHead.Data);
        }
        [Theory]
        [MemberData(nameof(TestDeleteAtGivenKey))]
        public void LinkedList_Delete_At_Given_Key(int key, NodeSingly<int> head, string result)
        {
            var tempHead = head;
            NodeSingly<int> previous = null;
            while (tempHead != null)
            {
                if (tempHead.Data == key)
                {
                    var next = tempHead.Next;
                    if(previous == null)
                    {
                        head = tempHead.Next;
                    }
                    else
                    {
                        previous.Next = next;
                    }
                  
                    break;
                }
                previous = tempHead;
                tempHead = tempHead.Next;
            }
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(head);
            var p = linkedList.printList();
            Assert.Equal(result, p);
        }
        [Theory]
        [MemberData(nameof(TestDeleteAtPosition))]
        public void LinkedList_Delete_At_Position(int position, NodeSingly<int> head,string result)
        {


            if (position == 0)
            {
                head = head.Next;
                LinkedListSingly<int> ll = new LinkedListSingly<int>(head);
                var res = ll.printList();
                Assert.Equal(result, res);
                return;
            }

            var tempHead = head;
            while (position-- > 1)
            {
                tempHead = tempHead.Next;
            }

            if (tempHead == null || tempHead.Next == null)
            {
                return;
            }

            var next = tempHead.Next.Next;
            tempHead.Next = next;
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(head);
            //linkedList.deleteNodeSingly(position);
            var p = linkedList.printList();
            Assert.Equal(result, p);
        }
        public static IEnumerable<object[]> TestInsertAtPosition =>
         new List<object[]>
         {
            new object[] { 3,CreateHeadNodeSinglyOfInt(),new NodeSingly<int>(6),"1->2->6->3->" },
            new object[] { 2,CreateHeadNodeSinglyOfInt(),new NodeSingly<int>(6),"1->6->2->3->" },
            new object[] { 1,CreateHeadNodeSinglyOfInt(),new NodeSingly<int>(6),"1->2->3->" },


         };
        public static IEnumerable<object[]> TestGetValueAtPosition =>
        new List<object[]>
        {
                new object[] { 2,CreateHeadNodeSinglyOfInt(),3 },
                new object[] { 1,CreateHeadNodeSinglyOfInt(),2 },
                new object[] { 0,CreateHeadNodeSinglyOfInt(),1},
                new object[] { -1,CreateHeadNodeSinglyOfInt(),null},
        };
        public static IEnumerable<object[]> TestDeleteAtPosition =>
        new List<object[]>
        {
                new object[] { 2,CreateHeadNodeSinglyOfInt(),"1->2->" },
                new object[] { 1,CreateHeadNodeSinglyOfInt(),"1->3->" },
                new object[] { 0,CreateHeadNodeSinglyOfInt(),"2->3->" },
                new object[] { 3, PushToLinkedList(new NodeSingly<int>(0)).Head,"0->1->2->" },

        }; 

      
        public static IEnumerable<object[]> TestDeleteAtGivenKey =>
       new List<object[]>
       {
                new object[] { 2,CreateHeadNodeSinglyOfInt(),"1->3->" },
                new object[] { 1,CreateHeadNodeSinglyOfInt(),"2->3->" },
                new object[] { 3, PushToLinkedList(new NodeSingly<int>(0)).Head,"0->1->2->" },

       };
        public static NodeSingly<int> CreateHeadNodeSinglyOfInt()
        {
            return CreateLinkedList().Head;
        }
        public static LinkedListSingly<int> CreateLinkedList()
        {
            LinkedListSingly<int> linkedList = new LinkedListSingly<int>(new NodeSingly<int>(1));
            NodeSingly<int> second = new NodeSingly<int>(2);
            NodeSingly<int> third = new NodeSingly<int>(3);
            linkedList.Head.Next = second;
            second.Next = third;
            return linkedList;
        }

        public static LinkedListSingly<int> PushToLinkedList(NodeSingly<int> number)
        {
            var linkedList = CreateLinkedList();
            linkedList.Push(number);
            return linkedList;
        }
    }
}
