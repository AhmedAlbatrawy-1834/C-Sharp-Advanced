namespace CAExtensionMethos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine($"Current DateTime:{dt}");
            Console.WriteLine("********************************");
            // With Extension Method
            Console.WriteLine($"Is Weekend:{dt.IsWeekEnd()}"); // we can also do DateTimeExtension.IsWeekEnd(dt)
            Console.WriteLine($"Is WorkDay:{dt.IsWorkDay()}"); // we can also do DateTimeExtension.IsWorkDay(dt)
            Console.WriteLine("********************************");
            // With Old Style Helper Class
            Console.WriteLine($"Is Weekend:{DateTimeHandler.IsWeekEnd(dt)}");
            Console.WriteLine($"Is WorkDay:{DateTimeHandler.IsWorkDay(dt)}");

        }
    }
}
