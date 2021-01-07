using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class MergeSort
    {
        /* Summary
         * Seperti QuickSort, MergeSort adalah salah satu algoritma yg menerapkan teknik Divide & Conquer dengan cara membagi2 array kedalam beberapa bagian yang kemudian tiap bagiannya diurutkan dan di akhirnya akan dimerge kembali
         * 
         */
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

        public void Iterative_Sort(int[] arr)
        {
            int arrSize = arr.Length-1;
            for (int currSize = 1; currSize <= arrSize; currSize = 2*currSize)
            {
                for (int leftStart = 0; leftStart < arrSize; leftStart+=2*currSize)
                {
                    int middle = leftStart + currSize - 1;
                    int rightEnd = Math.Min(leftStart+ 2 * currSize - 1, arrSize);
                    output.WriteLine($"===currSize:{currSize}, left :{leftStart}, Middle:{middle},Right:{rightEnd}===");

                    Merge(arr, leftStart, middle, rightEnd);
                }
            }
            /* problem : 1, 6, 2, 4, 5, 3
             * Divide :  [1,6]     [2,4]    [5,3]  
             *            /\        /\       /\
             *          [1] [6]   [2] [4]  [5] [3] size 1 
             *            /        \          /
             *          [1,6]     [2,4]     [3,5] size 2 
             *                  /        \
             *              [1,2,4,6]     [3,5] size 4
             *                        |
             *                  [1,2,3,4,5,6]
             *  ===currSize:1, left :0, Middle:0,Right:1===
                LeftArr :1, RightArr:6
                ===currSize:1, left :2, Middle:2,Right:3===
                LeftArr :2, RightArr:4
                ===currSize:1, left :4, Middle:4,Right:5===
                LeftArr :5, RightArr:3
                ===currSize:2, left :0, Middle:1,Right:3===
                LeftArr :1,6, RightArr:2,4
                ===currSize:2, left :4, Middle:5,Right:5===
                LeftArr :3,5, RightArr:
                ===currSize:4, left :0, Middle:3,Right:5===
                LeftArr :1,2,4,6, RightArr:3,5
             */
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
             * === left :0, Middle: 0,Right: 1 ===
                   LeftArr :1, RightArr: 3
               === left :0, Middle: 1,Right: 2 ===
                   LeftArr :1,3, RightArr: 2
               === left :3, Middle: 3,Right: 4 ===
                   LeftArr :4, RightArr: 5
               === left :0, Middle: 2,Right: 4 ===
                   LeftArr :1,2,3, RightArr: 4,5
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
