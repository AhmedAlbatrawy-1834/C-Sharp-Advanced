using System.Reflection.Emit;
namespace CA_XML_Documentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {

                Console.Write("First Name:");
                var fname = Console.ReadLine();
                Console.Write("Last Name:");
                var lname = Console.ReadLine();

                Console.Write("Hire Date:");
                DateTime? HireDate = null;
                if (DateTime.TryParse(Console.ReadLine(), out DateTime HDate))
                {
                    HireDate = HDate;
                }
                var Id = Generator.GenerateId(fname, lname, HireDate);
                var Password = Generator.GeneratePassword(8);

                Console.WriteLine($"{{\n Id:{Id},\n FName:{fname},\n LName:{lname},\n HireDate:{HireDate.Value.ToShortDateString()},\n Password:{Password}\n}}");
            } while (true);

        }
    }
}
