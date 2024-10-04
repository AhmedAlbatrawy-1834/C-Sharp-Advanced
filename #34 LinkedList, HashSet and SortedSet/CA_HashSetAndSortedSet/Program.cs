namespace CA_HashSetAndSortedSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------HashSet---------------
            // HashSet: it is an unordered collection of unique elements.
            // When work with Complex Type we need override Equals() and GetHashCode() methods.

            //Constructors:-
            //HashSet<Student>students = new HashSet<Student>();     // create Empty HashSet
            //HashSet<Student> students = new HashSet<Student>(5);   // create HashSet With Capacity 5
            Student[] array =
            {
                new Student(145,"Ahmed Albatrawy",3.25m),
                new Student(146,"Mohamed Ali",2.78m),
                new Student(150,"Ahmed Ali",2.78m),
                new Student(147,"Anas Elmorsy",3.14m),
                new Student(148,"Mohamed Alaa",3.25m),
                new Student(149,"Abas Hamed",2.78m)
            };

            HashSet<Student> set = new HashSet<Student>(array); //create HashSet From Already Existed Collection
            Print(set);
            Console.WriteLine("********************************");

            // Methods:-
            //  Add(),Remove(),RemoveWhere(),Clear() زي الباقي برده  
            //ExceptWith(),IntersectWith(),UnionWith(),Overlaps(),SymmetricExceptWith()  بس في بقا العمليات على المجموعات زي الاتحاد والتقاطع والفرق وكدا 

            //--------------SortedSet-------------
            //SortedSet: it is an ordered collection of unique elements.
            //بالظبط بس مترتبة HashSet زي ال 
            //when work with complex data type you need to implement IComparable<T> to make it Sorted else you will get Exception

            //Constructors:-
            //SortedSet<Student> set2 = new SortedSet<Student>(); // create Empty SortedList
            SortedSet<Student> set2 = new SortedSet<Student>(array); //create HashSet From Already Existed Collection
            
            //Methods:-
            //Methods فبرده هتبقا نفس ال HashSet احنا قولنا انها نفس ال  

            Print(set2);

        }
        public static void Print(HashSet<Student> set)
        {
            foreach(var i in set)
            {
                Console.WriteLine(i);
            }
        }
        public static void Print(SortedSet<Student> set)
        {
            foreach (var i in set)
            {
                Console.WriteLine(i);
            }
        }
    }

    class Student:IComparable<Student>
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

        public override int GetHashCode()
        {
            int hash = 71;
            hash = hash *43 +Id.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            Student ?student = obj as Student;
            if(student is null)
                return false;
            
            return this.Id.Equals(student.Id);
        }

        public override string ToString()
        {
            return $"{{{Id}     {Name}  {GPA}}}";
        }

        public int CompareTo(Student other)
        {
            if (other is null)
                return -1;
            if (this.GPA == other.GPA)
                return this.Name.CompareTo(other.Name);
            if (this.GPA > other.GPA)
                return -1;
            return 1;
            
            
        }
    }
}
