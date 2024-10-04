using System.Diagnostics;

namespace ConcurrencyAndParallelism
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var duties = new List<DailyDuty>
            {
                new DailyDuty("Learn C#"),
                new DailyDuty("Watch Aqeda Video"),
                new DailyDuty("Solve Some Problems"),           // each Duty Take 3000 ms
                new DailyDuty("Clean my Room"),
                new DailyDuty("Read Algorithms Book")
            };
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Using Concurrency Processing");
            await ProcessingInConcurrency(duties);
            sw.Stop();
            Console.WriteLine($"Total Time:{sw.ElapsedMilliseconds} ms");
            sw.Restart();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Using Parallel Processing");
            sw.Start();
            await ProcessingInParallel(duties);
            sw.Stop();
            Console.WriteLine($"Total Time:{sw.ElapsedMilliseconds} ms");








        }

        static Task ProcessingInConcurrency(List<DailyDuty> dutyList)  // Take 3000 * NumberOfDuties ms
        {
            foreach(var duty in dutyList)
            {
                duty.Process();
            }
            return Task.CompletedTask;
        }

        static Task ProcessingInParallel(List<DailyDuty> dutyList) // Take 3000 * 1 ms
        {
            Parallel.ForEach(dutyList, (duty) =>duty.Process());
            return Task.CompletedTask;
        }
    }

    class DailyDuty
    {
        public string Title { get; private set; }
        public bool Completed{ get; private set; }

        public DailyDuty(string title)
        {
            Title = title;
            Completed = false;
        }

        public void Process()
        {
            Completed = true;
            Task.Delay(3000).Wait();
            Console.Write($"Title:{this.Title}  ");
            Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}  Processor ID:{Thread.GetCurrentProcessorId()}");
            

        }
    }
}
