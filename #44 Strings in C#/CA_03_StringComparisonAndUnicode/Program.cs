namespace CA_03_StringComparisonAndUnicode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"D:\OneDrive\Desktop\C# Advanced Github Repo\#44 Strings in C#\CA_03_StringComparisonAndUnicode\TextFile\OutPut.txt");
            string char1 = "\u0061\n";  // a
            string char2 = "\u0308";  // ̈ 
            sw.WriteLine(char1);
            sw.WriteLine(char2);

            sw.WriteLine("--------------");
            string char3 = "\u0061\u0308"; // ä
            sw.WriteLine(char3);

            sw.WriteLine("--------------");
            string char4 = "\u00e4"; // ä
            sw.WriteLine(char4);
            sw.WriteLine("--------------");

            sw.WriteLine($"{char3} == {char4}  (Culture-Sensitive):" +
                $"{String.Equals(char3, char4, StringComparison.CurrentCulture)}"); // Printing 
            sw.WriteLine("--------------");

            sw.WriteLine($"{char3} == {char4}  (Ordinal):" +
                $"{String.Equals(char3, char4, StringComparison.Ordinal)}"); // Numeric value
            sw.WriteLine("--------------");

            sw.WriteLine($"{char3} == {char4}  (Normalization ordinal):" +
                $"{String.Equals(char3.Normalize(), char4.Normalize(), StringComparison.Ordinal)}");
            sw.WriteLine("--------------");

            sw.Close();

        }
    }
}
