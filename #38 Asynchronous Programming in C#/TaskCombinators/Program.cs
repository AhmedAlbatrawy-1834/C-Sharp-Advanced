namespace TaskCombinators
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var Has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
            var Has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
            Console.WriteLine("Using WhenAny()");
            Console.WriteLine("------------------------");
            var any =await Task.WhenAny(Has1000SubscriberTask, Has4000ViewHoursTask);
            Console.WriteLine(any.Result);

            Console.WriteLine("Using WhenAll()");
            Console.WriteLine("------------------------");
            var all = await Task.WhenAll(Has1000SubscriberTask,Has4000ViewHoursTask);
            foreach (string task in all)
            {
                Console.WriteLine(task);
            }


        }
        static Task<string> Has1000Subscriber()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("Congratulation !! You Have 1000 Subscribers");
        }
        static Task<string> Has4000ViewHours()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("Congratulation !! You Have 4000 View Hours");
        }
    }
}
