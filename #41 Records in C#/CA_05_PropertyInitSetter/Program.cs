namespace CA_05_PropertyInitSetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(145, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student()  //Object Initializer
            {
                Id=44,
                Name="Mohamed Ali",
                GPA=3.15m
            };

            Console.WriteLine($"std1:{{{std1}}}");
            Console.WriteLine($"std2:{{{std2}}}");

            // std2.Name = "Alaa Hamed";  CompileTime Error Because we use init

            // using init in property make property Immutable and  allow to use object initializer
        }
    }
    class Student : IEquatable<Student>
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public decimal GPA { get; init; }
        public Student() 
        { 
            
        }
        public Student(int id, string name, decimal GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
        public bool Equals(Student? std)  
        {
            if (std is null)
                return false;
            return this.Id == std.Id && this.Name == std.Name;
        }
        public override bool Equals(object? obj)
        {
            Student? std = obj as Student;
            return this.Equals(std);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Name);  
        }

        public static bool operator ==(Student? lhs, Student? rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Student? lhs, Student? rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return $"ID:{this.Id}   Name:{this.Name}    GPA:{this.GPA}";
        }

    }
}
