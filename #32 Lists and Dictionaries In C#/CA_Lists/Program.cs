using System.Reflection.Metadata.Ecma335;

namespace CA_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] Students =
            {
                new Student(145,"Ahmed Albatrawy",3.15m),
                new Student(144,"Mohamed Hamed",3.25m),
                new Student(148,"Mazen Elnems",3.22m),
                new Student(140,"Fares Eldagen",3.50m)
            };

            // Lists in C#
            
            //                                      -----Constructors------

            //1- List<Student> StudentsList = new List<Student>();      //create Empty List of Students
            //2- List<Student> StudentList = new List<Student>(3);      //create Empty List of Student with Capacity 3
            List<Student> StudentList = new List<Student>(Students);    //create List of Student from already Existed Array of Student

            //                                     ------proprieties---
            // 1- Count: Return the Number of items in List
            // 2-Capacity: Return Maximum number of items the List Can Hold
            // if List Count Equals List Capacity and you add new item the List Capacity will doublicated (x2) (Capacity*=2)

            Console.WriteLine(StudentList.Capacity+" "+StudentList.Count);  // 4 4
            StudentList.Add(new Student(142, "Mohanad Ahmed", 3.55m));
            Console.WriteLine(StudentList.Capacity+" "+StudentList.Count); // 8 5

            //                                     -----Methods------
            // .Add() : use to add Single item at the end of list
            StudentList.Add(new Student(255, "Anas Elmorsy", 3.56m)); // O(1)

            // .AddRange(): use to add Array of items at the end of List
            Student[] students2 =
            {
                new Student(178,"Ahmed Mohamed",3.35m),
                new Student(188,"Issam Ali",3.89m)
            };
            StudentList.AddRange(students2); //O(n)

            // .Insert(): use to add Single item in specific index of List
            // .InsertRange(): use to add array of items in specific index of List
            StudentList.InsertRange(5, students2); // O(n) due to shifting items
            StudentList.Insert(2, new Student(255, "Ibrahim Abas", 3.21m));  // O(n) due to shifting items

            // .RemoveAt(): use to Remove single item from specific index of List
            StudentList.RemoveAt(2);

            // .Remove(): use to Remove single specific item from List but you need to override Equals() Method And GetHashCode() Method if you pass new object and compare values
            // you can pass list[index] if you want compare with reference
            StudentList.Remove(new Student(145, "Ahmed Albatrawy", 3.15m)); //pass new Object and compare with values
            //StudentList.Remove(StudentList[1]); // pass list[index] and compare with reference


            // .RemoveAll(): use to Remove All items that match the Condition take Generic Delegate Predicate<T>
            StudentList.RemoveAll(x => x.GPA > 3.50m);

            // .RemoveRange(): use to Remove Range of items From List take start index and number of items you need remove
            StudentList.RemoveRange(0, 2); // from index 0 remove 2 items

            // .Clear(): use to remove All items in List
            //StudentList.Clear();

            // .Contains(): return True if Specific item is exist in List else return False and but you need to override Equals() Method And GetHashCode() Method if you pass new object and compare values
            // you can pass list[index] if you want compare with reference
            Print(StudentList);
            Console.WriteLine(StudentList.Contains(new Student(178, "Ahmed Mohamed", 3.35m))); //pass new Object and compare with values
            //Console.WriteLine(StudentList.Contains(StudentList[1])); // pass list[index] and compare with reference

            // .CopyTo(): use to copy items in list to an one dimensional array and .ToArray() method Do the Same thing
            var array = new Student[StudentList.Count];
            var array2 = StudentList.ToArray();
            StudentList.CopyTo(array);

            // .Sort(): use to sort List and if List is complex type you need to implement IComparer<T> interface and implement Compare() method


            // and more useful methods
        }
        public static void Print(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        
    }
    public class Student
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
            return $"{{ ID:{Id}    Name:{Name}     GPA:{GPA} }}";
        }

        public override bool Equals(object? obj)
        {
            Student student = obj as Student;
            if (student is null)
                return false;
            return this.Id.Equals(student.Id)
                    && this.Name.Equals(student.Name)
                    && this.GPA.Equals(student.GPA);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 23 + this.Id.GetHashCode();
                hash = hash * 23 + this.Name.GetHashCode();
                hash = hash * 23 + this.GPA.GetHashCode();
                return hash;
            }

        }
    }
}
