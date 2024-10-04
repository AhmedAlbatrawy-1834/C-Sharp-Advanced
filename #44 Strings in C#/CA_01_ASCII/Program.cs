namespace CA_01_ASCII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string header = String.Format("{0,-12} {1,-12} {2,-12} {3,-12}", "Decimal", "HEX", "Binary", "Character");
            Console.WriteLine(header);
            Console.WriteLine("------------------------------------------------");
            for(int i = 0; i <= 255; i++)
            {
                var ch = (char)i;
                var Dec = i.ToString().PadLeft(3,'0');
                var Bin = Convert.ToString(i, 2).PadLeft(8, '0');
                var Hex = i.ToString("X");

                Console.WriteLine($"{Dec,-12} {Hex,-12} {Bin,-12} {ch,-12}");
            }
        }
    }
}
