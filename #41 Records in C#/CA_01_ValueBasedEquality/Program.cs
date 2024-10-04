namespace CA_01_ValueBasedEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // struct is Value based Equality 
            // (int,long,decimal,....) all numeric types are struct then they are Value Based Equality
            Student std1 = new Student(15,"Ahmed Albatrawy",3.46m);
            Student std2 = new Student(15,"Ahmed Albatrawy",3.46m);

            Console.WriteLine($"std1:{{{std1}}}");
            Console.WriteLine($"std2:{{{std2}}}");

            Console.WriteLine($"std1 is Equal to std2:{std1.Equals(std2)}"); // True
        }
    }

    struct Student
    {

        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal GPA {  get; set; }
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
