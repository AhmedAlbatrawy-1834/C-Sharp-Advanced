namespace TaskContinuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<long> task = Task.Run(() => SumRange(10, 5_000_000));

            // -- 1 --
             //Console.WriteLine($"The result is:{task.Result}");  // Bad Block Thread Until The Result Calculated

            // -- 2 --
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>           // this not Block Thread 
            //{
            //    Console.WriteLine($"The Result is:{awaiter.GetResult()}"); // Here .GetResult() not Bad because the Result already Calculated 
            //});

            // -- 3 --
            // this not Block Thread
            task.ContinueWith((task) => Console.WriteLine($"The Result is:{task.Result}"));  // Here .Result not Bad because the Result already Calculated 
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} Core:{Thread.GetCurrentProcessorId()} isBackground:{Thread.CurrentThread.IsBackground}");
            Console.WriteLine("Some Code");
            Console.ReadKey();
        }

        static long SumRange(long min,long max)   // Method Take Some Time 
        {
            Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId} Core:{Thread.GetCurrentProcessorId()} isBackground:{Thread.CurrentThread.IsBackground}");
            long ans = 0;
            for(long i = min; i <= max; i++)
            {
                ans += i;
            }
            Thread.Sleep(3000);
            
            return ans;
        }
    }
}
