using System.Runtime.CompilerServices;

namespace CA_02_ValueTuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValueTuple<string, string> t1 = new ValueTuple<string, string>("Ahmed Albatrawy", "CS"); // Form 1
            ValueTuple<string, string> t2 = ValueTuple.Create("Mazen Elnems", "IS");   // Form 2
            Console.WriteLine(t2);
            (string, string) t3 = new("Eslam Sheha", "IS");   // Form 3
            Console.WriteLine(t3);
            (string, string) t4 = new ValueTuple<string, string>("Mohamed Hamed", "CS");   // Form 4
            Console.WriteLine(t4);

            var t5 = CreateTupleV1();
            Console.WriteLine($"{t5.Item1}  {t5.Item2}");

            var t6 = CreateTupleV2();
            Console.WriteLine($"{t6.Name}  {t6.Department}");

            //var (Name, Depart) = t5;   //work  // Deconstructing
            //(var Name, var Depart) = t5;  //work  // Deconstructing
            //(var Name, string Depart) = t5;//work but not recommended  // Deconstructing
            (string Name, string Depart) = t5; //work  // Deconstructing

            Console.WriteLine($"{Name}   {Depart}");


        }
        //IsImplicit Names  (item1,item2)
        static (string, string) CreateTupleV1()
        {
            return ("Ahmed Albatrawy", "CS");
        }

        //Explicit Names
        static (string Name,string Department) CreateTupleV2()
        {
            return ("Ahmed Albatrawy", "CS");
        }
    }
}
