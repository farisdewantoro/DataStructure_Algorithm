using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class BubbleSort
    {
        private readonly ITestOutputHelper output;

        public BubbleSort(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        /*
         * Bubble Sort : mengurutkan secara terus-menerus/berulang dengan mengswap element apabila tidak sesuai urutan. tiap iterasi di mulai kembali dari index 0 untuk pengurutannya. dan pada akhirnya index terakhir adalah yg terbesar. menggunakan 2 loop, loop i dan loop j; i<arr.length dan j < arr.length - i - 1
         * contoh [5,2,4,6]
         * compare 2 element 5 dan 2 apabila 2 < 5 swap menjadi [2,5,4,6]
         * compare 2 element 5 dan 4 apabila 4 < 5 swap menjadi [2,4,5,6]
         * .. dan seterusnya 
         * 
        * First Pass:
       ( 5 1 4 2 8 ) –> ( 1 5 4 2 8 ), Here, algorithm compares the first two elements, and swaps since 5 > 1.
       ( 1 5 4 2 8 ) –>  ( 1 4 5 2 8 ), Swap since 5 > 4
       ( 1 4 5 2 8 ) –>  ( 1 4 2 5 8 ), Swap since 5 > 2
       ( 1 4 2 5 8 ) –> ( 1 4 2 5 8 ), Now, since these elements are already in order (8 > 5), algorithm does not swap them.

       Second Pass:
       ( 1 4 2 5 8 ) –> ( 1 4 2 5 8 )
       ( 1 4 2 5 8 ) –> ( 1 2 4 5 8 ), Swap since 4 > 2
       ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 )
       Now, the array is already sorted, but our algorithm does not know if it is completed. The algorithm needs one whole pass without any swap to know it is sorted.

       Third Pass:
       ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 )
       ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 )
        */

        /*
   *  Worst and Average Case Time Complexity: O(n*n). Worst case occurs when array is reverse sorted.
      Best Case Time Complexity: O(n). Best case occurs when array is already sorted.
      Auxiliary Space: O(1)
      Boundary Cases: Bubble sort takes minimum time (Order of n) when elements are already sorted.
      Sorting In Place: Yes
      Stable: Yes
   */
        public void Iterative_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            bool swapped;
            for (int i = 0; i < arr.Length; i++)
            {
                countTimeComplexity++;
                swapped = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                        countTimeComplexity++;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            output.WriteLine("Time Complexity : " + countTimeComplexity.ToString());


        }

        public void Recursive_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                countTimeComplexity++;
                bool swapped = Recursive_Sort(arr, 0, arr.Length - i - 1,ref countTimeComplexity);
                if (!swapped)
                {
                    break;
                }
            }
            output.WriteLine("Time Complexity : " + countTimeComplexity.ToString());

        }

        private static bool Recursive_Sort(int[] arr, int i, int length,ref int countTimeComplexity,bool swapped = false)
        {
            countTimeComplexity++;
            if (length <= i)
            {
                return swapped;
            }
            if (arr[i + 1] < arr[i])
            {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                swapped = true;
            }
            return Recursive_Sort(arr, ++i, length,ref countTimeComplexity, swapped);
        }
    }
}
