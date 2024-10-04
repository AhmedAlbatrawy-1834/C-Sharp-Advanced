namespace AsyncFunction_async_await
{
    internal class Program
    {
        static async Task Main(string[] args)   // async Task == void
        {
            // -- 1 --
            // Old Use 
            //var task = Task.Run(() => ReadContent("https://www.google.com/"));
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    Console.WriteLine(awaiter.GetResult());
            //});
             //Console.ReadKey();

            // -- 2 -- 
            // New Use
            var content = await ReadContentAsync("https://www.google.com/");
            Console.WriteLine(content);
        }

        static Task<string> ReadContent(string url)  // Return Task<string> 
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(url);

            return task;
        }
        // static async string ReadContentAsync(string url) // Return String Value
        static async Task<string> ReadContentAsync(string url)  // Promise To Return String Value
        {
            var client = new HttpClient();

            var task = client.GetStringAsync(url);   //Return Task<string> 
            DoSomething();   
            var content = await task;

            return content;
        }

        static void DoSomething()
        {
            Console.WriteLine("Do Something....");
        }
    }

}
