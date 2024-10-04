namespace CA_04_OverrideEqualsAndGetHashCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(145, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student(145, "Ahmed Albatrawy", 3.46m);

            Console.WriteLine($"std1:{{{std1}}}");
            Console.WriteLine($"std2:{{{std2}}}");

            //Default Equals() Work with Reference (Memory Location)
            //Console.WriteLine("Before Override Equals");
            //Console.WriteLine($"std1.Equals(std2) : {std1.Equals(std2)}");    // False 

            Console.WriteLine("After Override Equals");
            Console.WriteLine($"std1.Equals(std2) : {std1.Equals(std2)}");      // True
            // == by default is Reference based Equality so we need to overload operator ==
            Console.WriteLine($"std1 == std2 :{std1 == std2}");                 // True
            Console.WriteLine($"std1 != std2 :{std1 != std2}");                 // False

            var students = new Dictionary<Student, string>();
            students.Add(std1, "Some String....");
            //students.Add(std2, "Some String...."); // RunTime Error (Exception)
                                                   // System.ArgumentException: An item with the same key has already been added.
        }
    }
    class Student : IEquatable<Student>
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
        public bool Equals(Student? std)  // not need Casting
        {
            if (std is null)
                return false;
            return this.Id == std.Id && this.Name == std.Name;   // determine with ID and Name only
        }
        public override bool Equals(object? obj)
        {
            Student? std = obj as Student;
            return this.Equals(std);
        }
        public override int GetHashCode()
        {
            //int hash = 17;                                
            //hash = hash * 23 + this.Id.GetHashCode();      
            //hash = hash * 23 + this.Name.GetHashCode();   
            //return hash;

            return HashCode.Combine(this.Id, this.Name);  // another implementation
        }

        public static bool operator==(Student? lhs, Student? rhs)
        {
            if(lhs is null)
            {
                if(rhs is null)
                {
                    return true;
                }

                return false;
            }
            return lhs.Equals(rhs);
        }
        public static bool operator!=(Student? lhs, Student? rhs)
        {
            return !(lhs==rhs);
        }

        public override string ToString()
        {
            return $"ID:{this.Id}   Name:{this.Name}    GPA:{this.GPA}";
        }

    }
}
