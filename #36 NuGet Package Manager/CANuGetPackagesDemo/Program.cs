using Humanizer;
using IDGeneratorSystem;
using IDGeneratorSystem.Models;
using System.Reflection.Emit;

namespace CANuGetPackagesDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Employees = new List<Employee>
            {
                new Employee(IDGenerator.GenerateId(JopPositions.Engineer),"Ahmed Albatrawy",new DateTime(2022,9,9,10,50,00),5000.95m),
                new Employee(IDGenerator.GenerateId("Reem","Mohamed"),"Reem Mohamed",new DateTime(2024,8,1,8,30,00),5000.95m),
                new Employee(IDGenerator.GenerateId(JopPositions.Employee),"Alaa Hamed",new DateTime(2023,2,9,9,20,00),5000.95m),
                new Employee(IDGenerator.GenerateId(JopPositions.Doctor),"Omar Alaa",new DateTime(2024,3,9,5,00,00),5000.95m),
            };

            foreach (Employee emp in Employees)
            {
                Console.WriteLine(emp);
            }
        }
    }

    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfHiring { get; set; }
        public decimal Salary { get; set; }

        public Employee(string id, string name, DateTime dateOfHiring, decimal salary)
        {
            Id = id;
            Name = name;
            DateOfHiring = dateOfHiring;
            Salary = salary;
        }
        public override string ToString()
        {
            return $"{{\nID:{Id}\nName:{Name}\nSalary:{Salary}\nHiring:{DateOfHiring.Humanize()}\n}}";
        }
    }

}
