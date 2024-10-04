using System.Text.Json;

namespace CA_JSONSerializerAndHttpClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var content =await client.GetStringAsync("https://jsonplaceholder.typicode.com/albums");
            var albums = JsonSerializer.Deserialize<List<Album>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Print Only 10 Albums
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(albums[i]);
                Console.WriteLine("-----------------------");

            }
            
        }
    }


    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"User ID: {UserId}\n" +
                   $"Album ID: {Id}\n" +
                   $"Album Title: {Title}\n";
        }
    }


}
