using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DataStructures.Test
{
    public class BinaryTreeTest
    {
        private readonly ITestOutputHelper output;

        public BinaryTreeTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Fact]
        public void Create_Full_BinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            var right = binaryTree.Root.Right;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);

            /*
              *       10
              *    5     12
              *  4  6    
            */
            output.WriteLine("PreOrder:======");
            var resPreOrder = binaryTree.PrintPreOrderTree(output);
            Assert.Equal("10->5->4->6->12->", resPreOrder);

            output.WriteLine("InOrder:=======");
            var resInOrder = binaryTree.PrintInOrderTree(output);
            Assert.Equal("4->5->6->10->12->", resInOrder);
            output.WriteLine("PostOrder:======");
            var resPostOrder = binaryTree.PrintPostOrderTree(output);
            Assert.Equal("4->6->5->12->10->", resPostOrder);

        }

        [Fact]
        public void Create_Complete_BinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            var right = binaryTree.Root.Right;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);
            right.Left = new Node<int>(11);
            /*
              *       10
              *    5     12
              *  4  6   11 
            */
            output.WriteLine("PreOrder:======");
            var resPreOrder = binaryTree.PrintPreOrderTree(output);
            Assert.Equal("10->5->4->6->12->11->", resPreOrder);

            output.WriteLine("InOrder:=======");
            var resInOrder = binaryTree.PrintInOrderTree(output);
            Assert.Equal("4->5->6->10->11->12->", resInOrder);
            output.WriteLine("PostOrder:======");
            var resPostOrder = binaryTree.PrintPostOrderTree(output);
            Assert.Equal("4->6->5->11->12->10->", resPostOrder);

        }


        [Fact]
        public void Create_Perfect_BinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            var right = binaryTree.Root.Right;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);
            right.Left = new Node<int>(11);
            right.Right = new Node<int>(13);

            /*
              *       10
              *    5     12
              *  4  6  11  13
            */
            output.WriteLine("PreOrder:======");
            var resPreOrder = binaryTree.PrintPreOrderTree(output);
            Assert.Equal("10->5->4->6->12->11->13->", resPreOrder);

            output.WriteLine("InOrder:=======");
            var resInOrder = binaryTree.PrintInOrderTree(output);
            Assert.Equal("4->5->6->10->11->12->13->", resInOrder);
            output.WriteLine("PostOrder:======");
            var resPostOrder = binaryTree.PrintPostOrderTree(output);
            Assert.Equal("4->6->5->11->13->12->10->", resPostOrder);

        }

        [Fact]
        public void Check_IsBalanced_BinaryTree_Should_True()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);

            /*
              *       10
              *    5     12
              *  4  6  
            */

            Assert.True(binaryTree.IsBalanced());

        }

        [Fact]
        public void Insert_BinaryTree_Should_Correct_Order()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            var right = binaryTree.Root.Right;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);
            //right.Left = new Node<int>(11);
            /*
              *       10
              *    5     12
              *  4  6   11  <- insert 13
            */
            //binaryTree.Insert(new Node<int>(13));
            binaryTree.InsertBFS_Using_Queue(11);
            var resInOrder = binaryTree.PrintInOrderTree(output);
            //Assert.Equal("4->5->6->10->11->12->13->", resInOrder);
            Assert.Equal("4->5->6->10->11->12->", resInOrder);
        }

        [Fact]
        public void Check_IsBalanced_BinaryTree_Should_False()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Root = new Node<int>(10);
            binaryTree.Root.Left = new Node<int>(5);
            binaryTree.Root.Right = new Node<int>(12);
            var left = binaryTree.Root.Left;
            left.Left = new Node<int>(4);
            left.Right = new Node<int>(6);
            left.Right.Right = new Node<int>(7);
            /*
            *       10
            *      /  \
            *    5     12
            *   / \
            *  4   6
            *       \
            *        7
            */

            Assert.False(binaryTree.IsBalanced());

        }



    }
}
