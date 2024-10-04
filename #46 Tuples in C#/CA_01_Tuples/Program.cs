namespace CA_01_Tuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, string> t1 = new Tuple<string, string>("Ahmed Albatrawy","CS"); // Form 1
            Tuple<string, string> t2 = Tuple.Create("Ahmed Albatrawy", "CS"); // Form 2

            var type = typeof(Tuple<string, string>);
            if (type.IsValueType)
            {
                Console.WriteLine("IS Value Type");
            }
            else
            {
                Console.WriteLine("Is Reference Type");
            }
            Console.WriteLine("-------------------------------------");
            if (Tuple.ReferenceEquals(t1, t2))
            {
                Console.WriteLine("t1 and t2 have Same reference");
            }
            else
            {
                Console.WriteLine("t1 and t2 have 2 different refences");
            }
            Console.WriteLine("-------------------------------------");

            // tuple is immutable type
            // t1.Item1="Alaa"   Compiler Error

            if (t1.Equals(t2)) // t1==t2 Not work here
            {
                Console.WriteLine("t1 and t2 have same values");
            }
            else
            {
                Console.WriteLine("t1 and t2 have 2 different values");
            }
        }
    }
}
