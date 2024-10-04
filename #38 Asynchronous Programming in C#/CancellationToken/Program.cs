namespace CancellationToken
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                await UploadOperation(cts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            
            
        }

        static async Task UploadOperation(CancellationTokenSource cts)
        {
            Console.WriteLine("Note: If You want Cancel Enter Q");
            Thread.Sleep(2000);
            Console.Clear();
            Task.Run(() =>
            {
                var input= Console.ReadKey();
                if(input.Key== ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("\nOperation Canceled Successfully");
                }
            });
            try
            {
                int num = 1;
                while (!cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine($"Operation number {num} is Running......");
                    await Task.Delay(4000,cts.Token);
                    Console.WriteLine($"Operation number {num++} Completed at:{DateTime.Now}");
                }

            }
            catch(TaskCanceledException ex)
            {
                throw ex;
            }

            //Console.WriteLine("Operation Terminated");
        }
    }
}
