namespace LongRunningTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(ShortTask) ;   // Short Task Use Thread Pool
            task.Wait(); // To Block Main Thread Until Task Done Because Task use Background Thread

            Console.WriteLine("-----------------------------------------------");

            var task2 = Task.Factory.StartNew(LongTask,TaskCreationOptions.LongRunning);  // Long Task Dont Use Thread Pool
            task2.Wait(); // To Block Main Thread Until Task Done Because Task use Background Thread
        }

        static void LongTask()
        {
            Thread.Sleep(5000);
            DisplayThreadInfo(Thread.CurrentThread);
            Console.WriteLine(" Long Task Completed");
        }
        static void ShortTask()
        {
            DisplayThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Short Task Completed");
            

        }

        static void DisplayThreadInfo(Thread th)
        {
            Console.WriteLine($"ID:{th.ManagedThreadId} Pooled:{th.IsThreadPoolThread} Background:{th.IsBackground}");
        }
    }
}
