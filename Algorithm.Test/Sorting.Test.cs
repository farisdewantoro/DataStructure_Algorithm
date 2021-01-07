using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class Sorting
    {
        /*
         * Terminology
         * In-place sorting : hanya merubah array yg diberikan sesuai urutan. contoh: Insertion Sort & Selection Sort 
         * Internal and External sortings : 
         *  External : ketika memerlukan data yg perlu diurutkan tidak dapat ditempatkan di memory secara satu waktu.
         *             digunakan ketika menggunakan data yang besar. contoh algoritma -> Merge Sort
         *  Internal : ketika data di simpan di memory.
         * Stable sorting : 
         * 
         */
        private readonly ITestOutputHelper output;

        public Sorting(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Merge_Sort_Recursive(int[] arr,int[] expected)
        {
            MergeSort mergeSort = new MergeSort(output);
            mergeSort.Recursive_Sort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Merge_Sort_Iterative(int[] arr, int[] expected)
        {
            MergeSort mergeSort = new MergeSort(output);

            mergeSort.Iterative_Sort(arr);
            Assert.Equal(expected, arr);

        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Quick_Sort_Iterative(int[] arr, int[] expected)
        {
            QuickSort quickSort = new QuickSort(output);

            quickSort.Iterative_Sort(arr);
            Assert.Equal(expected, arr);

        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Quick_Sort_Recursive(int[] arr, int[] expected)
        {
            QuickSort quickSort = new QuickSort(output);

            quickSort.Recursive_Sort(arr);
            Assert.Equal(expected, arr);

        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Bubble_Sort(int[] arr, int[] expected)
        {
            int[] recursiveArr = new int[arr.Length];
            Array.Copy(arr, recursiveArr, arr.Length);
            BubbleSort bubbleSort = new BubbleSort(output);

            bubbleSort.Iterative_Sort(arr);
            Assert.Equal(expected, arr);

            bubbleSort.Recursive_Sort(recursiveArr);
            Assert.Equal(expected, recursiveArr);
        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Selection_Sort(int[] arr,int[] expected)
        {
            SelectionSort selectionSort = new SelectionSort(output);
            selectionSort.Iterative_Sort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [MemberData(nameof(sortingTestASC))]
        public void Insertion_Sort(int[] arr, int[] expected)
        {
          

            int[] GGArr = new int[arr.Length];
            int[] recursiveArr = new int[arr.Length];
            Array.Copy(arr, GGArr, arr.Length);
            Array.Copy(arr, recursiveArr, arr.Length);

            InsertionSort insertionSort = new InsertionSort(output);

            insertionSort.Iterative_Sort(arr);
            Assert.Equal(expected, arr);

            insertionSort.GG_Sort(GGArr);
            Assert.Equal(expected, GGArr);

            insertionSort.Recursive_Sort(recursiveArr);
            Assert.Equal(expected, recursiveArr);
        }
        public static IEnumerable<object[]> sortingTestASC =>
            new List<object[]>
            {
                    new object[] { new int[] { 64, 25, 12, 22, 11 }, new int[] { 11, 12, 22, 25, 64 } },
                    new object[] {new int[] { 5, 1, 4, 2, 8 }, new int[] { 1, 2, 4, 5, 8 }},
                    new object[] { new int[] { 1, 3, 2, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }},
                    new object[] { new int[] { 1, 6, 2, 4, 5,3 }, new int[] { 1, 2, 3, 4, 5,6 }},
                    new object[] { new int[] { 11, 6, 22, 4, 5,3,7,3 }, new int[] { 3, 3, 4, 5, 6,7,11,22 }},
                    new object[] { new int[] { 11, 6, 22 }, new int[] { 6,11,22 }},
                    new object[] { new int[] { 11, 6 }, new int[] { 6,11 }},

            };
     
    }
}
