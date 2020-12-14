using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DataStructures.Test
{
    public class QueueTest
    {

        private readonly ITestOutputHelper output;

        public QueueTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 5, 3, 3, 1 })]
        public void Implement_Queue_using_LinkedList(int[] arr)
        {
            var QueueLL = new QueueLinkedList<int>();
            foreach (var item in arr)
            {
                QueueLL.EnQueue(item);
            }

            foreach (var item in arr)
            {
                var result = QueueLL.DeQueue();
                Assert.Equal(item, result);
            }

            QueueLL.EnQueue(10);
            QueueLL.EnQueue(20);
            QueueLL.DeQueue();
            QueueLL.DeQueue();
            QueueLL.EnQueue(30);
            QueueLL.EnQueue(40);
            QueueLL.EnQueue(50);
            QueueLL.DeQueue();
            output.WriteLine("Queue Front : " + QueueLL.Front.Data);
            output.WriteLine("Queue Rear : " + QueueLL.Rear.Data);
            Assert.Equal(40, QueueLL.Front.Data);
            Assert.Equal(50, QueueLL.Rear.Data);
        }
    }
}
