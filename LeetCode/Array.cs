using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class Array
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 6, 10 })]
        [InlineData(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 3, 1, 2, 10, 1 }, new int[] { 3, 4, 6, 16, 17 })]
        public void Running_Sum_of_1d_Array_1480(int[] nums, int[] result)
        {
            /*
             * 1->0 = 1
             * 2->1 = 3
             * 3->3 = 6
             * 4->10
             */

            for (int i = 1; i < nums.Length; i++)
            {

                nums[i] = nums[i] + nums[i - 1];
            }


            Assert.Equal(result, nums);
        }

        [Theory]
        [InlineData(new int[] { 2, 5, 1, 3, 4, 7 },3, new int[] { 2, 3, 5, 4, 1, 7 })]
        [InlineData(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new int[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
        [InlineData(new int[] { 1, 1, 2, 2 }, 2, new int[] { 1, 2, 1, 2 })]

        public void Shuffle_the_Array_1470(int[] nums, int n, int[] result)
        {
            var newArr = new int[nums.Length];
            var x = 0;
            var y = n;
            for (int i = 0; i < nums.Length; i = i + 2)
            {
                newArr[i+1] = nums[y++];
                newArr[i] = nums[x++];
            }
            Assert.Equal(result, newArr);
        }

        [Theory]
        [InlineData(4,new int[] { 0, 1, 1, 2 })]
        public void Fibonnaci(int n, int[] result)
        {
            var res = new int[n];
          
            int prev = 0;
            int next = 1;
            res[0] = prev;
            res[1] = next;
            for (int i = 2; i < n; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
                res[i] = next;
            }

           
            Assert.Equal(result, res);
        }

        [Fact]
        public void checkAnagram()
        {
            // Write your code here
            List<String> text = new List<string>()
            {
                "code","aaagmnrs","anagrams","doce"
            };
            HashSet<String> temp = new HashSet<String>();
            List<String> result = new List<string>();
            for (int i = 0; i < text.Count; i++)
            {
                char[] Array1 = text[i].ToCharArray();
                System.Array.Sort(Array1);
                String str1 = new String(Array1);

                if (temp.Contains(str1) || temp.Contains(text[i]))
                {
                    continue;
                }
                else
                {
                    result.Add(text[i]);
                    temp.Add(str1);
                }
            }
            Assert.Equal(new List<string> { "code", "aaagmnrs" }, result);
        }
        [Theory]
        [InlineData(new int[] { 2, 3, 5, 1, 3 },3,new bool[] { true, true, true, false, true })]
        [InlineData(new int[] { 4, 2, 1, 1, 2 }, 1, new bool[] { true, false, false, false, false })]
        [InlineData(new int[] { 12, 1, 12 }, 10, new bool[] { true, false, true })]

        public void Kids_With_the_Greatest_Number_of_Candies_1431(int[] candies, int extraCandies,bool[] expected)
        {
            int greatest = 0;
            bool[] result = new bool[candies.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                var temp = candies[i];
                greatest = System.Math.Max(temp, greatest);
            }
            for (int i = 0; i < candies.Length; i++)
            {
                var temp = candies[i];
                var res = false;
                if (temp + extraCandies >= greatest)
                {
                    res = true;
                }
                result[i] = res;
            }
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Richest_Customer_Wealth))]
        public void Richest_Customer_Wealth_1672(int[][] accounts,int result)
        {
            int maxWealth = 0;

            if (accounts.Length == 0)
            {
                return;
            }
            for (int i = 0; i < accounts.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    count += accounts[i][j];
                }
                maxWealth = System.Math.Max(maxWealth, count);
            }

            Assert.Equal(result, maxWealth);
        }

        [Fact]
        public void XorQueries()
        {
            int[] arr = new int[] { 1, 3, 4, 8 };
            int[][] queries = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 0, 3 }, new int[] { 3, 3 } };
            int[] expected = new int[] { 2, 7, 14, 8 };
            int[] result = new int[queries.Length];
            int[] prefix = new int[arr.Length + 1];

            prefix[0] = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                prefix[i + 1] = prefix[i] ^ arr[i];
            }

            for (int i = 0; i < queries.Length; i++)
            {
                int L = queries[i][0];
                int R = queries[i][1];
                result[i] = prefix[L] ^ prefix[R + 1];
            }

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1,6,2,4},6)]
        public void Find_Max_Value_Recursive(int[] arr,int expected)
        {
            var max = Find_Max_Value(arr, arr.Length);
            Assert.Equal(expected, max);
        }

        private int Find_Max_Value(int[] arr,int arraySize)
        {
            if(arraySize == 1)
            {
                return arr[0];
            }
            else
            {
                int max = Find_Max_Value(arr, arraySize - 1);
                if(max > arr[arraySize - 1])
                {
                    return max;
                }
                else
                {
                    return arr[arraySize-1];
                }
            }

        }
        public static IEnumerable<object[]> Richest_Customer_Wealth =>
            new List<object[]>
            {
                new object[] { new int[][] { new int[]{ 1,2,3 }, new int[]{ 3,2,1 } }, 6},
                new object[] { new int[][] { new int[]{1,5 }, new int[]{ 7,3 },new int[]{3,5 } },10},
                new object[] { new int[][] { new int[] { 2, 8, 7 }, new int[] { 7, 1, 3 }, new int[] { 1, 9, 5 } },17},
            };
    }
}
