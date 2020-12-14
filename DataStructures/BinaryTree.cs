using System;
using System.Collections.Generic;
using System.Text;

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
         *Full binary tree
         *Complete binary tree
         *Perfect binary tree
         *Balanced Binary Tree 

         */
        public Node<T> Root { get; set; }

        public BinaryTree()
        {

        }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node()
        {

        }
    }
}
