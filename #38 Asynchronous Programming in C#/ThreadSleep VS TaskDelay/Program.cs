namespace ThreadSleep_VS_TaskDelay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ThreadSleep(5000);
            TaskDelay(5000);

            Console.ReadKey();
        }

        static void TaskDelay(int ms)
        {
            // Wrong Use
            //Task.Delay(ms); // not Block Thread and Delay Return Task we Can Use It
            //Console.WriteLine($"Completed after:{ms} ms");

            // Correct Use
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Completed after:{ms} ms");
            });

            // another Correct Use
            //Task.Delay(ms).ContinueWith((s) =>
            //{
            //    Console.WriteLine($"Completed after:{ms} ms");
            //});

            //Task.Delay(ms).Wait(); == Thread.Sleep(ms);
        }

        static void ThreadSleep(int ms)
        {
            Thread.Sleep(ms); // Block Thread
            Console.WriteLine($"Completed after:{ms} ms");

        }
    }
}
