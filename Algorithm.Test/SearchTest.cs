using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class SearchTest
    {
        private readonly ITestOutputHelper output;

        public SearchTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(sortedArr))]
        public void BinarySearchTest_Iterative(int[] arr, int key, int expected)
        {
            BinarySearch binarySearch = new BinarySearch(output);
            int index = binarySearch.Iterative_Search(arr, key);
            Assert.Equal(expected, index);
        }
        [Theory]
        [MemberData(nameof(sortedArr))]
        public void BinarySearchTest_Recursive(int[] arr, int key, int expected)
        {
            BinarySearch binarySearch = new BinarySearch(output);
            int index = binarySearch.Recursive_Search(arr, key);
            Assert.Equal(expected, index);
        }

        [Theory]
        [MemberData(nameof(sortedArr))]
        public void JumpSearchTest_Iterative(int[] arr, int key, int expected)
        {
            JumpSearch jumpSearch = new JumpSearch(output);
            int index = jumpSearch.Iterative_Search(arr, key);
            Assert.Equal(expected, index);
        }

        [Theory]
        [MemberData(nameof(sortedArr))]
        public void JumpSearchTest_Recursive(int[] arr, int key, int expected)
        {
            JumpSearch jumpSearch = new JumpSearch(output);
            int index = jumpSearch.Recursive_Search(arr, key);
            Assert.Equal(expected, index);
        }

        [Theory]
        [MemberData(nameof(unsortedArr))]
        public void LinearSeachTest_Iterative(int[] arr, int key,int expected)
        {
            LinearSearch linearSearch = new LinearSearch(output);
            int index = linearSearch.Iterative_Search(arr,key);
            Assert.Equal(expected,index);
        }

        [Theory]
        [MemberData(nameof(unsortedArr))]
        public void LinearSeachTest_Recursive(int[] arr, int key, int expected)
        {
            LinearSearch linearSearch = new LinearSearch(output);
            int index = linearSearch.Recursive_Search(arr, key);
            Assert.Equal(expected, index);
        }

        public static IEnumerable<object[]> unsortedArr =>
          new List<object[]>
          {
                    new object[] { new int[] { 1, 2, 6, 8, 0, 19, 29 }, 19,5},
                    new object[] { new int[] { 16, 22, 6, 8, 0, 19, 29 }, 12, -1},
                    new object[] { new int[] { 16, 22, 6, 8, 0, 19, 29 }, 6, 2 }

          };

        public static IEnumerable<object[]> sortedArr =>
           new List<object[]>
           {
                        new object[] { new int[] { 1,2,3,4,5,6 }, 2,1},
                        new object[] { new int[] { 5,7,9,11,12 }, 12,4},
                        new object[] { new int[] { 1, 5, 7, 9, 11, 12 }, 13, -1 },
                        new object[] { new int[] { 2, 5, 6, 9, 11, 12 }, 5, 1 },
                        new object[] { new int[] { 0, 5, 11, 22, 66, 100 }, 0, 0 }
           };
    }
}
