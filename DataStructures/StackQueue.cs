using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class StackQueue<T>
    {
        public StackLinkedList<T> Stack1 { get; set; }
        public StackLinkedList<T> Stack2 { get; set; }
        
        public void EnQueue1(T data)
        {
            if(Stack1 == null)
            {
                Stack1 = new StackLinkedList<T>();
            }

            if(Stack2 == null)
            {
                Stack2 = new StackLinkedList<T>();
            }
            var newData = new StackNodeSingly<T>(data);
           
            while (Stack1.HeadStackNodeSingly != null)
            {
                Stack2.Push(new StackNodeSingly<T>(Stack1.Pop()));
            }
            Stack1.Push(newData);
            while (Stack2.HeadStackNodeSingly != null)
            {
                Stack1.Push(new StackNodeSingly<T>(Stack2.Pop()));
            }
        }

        public T DeQueue1()
        {
            if(Stack1 == null || Stack1.HeadStackNodeSingly == null)
            {
                return default(T);
            }
            return Stack1.Pop();
        }

        public void EnQueue2(T data)
        {
            if (Stack1 == null)
            {
                Stack1 = new StackLinkedList<T>();
            }
            Stack1.Push(new StackNodeSingly<T>(data));
        }

        public T DeQueue2()
        {
            if(Stack2 == null)
            {
                Stack2 = new StackLinkedList<T>();
            }
          
            while (Stack1.HeadStackNodeSingly != null)
            {
                Stack2.Push(new StackNodeSingly<T>(Stack1.Pop()));

            }

            return Stack2.Pop();
        }
    }
}
