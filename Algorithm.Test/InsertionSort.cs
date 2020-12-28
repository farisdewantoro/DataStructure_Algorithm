using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class InsertionSort
    {
        private readonly ITestOutputHelper output;

        public InsertionSort(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        /*
         * Insertion Sort : mengurutkan dengan memisahkan array kedalam 2 bagian secara virtual, bagian 1 adalah yang sudah diurutkan, bagian 2 yg belum diurutkan. yang nantinya ketika kita mengambil value dari yg belum  diurutkan (bagian 2) maka akan disimpan sesuai posisi yg benar di bagian 1. 
         * 
         * dimulai dari index arr[1] ke arr[n]
         * compare posisi sekarang dengan posisi sebelumnya -> arr[1] < arr[0]
         * jika arr[1] < arr[0] maka swap. 
         * begitu selanjutnya -> arr[2] < arr[1] is true then arr[1] < arr[0] (compare semua yg ada di bagian 1)
         * apabila arr[3] < arr[2] is false <- maka lanjut ke iterasi selanjutnya tanpa perlu mengecek semua dibagian 1
         * 
         * Time Complexity: O(n*2)
            Auxiliary Space: O(1)
            Boundary Cases: Insertion sort takes maximum time to sort if elements are sorted in reverse order. And it takes minimum time (Order of n) when elements are already sorted.
            Algorithmic Paradigm: Incremental Approach
            Sorting In Place: Yes
            Stable: Yes
            Online: Yes
            Uses: Insertion sort is used when number of elements is small. It can also be useful when input array is almost sorted, only few elements are misplaced in complete big array.
         */


        public void Iterative_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                countTimeComplexity++;
                bool swapped = false;
                for (int j = 0; j < i; j++)
                {
                   
                    if (arr[i-j] < arr[i-j-1])
                    {
                        var temp = arr[i - j - 1];
                        arr[i - j - 1] = arr[i-j];
                        arr[i-j] = temp;
                        swapped = true;
                        countTimeComplexity++;
                    }
                    if (!swapped)
                    {
                        break;
                    }
                }
            }
            output.WriteLine("Time Complexity : "+countTimeComplexity.ToString());


        }

        public void Recursive_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            Recursive_Sort(arr, arr.Length,ref countTimeComplexity);
            output.WriteLine("Time Complexity : " + countTimeComplexity.ToString());

        }

        public void Recursive_Sort(int[] arr,int n, ref int countTimeComplexity)
        {
            countTimeComplexity++;
            // Base case 
            if (n <= 1)
                return;

            // Sort first n-1 elements 
            Recursive_Sort(arr, n - 1, ref countTimeComplexity);

            // Insert last element at  
            // its correct position 
            // in sorted array. 
            int last = arr[n - 1];
            int j = n - 2;

            /* Move elements of arr[0..i-1],  
            that are greater than key, to  
            one position ahead of their 
            current position */
            while (j >= 0 && arr[j] > last)
            {
                arr[j + 1] = arr[j];
                j--;
                countTimeComplexity++;
            }
            arr[j + 1] = last;

        }

        public void GG_Sort(int[] arr)
        {
            int countTimeComplexity = 0;
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                countTimeComplexity++;
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && arr[j] > key)
                {
                    countTimeComplexity++;
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            output.WriteLine("Time Complexity : " + countTimeComplexity.ToString());

        }
    }
}
