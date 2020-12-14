using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class StackLinkedList<T>
    {
        /*
         *Summary
         *Sizenya dinamis, bisa menyesuaikan kebutuhan 
         *butuh extra memory buat menyimpan pointer 
         */
        public StackNodeSingly<T> HeadStackNodeSingly { get; set; }
        public StackLinkedList(StackNodeSingly<T> stack = null)
        {
            HeadStackNodeSingly = stack;
        }
        public void Push(StackNodeSingly<T> NodeSingly)
        {
            NodeSingly.Next = HeadStackNodeSingly;
            HeadStackNodeSingly = NodeSingly;
        }

        public T Pop()
        {
            if(HeadStackNodeSingly == null)
            {
                return default(T);
            }
            var result = HeadStackNodeSingly.Data;
            var previous =  HeadStackNodeSingly.Next;
            HeadStackNodeSingly = previous;
            return result;
        }

        public string Draw()
        {
            string draw = "";
            while (HeadStackNodeSingly != null)
            {
                draw += HeadStackNodeSingly.Data + "->";
                HeadStackNodeSingly = HeadStackNodeSingly.Next;
            }

            return draw;
        }
    }

    public class StackNodeSingly<T>
    {
        public T Data { get; set; }
        public StackNodeSingly<T> Next { get; set; }
        public StackNodeSingly(T data)
        {
            Data = data;
        }

      
    }
}
