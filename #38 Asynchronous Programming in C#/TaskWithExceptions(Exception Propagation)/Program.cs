namespace TaskWithExceptions_Exception_Propagation_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Main Method Thread ID:{Thread.CurrentThread.ManagedThreadId}");
                Task.Run(MethodThrowException).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception Trace");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void MethodThrowException()
        {
            Console.WriteLine("Some Logic Done!!");
            Console.WriteLine("We in Method");
            Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
            throw new NullReferenceException($"Exception Thrown in Thread With ID:{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
