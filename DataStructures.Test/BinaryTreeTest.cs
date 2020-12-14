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

            output.WriteLine("PreOrder:======");
            binaryTree.PrintPreOrderTree(output);

            output.WriteLine("InOrder:=======");
            binaryTree.PrintInOrderTree(output);


            output.WriteLine("PostOrder:======");
            binaryTree.PrintPostOrderTree(output);
            Assert.Equal(5,binaryTree.Root.Left.Key);

        }
    }
}
