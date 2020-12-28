using System;
using Xunit;

namespace DataStructures.Test
{
    public class ArrayTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 7, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 3, 5, new int[] { 1, 2, 5, 4, 3 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 4, 5, new int[] { 2, 5, 4, 3, 1 })]
        public void Rotate_Arr_Of_Size_N_by_D_element_Extra_Memory(int[] arr, int d, int n, int[] arrResult)
        {
            Assert.Equal(arrResult, Array.Rotate_Arr_Of_Size_N_by_D_element_Extra_Memory(arr, d, n));
        }
        [Theory]
        [InlineData(new int[]{ 1, 2, 3, 4, 5, 6, 7 }, 2, 7,new int[] { 3, 4, 5, 6, 7,1,2 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 3, 5, new int[] { 1, 2, 5, 4, 3 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 4, 5, new int[] { 2, 5,4,3,1 })]
        public void Rotate_Array_of_Size_N_by_D_OneByOne(int[] arr,int d, int n,int[] result)
        {
            Array.leftRotate(arr, d, n);
            Assert.Equal(arr, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 7, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 3, 5, new int[] { 1, 2, 5, 4, 3 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 4, 5, new int[] { 2, 5, 4, 3, 1 })]
        public void Rotate_Array_JuggleAlgorithm(int[] arr, int d, int n, int[] result)
        {
            Array.Rotate_JuggleAlgorithm(arr, d, n);
            Assert.Equal(arr, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 7, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 3, 5, new int[] { 1, 2, 5, 4, 3 })]
        public void Rotate_Using_Temp_Array(int[] arr, int d, int n, int[] arrResult)
        {
            Assert.Equal(arrResult, Array.Rotate_Using_Temp_Array(arr, d, n));
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 7, new int[] { 3, 4, 5, 6, 7, 1, 2 })]
        [InlineData(new int[] { 5, 4, 3, 1, 2 }, 3, 5, new int[] { 1, 2, 5, 4, 3 })]
        public void Rotate_Arr_Of_Size_N_by_D_element(int[] arr, int d, int n, int[] arrResult)
        {
            //1,2,3,4,5,6,7
            //3,4,1,2,5,6,7
            //3,4,5,6,1,2,7
            //3,4,5,6,7,2,1
            //3,4,5,6,7,1,2

            /*
             * i=2
             * j=5
             * 
             * j=3
             * j=1
             * i=1
             */

            Assert.Equal(arrResult, Array.Rotate_Arr_Of_Size_N_by_D_element_WithOut_Extra_Memory(arr, d, n));

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5}, new int[] { 5,1, 2, 3, 4 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5,6 }, new int[] { 6, 1, 2, 3, 4,5 })]

        public void Cyclically_Rotate_Array_Clockwise_by_one(int[] arr, int[] result)
        {
            //FARIS:
            //5-1 5,2,3,4,5 //prev 1
            //1-2 5,1,3,4,5 //prev 2
            //2-3 5,1,2,4,5 //prev 3
            //3-4 5,1,2,3,5 //prev 4
            //4-5 5,1,2,3,4 //prev 5

            //int prev = arr[arr.Length-1];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int temp = arr[i];
            //    arr[i] = prev;
            //    prev = temp;
            //}

            //GEEKS FOR GEEKS : 
            // 4-5 -> 1,2,3,4,4
            // 3-4 -> 1,2,3,3,4
            // 2-3 -> 1,2,2,3,4
            // 1-2 -> 1,1,2,3,4
            // 5-1 -> 5,1,2,3,4
            int x = arr[arr.Length - 1], i;

            for (i = arr.Length - 1; i > 0; i--)
                arr[i] = arr[i - 1];
            arr[0] = x;
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
