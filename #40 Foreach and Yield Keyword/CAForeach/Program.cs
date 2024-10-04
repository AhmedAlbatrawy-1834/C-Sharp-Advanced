
namespace CAForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            Console.WriteLine("Using Normal For");
            Console.Write("Items:");
            for(int i = 0; i < list.Count(); i++)
            {
                Console.Write($" {list[i]}");
            }
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Using Foreach");
            Console.Write("Items:");
            foreach(var n in list)
            {
                Console.Write($" {n}");
            }
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Using ForeachUnderTheHood V1");
            Console.Write("Items:");
            ForeachUnderTheHoodV1(list);
            Console.WriteLine("\n-----------------------");
            Console.WriteLine("Using ForeachUnderTheHood V2");
            Console.Write("Items:");
            ForeachUnderTheHoodV2(list);
            Console.WriteLine();

        }

        // The compiler generate the body of this method to execute foreach
        private static void ForeachUnderTheHoodV1<T>(IEnumerable<T> list) 
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Console.Write($" {enumerator.Current}");
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }

        private static void ForeachUnderTheHoodV2<T>(IEnumerable<T> list)  // better than V1
        {
            using (IEnumerator<T> enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.Write($" {enumerator.Current}");
                }
            }
        }
    }
}
