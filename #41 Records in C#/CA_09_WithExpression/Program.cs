namespace CA_09_WithExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std1 = new Student(14, "Ahmed Albatrawy", 3.65m);
            Student std2 = new Student(15, "Alaa Hamed", std1.GPA); // not recommended 
            Student std3 = std1 with { Id = 15, Name = "Alaa Hamed" }; // recommended

            Console.WriteLine(std1+"\n");
            Console.WriteLine(std2+"\n");
            Console.WriteLine(std3);

        }
    }
    record Student(int Id, string Name, decimal GPA);
}
