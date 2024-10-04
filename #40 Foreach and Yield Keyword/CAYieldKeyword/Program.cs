namespace CAYieldKeyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Count: ");
            var count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nGetRandomNumbers V1");
            Console.Write("Numbers: ");
            foreach (var num in GetRandomNumbersV1(count))
            {
                Console.Write($" {num}");
            }
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("\nGetRandomNumbers V2");
            Console.Write("Numbers: ");
            foreach (var num in GetRandomNumbersV2(count))
            {
                Console.Write($" {num}");
            }
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("\nGetRandomNumbers V3");
            Console.Write("Numbers: ");
            foreach (var num in GetRandomNumbersV3(count))
            {
                Console.Write($" {num}");
            }
            Console.WriteLine("\n-----------------------------------\n");
        }


        #region Before Yield Keyword
        static IEnumerable<int> GetRandomNumbersV1(int count)  // Before Yield Keyword
        {
            var numbers = new List<int>();
            for(int i = 0; i < count; i++)
            {
                numbers.Add(Random.Shared.Next(1, 5001));
            }
            return numbers;
        }
        #endregion

        #region After Yield Keyword
        static IEnumerable<int> GetRandomNumbersV2(int count)  // best practice 
        {
            for(int i = 0; i < count; i++)
            {
                yield return Random.Shared.Next(1, 5001);
            }
        }
        #endregion

        #region Yield Break
        static IEnumerable<int> GetRandomNumbersV3(int count)
        {
            while (true)
            {
                if (count > 0)
                    yield return Random.Shared.Next(1, 5001);
                else
                    yield break;   // Break Yield Return loop
                count--;
            }
        }
        #endregion





    }
}
