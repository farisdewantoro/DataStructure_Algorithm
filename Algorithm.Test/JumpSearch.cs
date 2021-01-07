using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class JumpSearch
    {
        private readonly ITestOutputHelper output;

        public JumpSearch(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        public int Iterative_Search(int[] arr,int key)
        {
            int nLength = arr.Length;
            int jump = (int)Math.Floor(Math.Sqrt(nLength));
            int step = jump;
            int prev = 0;
            /*
             * 1,2,3,4,5,6 x = 2, length = 6
             * 
             * 
             */
            while (arr[Math.Min(step,nLength)-1] < key)
            {
                prev = step;
                step += jump;
                if(prev >= nLength)
                {
                    return -1;
                }
            }

            while(arr[prev] < key)
            {
                prev++;
                if(prev == Math.Min(step, nLength))
                {
                    return -1;
                }
            }

            if(arr[prev] == key)
            {
                return prev;
            }

            return -1;
        }

        public int Recursive_Search(int[] arr,int key)
        {
            int nLength = arr.Length;
            int step = (int)Math.Floor(Math.Sqrt(nLength));

            return Recursive_Search(arr, key, nLength, step, 0);
        }

        public int Recursive_Search(int[] arr, int key, int nLength,int step, int prev)
        {
           
            if (prev >= nLength) return -1;
            if (arr[prev] == key) return prev;

            if (arr[Math.Min(step,nLength)-1] < key)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(nLength));
                return Recursive_Search(arr, key, nLength, step, prev);
            }
            else
            {
                return Recursive_Search(arr, key, nLength, step, ++prev);
            }
          
            

        }
    }
}
