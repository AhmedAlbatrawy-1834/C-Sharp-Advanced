using System.Diagnostics.CodeAnalysis;

namespace CA_Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ctors

            //Dictionary<Project, Employee> projects = new Dictionary<Project, Employee>();     // Empty
            Dictionary<Project, Employee> projects = new Dictionary<Project, Employee>(new Comparer());  // IEualityComparer<T>.

            // Add()            Takes O(1) if the current capacity less than count otherwise Takes O(n).
            projects.Add(new Project(100, "WebSite"), new Employee(1, "ahmed", 10000));
            projects.Add(new Project(101, "MobileApp"), new Employee(2, "mohamed", 10000));
            projects.Add(new Project(102, "Game"), new Employee(3, "ali", 10000));
            projects.Add(new Project(103, "DesktopApp"), new Employee(4, "khaled", 10000));

            // projects.Add(new Project(103, "DesktopApp"), new Employee(4, "khaled", 10000));
            // Try to add a duplicate key => Exception.

            // TryAdd()
            bool added = projects.TryAdd(new Project(103, "DesktopApp"), new Employee(4, "khaled", 10000));

            if (added)
                Console.WriteLine("Entry Added Successfully");
            else
                Console.WriteLine("Can't added");


            // Remove()            Takes O(1)   due to fast access by hash value
            projects.Remove(new Project(102, "Game"));

            // ContainsKey()            // Takes O(1)
            bool exists = projects.ContainsKey(new Project(103, "DesktopApp"));

            if (exists)
                Console.WriteLine("The Key Exists");

            // [T key] indexer      Takes O(1)
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{Id,-4} {Name,-15} {Salary,-8}";
        }
    }

    class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Project(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Id,-5} {Name,-10}";
        }
    }

    /// <summary>
    /// Provide value Equality.
    /// </summary>
    class Comparer : IEqualityComparer<Project>
    {
        public bool Equals(Project? x, Project? y)
        {
            return x?.Id == y?.Id && x?.Name == y?.Name;
        }

        public int GetHashCode([DisallowNull] Project obj)
        {
            int hash = 13;
            hash = hash * 31 + obj.Id.GetHashCode();
            hash = hash * 31 + obj.Name.GetHashCode();
            return hash;
        }
    }
}
