namespace Day6Assgn
{
    public static class StringExtensions
    {
        public static int WordCount(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "how are you?";

            int wordCount = sentence.WordCount();

            Console.WriteLine($"The number of words in the sentence is: {wordCount}");

            Console.ReadLine();
        }
    }
}

