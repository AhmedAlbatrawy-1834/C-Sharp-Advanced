namespace CA_03_HashCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(145, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student(145, "Ahmed Albatrawy", 3.46m);
            // std1 and std2 have 2 different Hash Code
            Console.WriteLine($"Hash Code for std1:{std1.GetHashCode()}");
            Console.WriteLine($"Hash Code for std2:{std2.GetHashCode()}\n");

            Employee Emp1 = new Employee(15, "Alaa Mohamed");
            Employee Emp2 = new Employee(15, "Alaa Mohamed");
            //Emp1 and Emp2 have the same Hash Code
            Console.WriteLine($"Hash Code for Emp1:{Emp1.GetHashCode()}");
            Console.WriteLine($"Hash Code for Emp2:{Emp2.GetHashCode()}\n");

            // Hash code for Integers Numbers is the Value of it
            Console.WriteLine($"Hash code for 1454 is:{1454.GetHashCode()}");
            Console.WriteLine($"Hash Code for 1.75 is:{1.75.GetHashCode()}");

        }
    }
    class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GPA { get; set; }
        public Student(int id, string name, decimal GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }

    struct Employee
    {
        public int Id;
        public string Name;

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
