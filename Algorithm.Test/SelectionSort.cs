using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class SelectionSort
    {
        private readonly ITestOutputHelper output;

        public SelectionSort(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        /*
         * Selection Sort : mengurutkan dengan mencari nilai minimum dari yg belum diurutkan, dan taro di paling depan setelah mendapatkannya. 
         * cari nilai minimum dari  arr[0...4] taro di index 0
         * cari nilai minimum dari  arr[1...4] taro di index 1
         * cari nilai minimum dari  arr[2...4] taro di index 2 
         * ... dan seterusnya sampai n length
         */

        /* Find the minimum element in arr[0...4]
         // and place it at beginning
                     11 25 12 22 64

         // Find the minimum element in arr[1...4]
         // and place it at beginning of arr[1...4]
                     11 12 25 22 64

         // Find the minimum element in arr[2...4]
         // and place it at beginning of arr[2...4]
                     11 12 22 25 64

         // Find the minimum element in arr[3...4]
         // and place it at beginning of arr[3...4]
                     11 12 22 25 64
         */
        //Time Complexity: O(n2) as there are two nested loops.
        public void Iterative_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countTimeComplexity++;
                int indx = i;
                for (int j = i; j < arr.Length; j++)
                {
                    countTimeComplexity++;
                    if (arr[j] < arr[indx])
                    {
                        indx = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[indx];
                arr[indx] = temp;
            }
            output.WriteLine("Time Complexity : " + countTimeComplexity.ToString());

        }
    }
}
