using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedListSingly<T>
    {
        /* Summary
         * Is a Linear data structure, mirip seperti array
         * tidak disimpan di memory location yg berdekatan. artinya bisa di simpan dimana saja didalam memory 
         * untuk mengakses tiap elementnya perlu menggunakan pointer.
         * tiap NodeSingly mempunyai data dan pointer(referensi)
         * terbagi menjadi 3 tipe :singly (1 arah),doubly (2 arah),circuly(kayak lingkaran terus muter, ga ada null di akhir) 
         * 
         * keuntungan:
         * sizenya fleksibel/dinamis
         * lebih mudah di insert/delete dari pada array
         * 
         * kekurangan:
         * ga bisa secara random mengakses tiap NodeSinglynya. perlu sequential di cari tiap NodeSingly.
         * membutuhkan extra memory space untuk tiap NodeSingly.
         * not cache friendly. karena lokasi memory yg disimpan secara acak.
         */
        public NodeSingly<T> Head { get; set; }

        public LinkedListSingly(NodeSingly<T> head)
        {
            Head = head;
        }
        public LinkedListSingly()
        {

        }
        public string printList()
        {
            NodeSingly<T> n = Head;
            string result = "";
            while (n != null)
            {
                result+=  n.Data.ToString()+ "->";
                n = n.Next;
            }

            return result;
        }

        public void Push(NodeSingly<T> NodeSingly)
        {
            NodeSingly.Next = this.Head;
            this.Head = NodeSingly;
        }

   

        public void Append(NodeSingly<T> NodeSingly)
        {
            if(Head == null)
            {
                Head = NodeSingly;
                return;
            }

            var temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = NodeSingly;
        }

        public void deleteNodeSingly(int position)
        {

            // If linked list is empty 
            if (Head == null)
                return;

            // Store head NodeSingly 
            NodeSingly<T> temp = Head;

            // If head needs to be removed 
            if (position == 0)
            {

                // Change head 
                Head = temp.Next;
                return;
            }

            // Find previous NodeSingly of the NodeSingly to be deleted 
            for (int i = 0;
                    temp != null && i < position - 1;
                    i++)
                temp = temp.Next;

            // If position is more than number of NodeSinglys 
            if (temp == null || temp.Next == null)
                return;

            // NodeSingly temp->next is the NodeSingly to be deleted 
            // Store pointer to the next of NodeSingly to be deleted 
            NodeSingly<T> next = temp.Next.Next;

            // Unlink the deleted NodeSingly from list 
            temp.Next = next;
        }
    }

    public class NodeSingly<T>
    {
        public T Data { get; set; }
        public NodeSingly<T> Next { get; set; }
        public NodeSingly(T data, NodeSingly<T> next = null)
        {
            Data = data;
            Next = next;
        }
    }
}
