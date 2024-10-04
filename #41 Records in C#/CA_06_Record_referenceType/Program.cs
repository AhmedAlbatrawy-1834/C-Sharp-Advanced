namespace CA_06_Record_referenceType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(145, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student(145, "Ahmed Albatrawy", 3.46m);
            //Override ToString()
            Console.WriteLine(std1);
            Console.WriteLine(std2);

            Console.WriteLine("------------------------");

            //override Equals
            Console.WriteLine($"std1.Equals(std2):{std1.Equals(std2)}");

            Console.WriteLine("------------------------");

            //override == , !=
            Console.WriteLine($"(std1 == std2):{(std1==std2)}");
            Console.WriteLine($"(std1 != std2):{(std1 != std2)}");




        }
    }

    //override Object Equals
    // Implement IEquatable<T> => (IEquatable<Student>)
    // override Object GetHashCode()
    // override == , != 
    // override object ToString()

    record Student //record Student == record class Student 
    {
        public int Id;
        public string Name;
        public decimal GPA;

        public Student(int id, string name, decimal GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }
}
