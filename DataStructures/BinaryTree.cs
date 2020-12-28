using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace DataStructures
{
    public class BinaryTree<T>
    {
        /* Summary
         * Binnary tree berbeda dengan array,stack,queue dan linkedlist, binarytree is a hierarchical data structures.
         * bagian paling atas di sebut root, element dibawahnya di sebut child, dan di atasnya di sebut parent. element yg tidak punya child di sebut leaves
         * dihubungkan dengan menggunakan Pointer -> left & right
         * contoh : folder-folder di dalam komputer
         * file system
            -----------
                 /    <-- root
              /      \
            ...       home
                  /          \
               ugrad        course
                /       /      |     \
              ...      cs101  cs112  cs113  
            
         *tipe binary tree:
         *  Full binary tree -> tiap node harus punya 0 atau 2 children
         *  Correct            Incorrect
         *       10                10
         *    5     12          5      12
         *  4  6              4  <- only have 1 children should have 0 or 2 children
         *      
         *  Complete binary tree -> semua level harus ter isi kecuali di leaf atau level terakhir, contohnya Heap 
         *  Correct            Incorrect
         *       10                10
         *    5     12          5      12
         *  4  6   11          4  6          <- ga boleh kosong dilevel ini
         *                    7   11         
         *  Perfect binary tree -> tiap node harus punya 2 children, semua leaves harus di level yg sama
         *  Correct            Incorrect
         *       10                10
         *    5     12          5      12
         *  4  6   11  13     4  6          <- ga boleh kosong dilevel ini
         *  Balanced Binary Tree -> height dari left dan right subtree di tiap node tidak lebih besar dari 1
         *  df = |height of left child - height of right child|
         *  Correct                             Incorrect 
         *             1(df=1)                          1(df=2)
         *     (df=0)2         3(df=0)          (df=1)2           3(df=0)
         *  (df=0)4  (df=0)5                 (df=0)4   (df=1)5
         *                                           (df=0)6  
         *                                        
         *  Degenerate Tree -> tiap node hanya punya 1 child
         *      1
         *    2
         *      3
         *        4 
         * Traversing :
         *     
         *       10
         *    5     12
         *  4  6  11  13
         *  
         *  Depth First Search Traversals:
         *      Preorder (Root, Left, Right) 10->5->4->6->12->11->13
         *      Inorder (Left, Root, Right)  4->5->6->10->11->12->13
         *      Postorder (Left, Right, Root) 4->6->5->11->13->12->10 
         *  Breadth First Search Traversals
         */
        public Node<T> Root { get; set; }

        public BinaryTree()
        {

        }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }


        
        public void Insert(Node<T> node)
        {
            Insert(Root,node);
        }

        public void Insert(Node<T> root,Node<T> newData)
        {
            if(root == null)
            {
                return;
            }

            Insert(root.Left, newData);
            Insert(root.Right, newData);
            if(root.Left == null && root.Right != null)
            {
                root.Left = newData;
            }

            if(root.Right == null && root.Left != null)
            {
                root.Right = newData;
            }
        }

        /*function to insert element in binary tree */
        public void InsertBFS_Using_Queue(int key)
        {
            Queue<Node<T>> q = new Queue<Node<T>>();
            var temp = Root;
            q.Enqueue(temp);
            
            // Do level order traversal until we find
            // an empty place.
            while (q.Count != 0)
            {
                temp = q.Peek();
                q.Dequeue();

                if (temp.Left == null)
                {
                    temp.Left = new Node<T>(key);
                    break;
                }
                else
                    q.Enqueue(temp.Left);

                if (temp.Right == null)
                {
                    temp.Right = new Node<T>(key);
                    break;
                }
                else
                    q.Enqueue(temp.Right);
            }
        }

        public string PrintPreOrderTree(ITestOutputHelper outputHelper)
        {
            string result = "";
            return  PrintPreOrderTree(Root,outputHelper, result);
        }
        public string PrintInOrderTree(ITestOutputHelper outputHelper)
        {
            string result = "";
            return PrintInOrderTree(Root, outputHelper, result);
        }
        public string PrintPostOrderTree(ITestOutputHelper outputHelper)
        {
            string result = "";
            return PrintPostOrderTree(Root, outputHelper, result);
        }

        private int CountHeight(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            /*
            *       10
            *      /  \
            *    5     12
            *   / \
            *  4   6
            *       \
            *        7
            *  10
            *  10->CountHeightLeft(5)
            *       5->CountHeightLeft(4);
            *           4->CountHeightLeft(null) return 0;
            *           4->CountHeightRight(null) return 0;
            *           4->return 1;
            *          return 1;
            *       5->CountHeightRight(6);
            *           6->CountHeightLeft(null) return 0;
            *           6->CountHeightRight(7)
            *               7->CountHeightLeft(null) return 0;
            *               7->CountHeightRight(null) return 0;
            *              return 1;
            *           6->return 2;
            *          return 2;
            *       5->return 3;
            *      return 3;
            *  10->CountHeightRight(12);
            *       12->CountHeightLeft(null) return 0;
            *       12->CountHeightRight(null) return 0;
            *       12->return 1;
            *      return 1;
            *  10-> heigth > 1 =  return -1;
            * 
            *      
            */
            var heightLeft = CountHeight(node.Left);
            var heightRight = CountHeight(node.Right);

            var height = System.Math.Abs(heightLeft - heightRight);
            if (heightLeft == -1 || heightRight == -1 || height > 1) return -1;
            return System.Math.Max(heightLeft,heightRight)+1;
        }

       

        public bool IsBalanced()
        {
            if (Root == null)
            {
                return true;
            }

            return CountHeight(Root) != -1;
        }
        public string PrintPreOrderTree(Node<T> node, ITestOutputHelper outputHelper,string result)
        {
            if (node == null)
            {
                return result;
            }

            /*
              *       10
              *    5     12
              *  4  6  11  13
            */

            /*
             * 10
             * 10->Write 10
             * 10->PrintLeft(5)
             *      5->Write 5
             *      5->PrintLeft(4)
             *          4->Write 4
             *          4->PrintLeft(null) return;
             *          4->PrintRight(null) return;
             *         5->return
             *      5->PrintRight(6)
             *          6->Write 6
             *          6->PrintLeft(null) return;
             *          6->PrintRight(null)return;
             *         5->return
             *     10->return;
             *10->PrintRight(12)
             *      12->Write 12
             *      12->PrintLeft(11)
             *          11->Write 11
             *          11->PrintLeft(null) return;
             *          11->PrintRight(null)return;
             *         12->return;
             *      12->PrintRight(13)
             *          13->Write 13
             *          13->PrintLeft(null)return;
             *          13->PrintRight(null)return;
             *         12->return;
             *     10->return;
             *     
             * 10->5->4->6->12->11->13
             */
            result += node.Key + "->";
            outputHelper.WriteLine(result);
           
            result =PrintPreOrderTree(node.Left, outputHelper,result);
            result =PrintPreOrderTree(node.Right, outputHelper,result);
            return result;
        }

        public string PrintInOrderTree(Node<T> node, ITestOutputHelper outputHelper,string result)
        {
            if (node == null)
            {
                return result;
            }
            /*
              *       10
              *    5     12
              *  4  6  11  13
              */

            

            /*10
             *10->PrintLeft(5)
             *      5->PrintLeft(4)
             *          4->PrintLeft(null) return;
             *          4->Write 4
             *          4->PrintRight(null)return;
             *         5->return;
             *      5->Write 5;
             *      5->PrintRight(6)
             *          6->PrintLeft(null)return;
             *          6->Write 6
             *          6->PrintRight(null)return;
             *         5->return;
             *     10->return;
             *10->Write 10
             *10->PrintRight(12)
             *      12->PrintLeft(11)
             *          11->PrintLeft(null)return;
             *          11->Write 11
             *          11->PrintRight(null)return;
             *        12->return;
             *      12->Write 12
             *      12->PrintRight(13)
             *          13->PrintLeft(null)return;
             *          13->Write 13
             *          13->PrintRight(null)return;
             *        12->return;
             */
            //4->5->6->10->11->12->13
          
            result = PrintInOrderTree(node.Left, outputHelper,result);
            result += node.Key + "->";
            outputHelper.WriteLine(result);
            result = PrintInOrderTree(node.Right, outputHelper,result);
            return result;
        }

        public string PrintPostOrderTree(Node<T> node, ITestOutputHelper outputHelper,string result)
        {
            if (node == null)
            {
                return result;
            }
            /*
            *       10
            *    5     12
            *  4  6  11  13
            */

            /* 10
            *  10->PrintLeft(5)
            *       5->PrintLeft(4)
            *           4->PrintLeft(null) return;
            *           4->PrintRight(null) return;
            *           4->write 4
            *       5->PrintRight(6)
            *           6->PrintLeft(null) return;
            *           6->PrintRight(null) return;
            *           6->write 6
            *       write 5
            *  10->PrintRight(12)
            *       12->PrintLeft(11)
            *           11->PrintLeft(null) return;
            *           11->PrintRight(null) return;
            *           11->Write 11
            *       12->PrintRight(13)
            *           13->PrintLeft(null)return;
            *           13->PrintRight(null)return;
            *           13->Write 13
            *       12->Write 12
            *  10->Write 10
            *  
            *  4->6->5->11->13->12->10
            */
            result = PrintPostOrderTree(node.Left, outputHelper, result);
            result = PrintPostOrderTree(node.Right, outputHelper, result);
            result += node.Key + "->";
            outputHelper.WriteLine(result);
         
            return result;
        }
    }

    public class Node<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node()
        {

        }

        public Node(int key)
        {
            Key = key;
        }

        public Node(int key,T data)
        {
            Key = key;
            Value = data;
        }
     
    }
}
