using System;
using System.Collections.Generic;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Divide_Hash Divide_Table = new Divide_Hash(50);
            Square_Hash Square_Table = new Square_Hash(50);

            Track[] trck = new Track[25];
            Track.Fill(trck);

            string x = "";
            while (x != "4")
            {
                Console.WriteLine("Choose the action: \n1. Print array of records\n2. Hash records by division method \n3. Hash records using the mid-squares method\n4. Exit");
                x = Console.ReadLine();
                switch (x)
                {
                    case "1":
                        Console.WriteLine("Point А\t\tPoint В\t\tRoute number");
                        foreach (var i in trck) { i.Show(); }
                        Console.WriteLine();
                        break;

                    case "2":
                       
                        DivideAction(trck, Divide_Table);
                        break;

                    case "3":
                      
                        SquareAction(trck, Square_Table);
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("Invalid input data format! ");
                      
                        break;
                }

            }
        }

   

        private static void DivideAction(Track[] ord, Divide_Hash DivideTable)
        {
            string c = ""; int acc1, acc2; int number;
            do
            {
                Console.WriteLine("Choose the action: \n1. Hash records by division method\n2. Add item to division hash table\n3. Find an element in a hash table of division \n4. Delete item in division hash table \n5. Print hash table of division \n6. Exit");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        for (int i = 0; i < ord.Length; i++) { DivideTable.Add(ord[i]); }
                        Console.WriteLine("Done!");
                       
                        break;

                    case "2":
                        Console.WriteLine("Enter new entry details: Destination number A (3 digits), Destination number B (3 digits), Route number (10000 to 99999)");
                        Console.Write("Destination number A:"); acc1 = int.Parse(Console.ReadLine()); Console.Write("Destination number B: "); acc2 = int.Parse(Console.ReadLine()); Console.Write(" Route number: "); number = int.Parse(Console.ReadLine());
                        DivideTable.Add(new Track(acc1, acc2, number));
                        Console.WriteLine("Item was added!");
                       
                        break;

                    case "3":
                        Console.WriteLine("Enter the route number where you want to find the entry: ");
                        number = int.Parse(Console.ReadLine());
                        if (DivideTable.Search(number) != 0) { Console.WriteLine($"The entry was found, its key is in the hash table - {DivideTable.Search(number)}"); } else { Console.WriteLine("There is no such record!"); }
                       
                        break;

                    case "4":
                        Console.WriteLine("Enter the route number in the entry to be deleted: ");
                        int dm = int.Parse(Console.ReadLine());
                        if (!DivideTable.Delete(dm)) { Console.WriteLine("There is no such record!"); } else { Console.WriteLine("Record was successfully deleted"); }
                        
                        break;

                    case "5":
                        Console.WriteLine("Current hash table: ");
                        DivideTable.Display();
                        
                        break;

                    case "6":
                      
                        break;

                    default:
                        Console.WriteLine("Invalid input data format! ");
                       
                        break;
                }
            }
            while (c != "6");
        } // действия с таблицей деления

        private static void SquareAction(Track[] ord, Square_Hash SquareTable)
        {
            string c = ""; int acc1, acc2; int number;
            do
            {
                Console.WriteLine("Choose the action: \n1. Hashes input data using the mid-squares method \n2. Add item to division hash table\n3. Find an element in a hash table of division \n4. Delete item in division hash table \n5. Print hash table of division \n6. Exit");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        for (int i = 0; i < ord.Length; i++) { SquareTable.Add(ord[i]); }
                        Console.WriteLine("Done!");
                       
                        break;

                    case "2":
                        Console.WriteLine("Enter new entry details: Destination number A (3 digits), Destination number B (3 digits), Route number (10000 to 99999)");
                        Console.Write("Destination number A: "); acc1 = int.Parse(Console.ReadLine()); Console.Write("Destination number B: "); acc2 = int.Parse(Console.ReadLine()); Console.Write("Route number: "); number = int.Parse(Console.ReadLine());
                        SquareTable.Add(new Track(acc1, acc2, number));
                        Console.WriteLine("Item was added");
                       
                        break;

                    case "3":
                        Console.WriteLine("Enter the route number where you want to find the entry: ");
                        number = int.Parse(Console.ReadLine());
                        if (SquareTable.Search(number) != 0) { Console.WriteLine($"The entry was found, its key is in the hash table - {SquareTable.Search(number)}"); } else { Console.WriteLine("There is no such record!"); }
                        
                        break;

                    case "4":
                        Console.WriteLine("Enter the route number in the entry to be deleted: ");
                        int dm = int.Parse(Console.ReadLine());
                        if (!SquareTable.Delete(dm)) { Console.WriteLine("There is no such record!"); } else { Console.WriteLine("Record was successfully deleted!"); }
                       
                        break;

                    case "5":
                        Console.WriteLine("Current hash table: ");
                        SquareTable.Display();
                       
                        break;

                    case "6":
                        
                        break;

                    default:
                        Console.WriteLine("Invalid input data format! ");

                        break;
                }
            }
            while (c != "6");
        } // mid-squares table actions
    }

    class Track
    {
        public static Random rnd = new Random();
        public int PointA { get; set; }
        public int PointB { get; set; }
        public int Number { get; set; }

        public Track(int payer, int payee, int money)
        {
            this.PointA = payer; this.PointB = payee; this.Number = money;
        }

        public void Show()
        {
            Console.WriteLine($"А{PointA}\t\tВ{PointB}\t\t#{Number}");
            Console.WriteLine();
        }

        public static void Fill(Track[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Track(rnd.Next(1, 999), rnd.Next(1, 999), rnd.Next(10000, 99999));
            }
        }
    } // Item

    class Item
    {

        public LinkedList<Track> Nodes { get; set; }

        public Item()
        {
            Nodes = new LinkedList<Track>();
        }
    } // array element, represented as a list

    class Divide_Hash
    {
        private Item[] items;

        public Divide_Hash(int size)
        {
            items = new Item[size];

            for (int i = 0; i < items.Length; i++) { items[i] = new Item(); }

        }

        private int Divide(int item)
        {
            return item % 48 + 1;
        } // division hash function

        public void Add(Track item)
        {
            var key = Divide(item.Number);
            items[key].Nodes.AddLast(item);
        } // adding 

        public int Search(int item)
        {
            var key = Divide(item);
            foreach (var elem in items[key].Nodes)
            {
                if (elem.Number == item) { return key; }
            }
            return 0;
        } // searching

        public bool Delete(int item)
        {
            var key = Divide(item);
            foreach (var elem in items[key].Nodes)
            {
                if (elem.Number == item) { return items[key].Nodes.Remove(elem); }
            }
            return false;
        } // deleting 

        public void Display()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Nodes.Count != 0) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{i}]:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ______________________________________"); } else { Console.WriteLine($"[{i}]:"); }
                foreach (var item in items[i].Nodes)
                {
                    item.Show();
                }
                Console.WriteLine();
            }
        }
    } // hash table by division

    class Square_Hash
    {
        private Item[] items;

        public Square_Hash(int size)
        {
            items = new Item[size];

            for (int i = 0; i < items.Length; i++) { items[i] = new Item(); }
        }

        private int MidSquare(int item)
        {
            long r = (long)Math.Pow(item, 2); long k = (r / 10000) % 100;
            k = (long)(k * 0.5);
            return (int)k;
        } //  mid-squares hash function

        public void Add(Track item)
        {
            var key = MidSquare(item.Number);
            items[key].Nodes.AddLast(item);
        } // adding

        public int Search(int item)
        {
            var key = MidSquare(item);
            foreach (var elem in items[key].Nodes)
            {
                if (elem.Number == item) { return key; }
            }
            return 0;
        } // searching

        public bool Delete(int item)
        {
            var key = MidSquare(item);
            foreach (var elem in items[key].Nodes)
            {
                if (elem.Number == item) { return items[key].Nodes.Remove(elem); }
            }
            return false;
        } // deleting

        public void Display()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Nodes.Count != 0) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{i}]:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" ______________________________________"); } else { Console.WriteLine($"[{i}]:"); }
                foreach (var item in items[i].Nodes)
                {
                    item.Show();
                }
                Console.WriteLine();
            }
        }
    } // mid-squares hash function
}