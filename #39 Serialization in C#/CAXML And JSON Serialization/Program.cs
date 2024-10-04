using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;

namespace CAXML_And_JSON_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Std1 = new Student
            {
                Id = 2545,
                FName = "Abass",
                LName = "Mohamed",
                GPA = 2.12m,
                FailsSubjects = { "DataBase", "Introduction in AI", "Math in Computer Science" }
            };
            Console.WriteLine("XML Serialization and Deserialization");
            var XML_str = XMLSerializationAsString(Std1);
            //File.WriteAllText("XMLFile.xml", str);  //Write Content in Xml File in path:"D:\OneDrive\Desktop\C# Advanced Github Repo\#39 Serialization in C#\CAXML And JSON Serialization\bin\Debug\net8.0\XMLFile.xml"
            Console.WriteLine(XML_str);

            var XMLContent = File.ReadAllText("XMLFile.xml");
            var std2 = XMLDeserializationFromString<Student>(XMLContent);
            Console.WriteLine("-------------------------------------------------");


            Console.WriteLine("JSON Serialization and Deserialization");
            var JSON_str = JSONSerializationAsString(Std1);
            //File.WriteAllText("JSONFile.json", JSON_str);  //Write Content in Json File in path:"D:\OneDrive\Desktop\C# Advanced Github Repo\#39 Serialization in C#\CAXML And JSON Serialization\bin\Debug\net8.0\JSONFile.json"
            Console.WriteLine(JSON_str);

            var JSONContent = File.ReadAllText("JSONFile.json");
            var std3 = JSONDeserializationFromString<Student>(JSONContent);
            Console.ReadKey();


        }
        #region XML Serialization
        static string XMLSerializationAsString<T>(T Obj) where T : class  // Generic To Can Work With all Types
        {
            var Result = "";
            var XMLSerializer = new XmlSerializer(Obj.GetType());
            using(var sw =new StringWriter())
            {
                using(var writer=XmlWriter.Create(sw,new XmlWriterSettings { Indent=true,IndentChars="...." }))
                {
                    XMLSerializer.Serialize(writer, Obj);
                    Result = sw.ToString();
                }
            }
            return Result;
        }
        #endregion

        #region XML Deserialization
        static T XMLDeserializationFromString<T>(string Content) where T :class   // Generic To Can Work With all Types
        {
            T? Obj = null;
            var XMLSerializer = new XmlSerializer(typeof(T));
            using(TextReader reader = new StringReader(Content))
            {
                Obj=XMLSerializer.Deserialize(reader) as T;
            }
            return Obj;

        }
        #endregion

        #region JSON Serialization
        static string JSONSerializationAsString<T>(T Obj)
        {
            var Result = "";
            Result = JsonSerializer.Serialize(Obj, new JsonSerializerOptions { WriteIndented = true });
            return Result;
        }
        #endregion

        #region JSON Deserialization
        static T JSONDeserializationFromString<T>(string content)
        {
            var Obj = JsonSerializer.Deserialize<T>(content);
            return Obj;
        }
        #endregion


    }
}
