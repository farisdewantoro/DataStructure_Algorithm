using System;
using System.Text;

namespace DataStructures
{
    public class QueueLinkedList<T>
    {
        public NodeSingly<T> Rear { get; set; }
        public NodeSingly<T> Front { get; set; }

        public QueueLinkedList()
        {
            
        }
        public void EnQueue(T data)
        {
            var newData = new NodeSingly<T>(data);
            if(Front == null && Rear == null)
            {
                Front = newData;
                Rear = newData;
                return;
            }
         
            Rear.Next = newData;
            Rear = newData;
        }

        public T DeQueue()
        {
            var temp = Front;
            Front = Front.Next;
            if (this.Front == null)
                this.Rear = null;
            return temp.Data;
        }
    }
}
