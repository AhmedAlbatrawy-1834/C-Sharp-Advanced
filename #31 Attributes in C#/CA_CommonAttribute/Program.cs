using System.Diagnostics;

namespace CA_CommonAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[Obsolete]  marks the code elements that are obsolete i.e. not in use anymore. 
            AnyClass.OldMethod();
            Console.WriteLine();
            // [Flags] The FlagsAttribute specifies that an enumeration can be used as a set of flags.
            FilePermissions Access =(FilePermissions.Read | FilePermissions.Write);
            Console.WriteLine(Access);
            Console.WriteLine();
            //[DebuggerDisplay] To  the way to display the element at debugging.
            List<Student> students = new List<Student>()
            {
                new Student(1451,"Ahmed Albatrawy",20,3.2m),
                new Student(1452,"Ali Ahmed",22,2.8m),
                new Student(14542,"Omar Alaa",23,3.15m)
            };

            foreach(var student in students)
            {
                Console.WriteLine(student);
            }

        }
    }
    public static class AnyClass
    {
        [Obsolete("Use NewMethod instead.",false)]               //give Warning...
        //[Obsolete("This method No longer supported",true)]     //give compiler error...
        public static void OldMethod()
        {
            Console.WriteLine("Old Method");
        }
        public static void NewMethod() 
        {
            Console.WriteLine("New Method!!!");
        }
    }

    [Flags]
    public enum FilePermissions :short
    {
        none=0,
        Execute=1,
        Write=2,
        Read=4
    }

    [DebuggerDisplay("ID:{Id}   Name:{Name}     GPA:{GPA}")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GPA {  get; set; }
        public int Age { get; set; }

        public Student(int id, string name,int Age, decimal GPA)
        {
            Id = id;
            Name = name;
            this.Age = Age;
            this.GPA = GPA;
        }
        public override string ToString()
        {
            return $"ID:{Id}   Name:{Name}  Age:{Age}     GPA:{GPA}";
        }
    }
}
