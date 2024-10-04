namespace CA_04_InternPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Ahmed";  // string literal
            string str3 = "Ahmed";  // string literal
            string str2 = new string("Ahmed");  // string object

            Console.WriteLine($"{nameof(str1)} is string literal with value:\"{str1}\"");
            Console.WriteLine($"{nameof(str2)} is string literal with value:\"{str2}\"");
            Console.WriteLine($"{nameof(str3)} is string object  with value:\"{str3}\"");


            Console.WriteLine($"{nameof(str1)}=={nameof(str2)} : {str1==str2}"); //true same content
            Console.WriteLine($"{nameof(str2)}=={nameof(str3)} : {str2 == str3}"); // true same content

            Console.WriteLine($"{nameof(str1)} and {nameof(str2)} has same reference:{String.ReferenceEquals(str1,str2)}"); // true same reference 
            Console.WriteLine($"{nameof(str2)} and {nameof(str3)} has same reference:{String.ReferenceEquals(str2, str3)}"); // false different reference 
            Console.WriteLine("------------------------------------------------");

            str2 = "Mohamed";
            Console.WriteLine($"{nameof(str1)} is string literal with value:\"{str1}\"");
            Console.WriteLine($"{nameof(str2)} is string literal with value:\"{str2}\"");

            Console.WriteLine($"{nameof(str1)}=={nameof(str2)} : {str1 == str2}"); //false different content
            Console.WriteLine($"{nameof(str1)} and {nameof(str2)} has same reference:{String.ReferenceEquals(str1, str2)}"); // false  different reference 
            Console.WriteLine("-------------------------");

            InternMethodRegion();


        }
        #region InternMethod
        static void InternMethodRegion()
        {
            string str1 = "Ahmed";
            string str2 = new string("Ahmed");
            string str3 = String.Intern(str2);
            Console.WriteLine($"{nameof(str1)} is string literal with value:\"{str1}\"");
            Console.WriteLine($"{nameof(str2)} is string object with value:\"{str2}\"");
            Console.WriteLine($"{nameof(str3)} is string literal from Intern(str2)  with value:\"{str3}\"");

            Console.WriteLine($"{nameof(str1)}=={nameof(str2)} : {str1 == str2}"); //true same content
            Console.WriteLine($"{nameof(str1)} and {nameof(str2)} has same reference:{String.ReferenceEquals(str1, str2)}"); // false  different reference 

            Console.WriteLine($"{nameof(str2)}=={nameof(str3)} : {str2 == str3}"); //true same content
            Console.WriteLine($"{nameof(str2)} and {nameof(str3)} has same reference:{String.ReferenceEquals(str2, str3)}"); // false  different reference 

            Console.WriteLine($"{nameof(str1)}=={nameof(str3)} : {str1 == str3}"); //true same content
            Console.WriteLine($"{nameof(str1)} and {nameof(str3)} has same reference:{String.ReferenceEquals(str1, str3)}"); // true same  reference 


        }
        #endregion
    }
}
