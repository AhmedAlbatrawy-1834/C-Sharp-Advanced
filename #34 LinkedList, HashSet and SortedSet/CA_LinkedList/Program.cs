namespace CA_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //          -----LinkedList-------

            // Constructors
            //YTVideo[] videos =
            //{
            //    new YTVideo("TYV1","C# Basics",new TimeSpan(00,40,56)),
            //    new YTVideo("TYV2","Variables in C#",new TimeSpan(00,30,30)),
            //    new YTVideo("TYV3","Classes In C#",new TimeSpan(00,50,05)),
            //    new YTVideo("TYV4","OOP in C#",new TimeSpan(3,35,25)),
            //    new YTVideo("TYV5","Exceptions in C#",new TimeSpan(00,30,23))
            //};

            //LinkedList<YTVideo> PlayList = new LinkedList<YTVideo>(videos);  //create LinkedList From Already Existed Array

            LinkedList<YTVideo> PlayList = new LinkedList<YTVideo>(); // Create Empty LinkedList
            var lesson1 = new YTVideo("TYV1", "C# Basics", new TimeSpan(00, 40, 56));
            var lesson2 = new YTVideo("TYV2", "Variables in C#", new TimeSpan(00, 30, 30));
            var lesson3 = new YTVideo("TYV3", "Classes In C#", new TimeSpan(00, 50, 05));
            var lesson4 = new YTVideo("TYV4", "OOP in C#", new TimeSpan(3, 35, 25));
            var lesson5 = new YTVideo("TYV5", "Exceptions in C#", new TimeSpan(00, 30, 23));

        //Properties:-
            //.Count : use to get Number of items in LinkedList
            //.Last  : use to get Last item in LinkedList (type: LinkedListNode<T>)
            //.First : use to get First item in LinkedList (type: LinkedListNode<T>)
            

        //Methods:-
            //Add Methods
            PlayList.AddFirst(lesson1);
            PlayList.AddAfter(PlayList.First, lesson2);
            PlayList.AddAfter(PlayList.First.Next,lesson3);
            PlayList.AddLast(lesson5);
            LinkedListNode<YTVideo>?last = PlayList.Last;
            PlayList.AddBefore(last, lesson4);
            Console.WriteLine("\t\tComplete PlayList");
            Print("Learn C#", PlayList);
            Console.WriteLine("********************************************");


            // Remove Methods:-
            //.Clear(): use to remove all item in LinkedList and make it Empty
            //.RemoveFirst():use to remove First item in LinkedList.
            //.RemoveLast():use to remove Last item in LinkedList.
            //.Remove(): use to remove specific item from LinkedList and you pass object of <T>
            //need to override GetHashCode() and Equals() methods if and only if you pass new object 
            PlayList.Remove(new YTVideo("TYV2", "Variables in C#", new TimeSpan(00, 30, 30))); //require to override GetHashCode() and Equals() methods
            PlayList.Remove(PlayList.Last.Previous); // not require to override GetHashCode() and Equals() methods
            Console.WriteLine("\t\tPlayList After Remove OOP in C# and Variables in C#");
            Print("Learn C#", PlayList);
            Console.WriteLine("********************************************");

        }
        public static void Print(string Title,LinkedList<YTVideo> List)
        {
            Console.WriteLine($"┌─{Title}");
            foreach(var video in List)
            {
                Console.WriteLine(video);
            }
            Console.WriteLine("└─");
        }
    }

    class YTVideo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public YTVideo(string id, string name, TimeSpan duration)
        {
            this.Id = id;
            this.Name = name;
            this.Duration = duration;
        }

        public override string ToString()
        {
            var url = $"https://www.youtube.com/watch?v={Id}";
            return $"├─{Name}   ({Duration})\n|\t{url}";
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            var video = obj as YTVideo;
            if (video == null)
                return false;
            return this.Id.Equals(video.Id);
        }
    }
}
