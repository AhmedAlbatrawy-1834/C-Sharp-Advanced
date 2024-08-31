using System.Reflection;

namespace CAReflectionAndMetadata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#################### Instantiating Types ####################*/
            do
            {
                Console.Write("Enter Enemy Name:");
                var eName = typeof(Enemy).Assembly.GetName().Name + "." + Console.ReadLine();
                object? obj = null;
                try
                {
                    var enemy = Activator.CreateInstance(typeof(Enemy).Assembly.GetName().Name, eName);
                    obj = enemy?.Unwrap();

                }
                catch
                {
                }
                switch (obj)
                {
                    case Goon g:
                        Console.WriteLine(g);
                        break;
                    case Agar a:
                        Console.WriteLine(a);
                        break;
                    case Pix p:
                        Console.WriteLine(p);
                        break;
                    default:
                        Console.WriteLine("Unknown");
                        break;
                }

            } while (true);


            /*#################### Reflecting Members ####################*/
            Console.WriteLine("Members");
            MemberInfo[] members = typeof(BankAccount).GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Private Members");
            MemberInfo[] PrivateMembers = typeof(BankAccount).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var member in PrivateMembers)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Fields");
            FieldInfo[] Fields = typeof(BankAccount).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in Fields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Properties");
            PropertyInfo[] Properties = typeof(BankAccount).GetProperties();
            foreach (var Property in Properties)
            {
                Console.WriteLine(Property);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Constructors");
            ConstructorInfo[] Constructors = typeof(BankAccount).GetConstructors();
            foreach (var Constructor in Constructors)
            {
                Console.WriteLine(Constructor);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Methods");
            MethodInfo[] Methods = typeof(BankAccount).GetMethods();
            foreach (var Method in Methods)
            {
                Console.WriteLine(Method);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Events");
            EventInfo[] Events = typeof(BankAccount).GetEvents();
            foreach (var Event in Events)
            {
                Console.WriteLine(Event);
            }
            Console.WriteLine("********************************");

            Console.WriteLine("Member by name");
            MemberInfo[] Memberss = typeof(BankAccount).GetMember(".ctor");
            foreach (var Member in Memberss)
            {
                Console.WriteLine(Member);
            }
            Console.WriteLine("********************************");




            /*#################### Invoking Members ####################*/
            var account = new BankAccount("A152", "Ahmed Albatrawy", 0);
            Type t = typeof(BankAccount);
            MethodInfo method = t.GetMethod("Deposit");
            //Type[] Parameters = { typeof(decimal) };
            method.Invoke(account, new object[] { 1500m });
            Console.WriteLine(account);

        }

        private static void Account_OnNegativeBalance(object? sender, EventArgs e)
        {
            var bankAccount = (BankAccount)sender;
            Console.WriteLine("Negative Balance!!!");

        }
    }




}
