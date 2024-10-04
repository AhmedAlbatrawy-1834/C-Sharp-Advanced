namespace CA_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //              -----queue-----
            //is a collection class that works in the FIFO (First In First Out) Principle.

        //Constructors:-
            //Queue<int> queue=new Queue<int>();        //create Empty Queue.
            //Queue<int> queue = new Queue<int>(5);     //create Empty Queue with capacity 5.
            Queue<int> queue = new Queue<int>([15, 2, 45, 454, 68, 5]);

        //Properties:-
            //Count:return number of items in Queue.
            Console.WriteLine(queue.Count);

            //Methods:-
            //.Enqueue():use to add new item in Queue (add at end)
            
            queue.Enqueue(15);

            //Dequeue():use to remove and return the the oldest item in queue
            //if Queue is empty it throw exception we can use TryDequeue()
            //Console.WriteLine(queue.Dequeue()); //may throw Exception if queue Empty.
            if(queue.TryDequeue(out int value))
            {
                Console.WriteLine(value);
            }

            //Peek():use to return the oldest item in queue
            //if Queue is empty it throw exception we can use TryDequeue()
            // Console.WriteLine(queue.Peek());  //may throw Exception if queue Empty.
            if (queue.TryPeek(out int Value))
            {
                Console.WriteLine(Value);
            }

            //.Contains():use to check if specific item exist in queue or not (return true or false).
            // O(n)
            Console.WriteLine((queue.Contains(5)) ? "Exist" : "not Exist");

            //.ToArray():use to copy queue items to new array
            var arr = queue.ToArray();

            //.CopyTo():use to copy queue items to existing one-dimensional Array.
            int[] arr2 = new int[queue.Count];
            queue.CopyTo(arr2, 0);

            //.Clear():use to remove all stack items.
            queue.Clear();
        }
    }
}
