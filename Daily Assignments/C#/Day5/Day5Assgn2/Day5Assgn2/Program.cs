using System;
namespace Day5Assgn2
{ 
        abstract class Furniture
        {
            public string Material { get; set; }
            public double Price { get; set; }

            public Furniture(string material, double price)
            {
                Material = material;
                Price = price;
            }

            public abstract void DisplayDetails(); 
        }
        class Chair : Furniture
        {
            public int NumberOfLegs { get; set; }

            public Chair(string material, double price, int numberOfLegs) : base(material, price)
            {
                NumberOfLegs = numberOfLegs;
            }

            public override void DisplayDetails()
            {
                Console.WriteLine("Chair - Material: " + Material + ", Price: " + Price + ", Legs: " + NumberOfLegs);
            }
        }
        class Bookshelf : Furniture
        {
            public int NumberOfShelves { get; set; }

            public Bookshelf(string material, double price, int numberOfShelves) : base(material, price)
            {
                NumberOfShelves = numberOfShelves;
            }

            public override void DisplayDetails()
            {
                Console.WriteLine("Bookshelf - Material: " + Material + ", Price: " + Price + ", Shelves: " + NumberOfShelves);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Chair chair = new Chair("Wood", 1500, 4);
                Bookshelf bookshelf = new Bookshelf("Metal", 3000, 5);

                chair.DisplayDetails();
                bookshelf.DisplayDetails();

                Console.ReadLine();
            }
        }
    }

