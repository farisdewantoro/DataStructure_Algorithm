using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace DataStructures
{
    public class StackArray
    {
        /*Summary
         * is Linear data structure
         * urutannya bisa  LIFO(Last In First Out) atau FILO(First In Last Out).
         * sizenya udah fixed
         */
        private int[] ele;
        private int top;
        private int max;
        private readonly ITestOutputHelper testOutputHelper;

        public StackArray(int size, ITestOutputHelper testOutputHelper)
        {
            ele = new int[size]; // Maximum size of Stack
            top = -1;
            max = size;
            this.testOutputHelper = testOutputHelper;
        }

        public void push(int item)
        {
            if (top == max - 1)
            {
                testOutputHelper.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                ele[++top] = item;
            }
        }

        public int pop()
        {
            if (top == -1)
            {
                testOutputHelper.WriteLine("Stack is Empty");
                return -1;
            }
            else
            {
                testOutputHelper.WriteLine("{0} popped from stack ", ele[top]);
                return ele[top--];
            }
        }

        public int peek()
        {
            if (top == -1)
            {
                testOutputHelper.WriteLine("Stack is Empty");
                return -1;
            }
            else
            {
                testOutputHelper.WriteLine("{0} popped from stack ", ele[top]);
                return ele[top];
            }
        }

        public void printStack()
        {
            if (top == -1)
            {
                testOutputHelper.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    testOutputHelper.WriteLine("{0} pushed into stack", ele[i]);
                }
            }
        }
    }
}
