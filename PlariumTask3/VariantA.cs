﻿using System;
using System.Globalization;
using System.Text;


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
            string prefixFirst, prefixSecond, stem, endFirst, endSecond;

            for (var i = 0; i < words.Length; i++)
            {
                for(var j = i + 1; j < words.Length; j++)
                {
                    stem = FindStemp(words[i], words[j]);

                    if (stem.Length > 2)
                    {
                        prefixFirst = words[i].Substring(0, words[i].IndexOf(stem));
                        prefixSecond = words[j].Substring(0, words[j].IndexOf(stem));
                        endFirst = words[i].Substring(words[i].IndexOf(stem) + stem.Length);
                        endSecond = words[j].Substring(words[j].IndexOf(stem) + stem.Length);
                        Console.WriteLine(new string('*', 20));
                        Console.WriteLine(words[i] + " and " + words[j]);
                        Console.WriteLine(prefixFirst + " " + stem + " " + endFirst);
                        Console.WriteLine(prefixSecond + " " + stem + " " + endSecond);
                        Console.WriteLine(new string('*', 20));
                    }
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

            string smallWord = fWord.Length <= sWord.Length ? fWord : sWord;
            string bigWord = fWord.Length > sWord.Length ? fWord : sWord;

            string stemm = string.Empty;
            string subString = string.Empty;
            int lPointer = 0, rPointer = 2;

            while(rPointer != smallWord.Length)
            {
                subString = smallWord.Substring(lPointer, rPointer - lPointer + 1);
                if (bigWord.Contains(subString) && subString.Length > stemm.Length)
                {
                    stemm = smallWord.Substring(lPointer, rPointer - lPointer + 1);
                }

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

            Stemmer("hello wqeellrt fffeellrtqqq poop");
        }
    }
}
