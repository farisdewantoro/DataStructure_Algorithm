using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class Array
    {
        public static void leftRotate(int[] arr, int d,
                         int n)
        {
            for (int i = 0; i < d; i++)
                leftRotatebyOne(arr, n);
        }

        public static void leftRotatebyOne(int[] arr, int n)
        {
            int i, temp = arr[0];
            for (i = 0; i < n - 1; i++)
                arr[i] = arr[i + 1];
            arr[i] = temp;
        }

        public static void Rotate_JuggleAlgorithm(int[] arr, int d,
                           int n)
        {
            int i, j, k, temp;
            /* To handle if d >= n */
            d = d % n;
            int g_c_d = GreatestCommonDivisor(d, n);
            for (i = 0; i < g_c_d; i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }
        public static int GreatestCommonDivisor(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GreatestCommonDivisor(b, a % b);
        }
        public static int[] reverse(int[] arr)
        {
            int[] newArray = new int[arr.Length];
            int tempIndex = 0;
            for (int i = 1; i <= arr.Length; i++)
            {
                newArray[tempIndex] = arr[arr.Length - i];
                tempIndex++;
            }

            return newArray;
        }

        public static int[] reverse2(int[] arr)
        {
            //1,2,3,4,5,6,7,8,9,10
            //10,2,3,4,5,6,7,8,9,1
            //10,9,3,4,5,6,7,8,2,1
            //10,9,8,4,5,6,7,3,2,1
            //10,9,8,7,5,6,4,3,2,1
            //10,9,8,7,6,5,4,3,2,1
            //O(n/2)
            for (int i = 0; i < arr.Length/2; i++)
            {
                var temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }

        
            return arr;
        }
    }
}
