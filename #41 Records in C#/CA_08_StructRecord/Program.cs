namespace CA_08_StructRecord
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
            Console.WriteLine();

            

            std1.Name = "Alaa Hamed"; // mutable

            Console.WriteLine(std1);
            Console.WriteLine(std2);
        }
    }
    // struct record by default is mutable
    // value type => store in Stack Memory
    record struct Student  
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

    readonly record  struct StudentV2  // readonly struct record (Immutable)
    {
        public readonly int Id;
        public readonly string Name;
        public readonly decimal GPA;

        public StudentV2(int id, string name, decimal GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }

    record struct StudentV3(int id, string name, decimal GPA); // Positional struct record
    readonly record struct StudentV4(int id, string name, decimal GPA); // Positional struct record



}
