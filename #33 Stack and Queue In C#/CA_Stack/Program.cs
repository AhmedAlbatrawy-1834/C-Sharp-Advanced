namespace CA_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //                  ------Stack------
            // is a collection class that works in the LIFO (Last In First Out) Principle.


        //Constructors:-
            //Stack<int> stack = new Stack<int>(); //create Empty Stack.
            //Stack<int> stack = new Stack<int>(5) //create Empty Stack with capacity 5.
            Stack<int> stack = new Stack<int>([1, 5, 2, 3, 5]); //create stack from existed Array or Collection.

        //Properties:-
            //Count:return number of item in Stack.
            Console.WriteLine(stack.Count);

        //Methods:-
            //.Push():use to push new item in stack
            stack.Push(15);

            //.Pop():use to remove and return last inserted item in stack.
            //if the stack is Empty it will throw an Exception we can use .TryPop()
            //Console.WriteLine(stack.Pop()); //may give Exception.
            if(stack.TryPop(out int Value))
            {
                Console.WriteLine(Value+"Deleted");
            }

            //.Peek():use to return top-most (last inserted) item in stack.
            //if the stack is Empty it will throw an Exception we can use .TryPeek()
            //Console.WriteLine(stack.Peek());//may give Exception.
            if (stack.TryPeek(out int value))
            {
                Console.WriteLine("the item is:"+value);
            }

            //.Contains():use to check if specific item exist in stack or not (return true or false).
            // O(n)
            Console.WriteLine((stack.Contains(5))?"Exist":"not Exist");

            //.ToArray():use to copy stack items to new array
            var arr= stack.ToArray();

            //.CopyTo():use to copy stack items to existing one-dimensional Array.
            int[] arr2=new int[stack.Count];
            stack.CopyTo(arr2, 0);

            //.Clear():use to remove all stack items.
            stack.Clear();

        }
    }
}
