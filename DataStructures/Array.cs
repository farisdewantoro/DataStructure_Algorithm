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

        private static void Swap(int[] arr, int fi, int si, int d)
        {
            int i, temp;
            for (i = 0; i < d; i++)
            {
                temp = arr[fi + i];
                arr[fi + i] = arr[si + i];
                arr[si + i] = temp;
            }
        }

        public static int[] Rotate_Arr_Of_Size_N_by_D_element_WithOut_Extra_Memory(int[] arr, int d, int n)
        {
            //1,2,3,4,5,6,7
            //6,7,3,4,5,1,2
            //4,5,3,6,7,1,2
            //3,5,4,6,7,1,2
            //3,4,5,6,7,1,2

            //i = 3
            //j = 5-3 = 2
            //5, 4, 3, 1, 2
            //1,2,3,5,4
            //i = 3-2 = 1
            //1,2,4,5,3
            //j = 1
            //1,2,5,4,3


            //1,2,3,4,5,6
            //
            int i = d, j = n - d;
            while (i != j)
            {
                if (i < j)
                {
                    Swap(arr, d - i, d + j - i, i);
                    j -= i;
                }
                else
                {
                    Swap(arr, d - i, d, j);
                    i -= j;
                }
            }
            Swap(arr, d - i, d, j);
            return arr;
        }
        public static int[] Rotate_Using_Temp_Array(int[] arr, int d, int n)
        {
            int[] tempArr = new int[d];
      

            for (int i = 0; i < n-d; i++)
            {
                if(i < d)
                {
                    tempArr[i] = arr[i];
                }
                arr[i] = arr[i+d];
            }

            if(n-d < d)
            {
                for (int i = 0; i < d-(n-d); i++)
                {
                    tempArr[(n - d) + i] = arr[(n - d) + i]; 
                }
            }

            for (int i = 0; i < d; i++)
            {
                arr[arr.Length - (d - i)] = tempArr[i];
            }
            return arr;
        }

        public static int[] Rotate_Arr_Of_Size_N_by_D_element_Extra_Memory(int[] arr, int d, int n)
        {
            int[] newArr = new int[n];
            var indexNewArr = 0;
            for (int i = d; i < n; i++)
            {
                newArr[indexNewArr] = arr[i];
                indexNewArr++;
            }
            for (int i = 0; i < d; i++)
            {
                newArr[indexNewArr] = arr[i];
                indexNewArr++;
            }
            return newArr;
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
            //O(logN)
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
