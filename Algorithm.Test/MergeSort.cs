using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class MergeSort
    {
        private readonly ITestOutputHelper output;

        public MergeSort(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public void Recursive_Sort(int[] arr)
        {
            Recursive_Sort(arr, 0, arr.Length - 1);
        }

        public void Recursive_Sort(int[] arr,int leftStart,int RightEnd)
        {
            if (leftStart >= RightEnd)
            {
                return;
            }
            int middle = (leftStart + RightEnd) / 2;
            Recursive_Sort(arr, leftStart, middle);
            Recursive_Sort(arr, middle + 1, RightEnd);
            output.WriteLine($"===left :{leftStart}, Middle:{middle},Right:{RightEnd}===");
            Merge(arr, leftStart, middle, RightEnd);
        }

        private void Merge(int[] arr,int leftStart,int middle,int rightEnd)
        {
            /*problem : 1, 3, 2, 4, 5
             *Divide [1,3,2]    [4,5]
             *         /   \      /  \
             *      [1,3]  [2]  [4]  [5]
             *      / \
             *    [1] [3]
             *Solve : 
             *    [1,3]         [4,5]
             *     /   \
             *    [1,3] [2] 
             *    /
             *   [1,2,3]        [4,5]
             *   
             * combine : [1,2,3,4,5]
             *      
             *     
             */
            int sizeOfLeft = middle - leftStart + 1;
            int sizeOfRight = rightEnd - middle;

            int[] leftArr = new int[sizeOfLeft];
            int[] rightArr = new int[sizeOfRight];
            int i, j;

            for (i = 0; i < sizeOfLeft; i++)
            {
                leftArr[i] = arr[leftStart + i];
            }

            for (j = 0; j < sizeOfRight; j++)
            {
                rightArr[j] = arr[middle + 1+j];
            }

            string leftStringArr = string.Join(",", leftArr);
            string rightStringArr = string.Join(",", rightArr);

            output.WriteLine($"LeftArr :{leftStringArr}, RightArr:{rightStringArr}");

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;
            int index = leftStart;
            while (i<sizeOfLeft && j<sizeOfRight)
            {
                if(leftArr[i] <= rightArr[j])
                {
                    arr[index] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[index] = rightArr[j];
                    j++;
                }
                index++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < sizeOfLeft)
            {
                arr[index] = leftArr[i];
                i++;
                index++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < sizeOfRight)
            {
                arr[index] = rightArr[j];
                j++;
                index++;
            }
        }
    }
}
