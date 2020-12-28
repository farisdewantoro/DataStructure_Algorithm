using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class DivideAndConquer
    {
        /*
         * Divide and Conquer adalah sebuah teknik untuk menyelesaikan sebelum masalah menjadi sub problem dengan cari membagi main problemnya. untuk penggunaan teknik ini setiap sub problem harus menyelesaikan main problemnya.
         * 
         * algoritma yg menggunakan Divide And Conquer
         * 1. Binary Search
         * 2. Merge Sort
         * 3. Quick Sort
         * 4. dll
         * 
         * stepnya :
         *  1. Divide = bagi main problem menjadi sub problem
         *  2. Conquer/Solve = solve semua sub problemnya menjadi sebuah solution
         *  3. Combine = gabungkan semua solution dari sub problem menjadi 1 solution
         */
        private readonly ITestOutputHelper output;

        public DivideAndConquer(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public int Find_Maximum(int[] arr)
        {
            /*Problem : find maximum number of [1,4,3,7]
             * 
             * divide problem : 
             * 1 sub problem = 1,4; 2 sub problem = 3,7
             * 
             * solve:
             * maximum dari subproblem 1 = 4
             * maximum dari sub problem 2 = 7
             * 
             * combine:
             * main problem = 4,7
             * maximum main problem = 7;
             */

            return Find_Maximum(arr, 0, arr.Length - 1);
        }

        public int Find_Maximum(int[] arr,int start,int end)
        {
            /*Problem : find maximum number of [1,4,3,7]
             * start = 0, end = 3, halfway = (0+3)/2 = 1
             * 
             * 1->start = 0, end = 1;
             * 1->left = 1
             * 1->start = 0+1; end = 0;
             */
            if (start == end)
            {
                return arr[start];
            }
            int halfway = (start+end) / 2; 
            int left = Find_Maximum(arr, start,halfway);
            int right = Find_Maximum(arr, halfway+1, end);
            if(left > right)
            {
                return left;
            }
            else
            {
                return right;
            }

        }


    }
}
