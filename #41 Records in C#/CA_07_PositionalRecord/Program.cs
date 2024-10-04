namespace CA_07_PositionalRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(145, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student { Id = 145, Name = "Ahmed Albatrawy", GPA = 3.46m };

            //std1.Name = "Alaa Hamed"; // CompileTime Error Because Positional Record is Immutable

            Console.WriteLine($"std1:{{{std1}}}");
            Console.WriteLine($"std2:{{{std2}}}");

            var (id, name, gpa) = std2;  // deconstructing
            Console.WriteLine($"\nstd2: id={id}, name:{name}, gpa:{gpa}");


        }
    }
    //Immutable
    //Constructor
    //Deconstruct
    //cant use Object initializer

     // Positional Record this form not support Object initializer
    //record Student(int Id,string Name,decimal GPA); 

    //Positional Record this form support Object initializer
    record Student(int Id, string Name, decimal GPA) 
    {
        public Student():this(0,"",0)
        {

        }
    }
}
