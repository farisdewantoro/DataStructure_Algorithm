using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algorithm.Test
{
    public class DivideAndConquerTest
    {
        private readonly ITestOutputHelper output;
        private readonly DivideAndConquer _divideAndConquer;
        public DivideAndConquerTest(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
            _divideAndConquer = new DivideAndConquer(output);
        }

        [Theory]
        [InlineData(new int[] { 1, 4, 3, 7 },7)]
        [InlineData(new int[] { 1, 4, 3, 7,11 }, 11)]
        public void Find_Maximum(int[] arr,int expected)
        {
            int maximum = _divideAndConquer.Find_Maximum(arr);
            Assert.Equal(expected, maximum);
        }
    }
}
