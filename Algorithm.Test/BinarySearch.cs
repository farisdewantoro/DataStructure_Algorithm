using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class BinarySearch
    {
        private readonly ITestOutputHelper output;

        public BinarySearch(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public int Iterative_Search(int[] arr,int key)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                /*[1,2,3,4,6]
                 * 5-0 = 5/2 = 2
                 * [3,4,6]
                 * 5+2 = 7/2 = 3
                 * 
                 * [5,7,9,11,12]
                 * 4+0 = 4/2 = 2
                 * 9 < 13 == left = 3
                 * 5+3 = 8/2 = 4
                 * 
                 */
                int middle = (right + left) / 2;
                output.WriteLine($"left:{left},middle:{middle},right:{right}");
                if(arr[middle] == key)
                {
                    return middle;
                }

                if(arr[middle] > key)
                {
                    right = --middle;
                }
                else
                {
                    left = ++middle;
                }
            }

            return -1;
        }

        public int Recursive_Search(int[] arr,int key)
        {
            return Recursive_Search(arr, key, 0, arr.Length - 1);
        }

        public int Recursive_Search(int[] arr,int key,int left,int right)
        {
            int middle = (right + left) / 2;
            
            if(left > right)
            {
                return -1;
            }
            
            if(arr[middle] == key)
            {
                return middle;
            }

            if(arr[middle] < key)
            {
                return Recursive_Search(arr, key, middle + 1, right);
            }
            else
            {
                return Recursive_Search(arr, key, left, middle - 1);
            }
        }
    }
}
