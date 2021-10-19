using System;
using System.Text;

namespace PlariumTask3
{
    class TestingVariantA
    {
        public static void Main(string[] args)
        {
            //---------------------------------------------------
            Console.Write("Enter your text: ");
            string text = Console.ReadLine();
            Console.Write("Enter word to search: ");
            string word = Console.ReadLine();

            Console.WriteLine();

            VariantA.SelectWordsInString(text, word);

            //---------------------------------------------------

            Console.WriteLine("\n" + "-----------------------------------------------" + "\n" + "\n");
            Console.Write("Enter string with verbs (Russian language): ");
            text = Console.ReadLine();
            Console.Write("String without verbs: ");
            VariantA.RemoveVerbsFromString(text);
            Console.WriteLine();

            //---------------------------------------------------

            VariantA.Stemmer(new StringBuilder("hello prefixeellsufix fffeellrtqqq notrepited"));
        }
    }
}
