using System.Runtime.InteropServices;
using System.Text;

namespace CA_01_StringVsStringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UsingString());
            Console.WriteLine(UsingStringBuilder());
        }

        static string UsingString()
        {
            string str;  //default is null

            str = String.Concat(new char[] { 'a', 'h', 'm' }); //create new object in Memory

            str += "edxyz Albatrawy";  // create new object in Memory

            str = str.Remove(5, 3); // remove xyz create new object in Memory
            str = str.Remove(0,1);  

            str= "A"+str; //create new object in Memory

            return str;

        }

        static string UsingStringBuilder()
        {
            StringBuilder sb = new StringBuilder(); // default is Empty String ("")  create new object in Memory

            sb.Append(new char[] { 'a', 'h', 'm' });  // use the object that in the memory (Not create new object in memory)

            sb.Append("edxyz Albatrawy");       // use the object that in the memory (Not create new object in memory)

            sb.Remove(5, 3);       // use the object that in the memory (Not create new object in memory)

            sb.Remove(0, 1);       // use the object that in the memory (Not create new object in memory)

            sb.Insert(0, 'A');       // use the object that in the memory (Not create new object in memory)

            return sb.ToString();
        }
    }
}
