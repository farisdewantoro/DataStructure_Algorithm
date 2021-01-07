using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class QuickSort
    {
        private readonly ITestOutputHelper output;

        public QuickSort(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public void Recursive_Sort(int[] arr)
        {
            Recursive_Sort(arr, 0, arr.Length-1);
        }
        public void Recursive_Sort(int[] arr, int low, int high)
        {
            output.WriteLine($"Recursive ==low:{low}, high:{high}===");
            if (low < high)
            {
                int pi = Partition(arr, low, high);
               

                Recursive_Sort(arr,low,pi-1);
                Recursive_Sort(arr, pi + 1, high);
            }

            /*
             * problem : [64, 25, 12, 22, 11]
             *            /                \
             *           low               high,pivot
             * [11, 25, 12, 22, 64]
             *      /            \
             *     low          high,pivot
             * [11, 25, 12, 22, 64]
             *      /        \
             *     low      high,pivot
             *     
             * [11,12,22,25,64]
             * 
             * 
             * problem : [5, 1, 4, 2, 8]
             *           /             \
             *          low             high,pivot
             * [5, 1, 4, 2, 8]
             *  /         \ 
             * low         high,pivot
             * [ 1, 2, 4, 5, 8]
             *  / \
             * low,high return;
             *      
             * [1, 2, 4, 5, 8]
             *        /   \   
             *       low   high,pivot
             * [1, 2, 4, 5, 8]
             *       / \
             *      low high
             * [1, 2, 4, 5, 8]
             *     /   \
             *    high   low
             * [1, 2, 4, 5, 8]
             *           /  \
             *          high low 
             * return [1,2,4,5,8]
             * 
             */
        }
        public void Iterative_Sort(int[] arr)
        {

            int top = -1;
            int[] stack = new int[arr.Length];
            stack[++top] = 0; //low
            stack[++top] = arr.Length - 1; //high
            while (top > 0 )
            {

                int high = stack[top--];
                int low = stack[top--];

                int pi = Partition(arr, low, high);

                // If there are elements on 
                // left side of pivot, then 
                // push left side to stack 
                if (pi-1 > low)
                {
                    stack[++top] = low;
                    stack[++top] = pi - 1;
                }

                // If there are elements on 
                // right side of pivot, then 
                // push right side to stack 
                if (pi+1 < high)
                {
                    stack[++top] = pi + 1;
                    stack[++top] = high;
                }
            }
        }

        public int Partition(int[] arr,int low,int high)
        {
           
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }

            }
            int tempLast = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tempLast;

            output.WriteLine($"Partition ==low:{low}, high:{high}, pivot:{pivot}, i:{i+1}===");
            return i + 1;
        }
    }
}
