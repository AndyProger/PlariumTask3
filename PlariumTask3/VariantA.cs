using System;
using System.Globalization;
using System.Text;
using System.Linq;


namespace PlariumTask3
{
    class VariantA
    {
        public static void SelectWordsInString(string text, string word)
        {
            string[] textArray = text.Split(' ');
            
            foreach(string str in textArray)
            {
                if(string.Compare(str, word, CultureInfo.CurrentCulture, 
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(str + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(str + " ");
                }
            }
        }

        public static void RemoveVerbsFromString(string text)
        {
            string[] arrayOfEnds = {"ать", "ять", "ешь", "ют"};
            string[] arrayOfWords = text.ToLower().Replace(".", string.Empty).Replace(",", string.Empty).Split(" ");
            StringBuilder resultString = new StringBuilder();

            bool isVerb = false;

            foreach(string word in arrayOfWords)
            {
                isVerb = false;

                foreach(string end in arrayOfEnds)
                {
                    if (word.EndsWith(end))
                    {
                        isVerb = true;
                        break;
                    }
                }

                if (!isVerb)
                    resultString.Append(word + " ");
            }

            Console.WriteLine(resultString);
        }

        public static void Stemmer(string str)
        {
            string[] words = str.ToLower().Replace(".", string.Empty).Replace(",", string.Empty).Split(" ");
            string prefix, stem, end;

            for (var i = 0; i < words.Length; i++)
            {
                for(var j = i + 1; j < words.Length; j++)
                {
                    


                }
            }
        }

        public static string FindStemp(string fWord, string sWord)
        {
            if (fWord.Length < 3 || sWord.Length < 3)
                return null;

            if (fWord == sWord) return fWord;
            if (fWord.Contains(sWord)) return sWord;
            if (sWord.Contains(fWord)) return fWord;

            string smallWord = fWord.Length < sWord.Length ? fWord : sWord;
            string bigWord = fWord.Length > sWord.Length ? fWord : sWord;

            string stemm = null;
            int lPointer = 0, rPointer = 2;

            while(rPointer != smallWord.Length)
            {
                if (bigWord.Contains(smallWord.Substring(smallWord.IndexOf(smallWord[lPointer]),
                                                         smallWord.IndexOf(smallWord[rPointer]))))
                    stemm = smallWord.Substring(smallWord.IndexOf(smallWord[lPointer]),
                                                         smallWord.IndexOf(smallWord[rPointer]));

                rPointer++;

                if(rPointer == smallWord.Length && lPointer + 2 != smallWord.Length)
                {
                    lPointer++;
                    rPointer = lPointer + 2;
                }
            }

            return stemm;
        }

        static void Main(string[] args)
        {
            //Console.Write("Enter your text: ");
            //string text = Console.ReadLine();
            //Console.Write("Enter word to search: ");
            //string word = Console.ReadLine();

            //Console.WriteLine("Waiting for pressing any key... ");
            //Console.ReadKey();
            //Console.WriteLine();

            //SelectWordsInString(text, word);

            //Console.WriteLine("\n" + "-----------------------------------------------" + "\n" + "\n");
            //Console.Write("Enter string with verbs (Russian language): ");
            //text = Console.ReadLine();
            //Console.Write("String without verbs: ");
            //RemoveVerbsFromString(text);

            
        }
    }
}
