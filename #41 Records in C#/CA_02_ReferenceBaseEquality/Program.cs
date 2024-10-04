namespace CA_02_ReferenceBaseEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // class is Reference Based Equality => Compare based on Reference (Memory Location)
            Student std1 = new Student(15, "Ahmed Albatrawy", 3.46m);
            Student std2 = new Student(15, "Ahmed Albatrawy", 3.46m);

            Console.WriteLine($"std1:{{{std1}}}");
            Console.WriteLine($"std2:{{{std2}}}");

            Console.WriteLine($"std1 is Equal to std2:{std1.Equals(std2)}"); // False
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
        public override string ToString()
        {
            return $"ID:{this.Id}   Name:{this.Name}    GPA:{this.GPA}";
        }
    }
}
