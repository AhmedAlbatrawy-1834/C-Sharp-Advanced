using System.Text;

namespace CA_02_EncodingAndUnicode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task.Run(() => GetDataASCIIFormatAsync()).Wait();  // ASCII
            Task.Run(() => GetDataUTF8FormatAsync()).Wait();
        }

        static async Task GetDataASCIIFormatAsync()
        {
            var FilePath = @"D:\OneDrive\Desktop\C# Advanced Github Repo\#44 Strings in C#\CA_02_EncodingAndUnicode\TextFiles\ASCII.txt";
            using(var Client=new HttpClient())
            {
                Uri uri= new Uri("https://www.youm7.com/");
                using(var Response = await Client.GetAsync(uri))
                {
                    var byteArray = await Response.Content.ReadAsByteArrayAsync();
                    var Content = Encoding.ASCII.GetString(byteArray);  // Arabic Chars Not Write
                    File.WriteAllText(FilePath,Content);
                }
            }
        }

        static async Task GetDataUTF8FormatAsync()
        {
            var FilePath = @"D:\OneDrive\Desktop\C# Advanced Github Repo\#44 Strings in C#\CA_02_EncodingAndUnicode\TextFiles\UTF8.txt";
            using(var Client = new HttpClient())
            {
                Uri uri = new Uri("https://www.youm7.com/");
                using (var Response = await Client.GetAsync(uri))
                {
                    var ByteArray = await Response.Content.ReadAsByteArrayAsync();
                    var Content = Encoding.UTF8.GetString(ByteArray);  // Arabic Chars Exist
                    File.WriteAllText(FilePath,Content);
                }
            }
        }
    }
}
