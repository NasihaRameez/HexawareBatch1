using System;

namespace Assignment3
{
    internal class Program
    {
       //Strings Assignment:
      static void GetWordLength()
      {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the word: " + word.Length);
        }

       static void ReverseWord()
       {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
           char[] charArray = word.ToCharArray();
           Array.Reverse(charArray);
            Console.WriteLine("Reversed word: " + new string(charArray));
        }

        static void CompareWords()
        {
            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine();

            if (word1.Equals(word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The words are the same.");
            }
            else
            {
                Console.WriteLine("The words are different.");
            }
        }

       //static void Main(string[] args)
       //{
       // Console.WriteLine("Choose an option:");
       // Console.WriteLine("1. Find the length of a word");
       // Console.WriteLine("2. Reverse a word");
       // Console.WriteLine("3. Compare two words");
       // Console.Write("Enter your choice (1-3): ");
       // int choice = Convert.ToInt32(Console.ReadLine());
       // switch (choice)
       // {
       //  case 1:
       //   GetWordLength();
       //   break;
       //  case 2:
       //   ReverseWord();
       //   break;
       //  case 3:
       //   CompareWords();
       //   break;
       //  default:
       //   Console.WriteLine("Invalid choice.");
       //   break;
       // }
       }
    }

