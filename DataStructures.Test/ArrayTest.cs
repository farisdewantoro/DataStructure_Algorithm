using System;
using Xunit;

namespace DataStructures.Test
{
    public class ArrayTest
    {
        [Theory]
        [InlineData(new int[]{ 1, 2, 3, 4, 5, 6, 7 }, 2, 7,new int[] { 3, 4, 5, 6, 7,1,2 })]
        public void Rotate_Array_of_Size_N_by_D_OneByOne(int[] arr,int d, int n,int[] result)
        {
            Array.leftRotate(arr, d, n);
            Assert.Equal(arr, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 7, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        public void Rotate_Array_JuggleAlgorithm(int[] arr, int d, int n, int[] result)
        {
            Array.Rotate_JuggleAlgorithm(arr, d, n);
            Assert.Equal(arr, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7,6,5,4,3,2,1 })]
        public void Reverse_Array(int[] arr, int[] result)
        {
            
            Assert.Equal(Array.reverse(arr), result);

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 })]
        public void Reverse2_Array(int[] arr, int[] result)
        {
            Assert.Equal(Array.reverse2(arr), result);

        }

        [Fact]
        public void ReverseTest_Array()
        {
            int[] arr = new int[10000000];
            int[] arr2 = new int[10000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i+1;
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = i + 1;
            }
            System.Array.Reverse(arr);

            Assert.Equal(arr,Array.reverse(arr2) );

        }

        [Fact]
        public void ReverseTest2_Array()
        {
            int[] arr = new int[10000000];
            int[] arr2 = new int[10000000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = i + 1;
            }

            System.Array.Reverse(arr);
            Array.reverse2(arr2);
            Assert.Equal(arr, arr2);

        }

    }
}
