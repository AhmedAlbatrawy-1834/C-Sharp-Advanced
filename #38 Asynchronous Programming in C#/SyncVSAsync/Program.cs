namespace SyncVSAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread, nameof(Main), 7);
            SynchronousOperation();   // block Thread

            ShowThreadInfo(Thread.CurrentThread, nameof(Main), 10);

            AsynchronousOperation(); // Not Block Thread

            ShowThreadInfo(Thread.CurrentThread, nameof(Main), 14);
            Console.WriteLine("Some Work in Main....\n");

            Console.ReadKey();


        }

        static void SynchronousOperation()
        {
            ShowThreadInfo(Thread.CurrentThread,nameof(SynchronousOperation),24);
            Console.WriteLine($"{nameof(SynchronousOperation)} Start Working....\n");
            Thread.Sleep(5000);
            Console.WriteLine($"{nameof(SynchronousOperation)} Complete Work\n");
        }

        static void AsynchronousOperation()
        {
            ShowThreadInfo(Thread.CurrentThread,nameof(AsynchronousOperation),32);
            Console.WriteLine($"{nameof(AsynchronousOperation)} Start Working....\n");
            Task.Delay(5000).GetAwaiter().OnCompleted(() => 
            {
                ShowThreadInfo(Thread.CurrentThread, nameof(AsynchronousOperation), 36);
                Console.WriteLine($"{nameof(AsynchronousOperation)} Complete its Work\n");
            });
        }

        static void ShowThreadInfo(Thread th,string MethodName,int Line)
        {
            Console.WriteLine($"Line# {Line} MethodName:{MethodName} Thread Id:{th.ManagedThreadId} Pooled:{th.IsThreadPoolThread} Background:{th.IsBackground}\n");
        }
    }
}
