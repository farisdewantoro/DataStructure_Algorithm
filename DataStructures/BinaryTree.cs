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
         *  Full binary tree
         *  Complete binary tree
         *  Perfect binary tree
         *  Balanced Binary Tree 
         *
         * Traversing :
         *  Depth First Traversals:
         *      Inorder (Left, Root, Right)
         *      Preorder (Root, Left, Right)
         *      Postorder (Left, Right, Root)
         */
        public Node<T> Root { get; set; }

        public BinaryTree()
        {

        }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }


        

        public void PrintPreOrderTree(ITestOutputHelper outputHelper)
        {
            PrintPreOrderTree(Root,outputHelper);
        }
        public void PrintInOrderTree(ITestOutputHelper outputHelper)
        {
            PrintInOrderTree(Root, outputHelper);
        }
        public void PrintPostOrderTree(ITestOutputHelper outputHelper)
        {
            PrintPostOrderTree(Root, outputHelper);
        }

        public void PrintPreOrderTree(Node<T> node, ITestOutputHelper outputHelper)
        {
            if (node == null)
            {
                return;
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
            outputHelper.WriteLine(node.Value.ToString());
            PrintPreOrderTree(node.Left, outputHelper);
            PrintPreOrderTree(node.Right, outputHelper);
        }

        public void PrintInOrderTree(Node<T> node, ITestOutputHelper outputHelper)
        {
            if (node == null)
            {
                return;
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
          
            PrintInOrderTree(node.Left, outputHelper);
            outputHelper.WriteLine(node.Value.ToString());
            PrintInOrderTree(node.Right, outputHelper);
        }

        public void PrintPostOrderTree(Node<T> node, ITestOutputHelper outputHelper)
        {
            if (node == null)
            {
                return;
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
            var val = node.Value;
            PrintPostOrderTree(node.Left, outputHelper);
            PrintPostOrderTree(node.Right, outputHelper);
            outputHelper.WriteLine(node.Value.ToString());

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
