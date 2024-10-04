namespace TaskProgress
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Action<int> dlg = (n) =>
            {
                Console.Clear();
                Console.WriteLine($"{n}%");
            };

            await UploadFile(dlg);
        }

        static async Task UploadFile(Action<int> UploadProgress)
        {
            for(int i = 0; i <= 100; i++)
            {
                if (i % 10 == 0)
                {
                    await Task.Delay(500);
                    UploadProgress(i);
                }
            }

            Console.WriteLine("File Uploaded Successfully");
        }
    }
}
