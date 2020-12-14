using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DataStructures.Test
{
    public class StackTest
    {
        private readonly ITestOutputHelper output;

        public StackTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        [Fact]
        public void Implement_Stack_Using_Array()
        {
            StackArray stack = new StackArray(100, output);
            stack.push(2);
            stack.push(3);

            Assert.Equal(3,stack.pop());
            stack.push(4);
            Assert.Equal(4, stack.pop());
            stack.printStack();
        }

        [Fact]
        public void Implement_Stack_Using_LinkedList()
        {
            var head = new StackNodeSingly<int>(1);

            StackLinkedList<int> stack = new StackLinkedList<int>(head);
            stack.Push(new StackNodeSingly<int>(2));
            stack.Push(new StackNodeSingly<int>(3));
            Assert.Equal(3, stack.Pop());
            stack.Push(new StackNodeSingly<int>(4));
            Assert.Equal(4, stack.Pop());
            output.WriteLine(stack.Draw());
        }

        [Theory]
        [InlineData(new int[] {1,2,3,4})]
        [InlineData(new int[] { 5, 3, 3, 1 })]
        public void Method1_Implement_Queue_Using_Stack_EnQueueIsCostly(int[] arr)
        {
            /*
             * Complexity Analysis:
                Time Complexity:
                Push operation: O(1).
                Same as pop operation in stack.
                Pop operation: O(N).
                In the worst case we have empty whole of stack 1 into stack 2
                Auxiliary Space: O(N).
                Use of stack for storing values.
             */
            var Queue = new StackQueue<int>();
            foreach (var item in arr)
            {
                Queue.EnQueue1(item);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var data = Queue.DeQueue1();
                Assert.Equal(arr[i], data);
                output.WriteLine(data.ToString());
            }
            
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 5, 3, 3, 1 })]
        public void Method2_Implement_Queue_Using_Stack_DeQueueIsCostlyAtFirstTime(int[] arr)
        {
            /* MUCH MORE FASTER!
        *Complexity Analysis:
            Time Complexity:
            Push operation : O(1).
            Same as pop operation in stack.
            Pop operation : O(N).
            The difference from above method1 is that in this method element is returned and all elements are restored back in a single call.
            Auxiliary Space: O(N).
            Use of stack for storing values.
        */
            var Queue = new StackQueue<int>();
            foreach (var item in arr)
            {
                Queue.EnQueue2(item);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                var data = Queue.DeQueue2();
                Assert.Equal(arr[i], data);
                output.WriteLine(data.ToString());
            }

        }

        [Fact]
        public void Null_Stack_Using_LinkedList()
        {
            var head = new StackNodeSingly<int>(1);

            StackLinkedList<int> stack = new StackLinkedList<int>(head);
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Pop());
            stack.Push(new StackNodeSingly<int>(2));
            
            output.WriteLine(stack.Draw());
        }

        [Theory]
        [InlineData(new char[] { '[', '(', ')', ']', '{', '}', '{', '[', '(', ')', '(', ')', ']', '(', ')', '}' }, true)]
        [InlineData(new char[] { '[', '{', '{', ']' }, false)]
        [InlineData(new char[] { '[', '{', '(', ')', '}', ']' }, true)]
        [InlineData(new char[] { '[', '(', ']', ')', '}', ']' }, false)]

        public void Check_Balanced_Brackets(char[] brackers,bool isBalanced)
        {
            StackLinkedList<char> stack = new StackLinkedList<char>();
            var result = true;
            foreach (var item in brackers)
            {
                switch (item)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(new StackNodeSingly<char>(item));
                        break;
                    case '}':
                    case ']':
                    case ')':
                        char bracket = stack.Pop();
                        bool isPair = isPairMatch(bracket, item);
                        if (!isPair)
                        {
                            result = false;
                        }
                        break;
                    default:
                        break;
                }
                if (!result) break;
            }
           
            Assert.Equal(isBalanced, result);
        }

        private bool isPairMatch(char a,char b)
        {

            if( (a == '{' && b == '}') || 
                (a == '[' && b == ']') ||
                (a == '(' && b == ')'))
            {
                return true;
            }
            return false;
        }
    }
}
