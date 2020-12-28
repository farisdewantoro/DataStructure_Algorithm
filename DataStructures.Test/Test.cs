using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DataStructures.Test
{
    public class Test
    {
        private readonly ITestOutputHelper output;

        public Test(ITestOutputHelper testOutputHelper)
        {
            output = testOutputHelper;
        }
        [Fact]
        public async void AsyncTest()
        {
            output.WriteLine("===1===");
             MyMethodAsync();
            await MyMethodAsync();

            output.WriteLine("===2===");


        }



        private async Task MyMethodAsync()
        {
            await Task.Yield();
            Task<int> longRunningTask = LongRunningOperationAsync();
            output.WriteLine("M3");
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            output.WriteLine(result.ToString());
        }

        private async Task<int> LongRunningOperationAsync()
        {
            await Task.Delay(1000);
            return 1;
        }
    }
}
