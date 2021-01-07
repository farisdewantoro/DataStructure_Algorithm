using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class LinearSearch
    {
        private readonly ITestOutputHelper output;

        public LinearSearch(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public int Iterative_Search(int[] arr, int key)
        {
            int left;
            int right = arr.Length - 1;

            for (left = 0; left < right; left++)
            {
                output.WriteLine($"left:{left}, right:{right}");
                if(arr[left] == key)
                {
                    return left;
                }

                if(arr[right] == key)
                {
                    return right;
                }

                right--;
            }

            return -1;
        }

        public int Recursive_Search(int[] arr,int key)
        {
           int indexFind =  Recursive_Search(arr, key,0,arr.Length-1);
            return indexFind;
        }

        public int Recursive_Search(int[] arr,int key,int left,int right)
        {
            output.WriteLine($"left:{left}, right:{right}");
            if (left >= right)
            {
                return -1;
            }

            if(arr[left] == key)
            {
                return left;
            }

            if(arr[right] == key)
            {
                return right;
            }

            int result =  Recursive_Search(arr, key, ++left, --right);
            output.WriteLine($"left:{left}, right:{right},result:{result}");
            return result;
        }
    }
}
