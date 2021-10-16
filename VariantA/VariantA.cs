using System;
using System.Globalization;
using System.Text;


namespace PlariumTask3
{
    class VariantA
    {
        /*
         * По нажатию произвольной клавиши поочередно выделяет в тексте заданное слово 
         * (заданное слово вводится с клавиатуры);
         */
        public static void SelectWordsInString(string text, string word)
        {
            string[] textArray = text.ToLower().Split(" ");

            foreach (string str in textArray)
            {
                if (string.Compare(str, word, CultureInfo.CurrentCulture,
                    CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols) == 0)
                {
                    Console.ReadKey();
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

        // Ищет глаголы и возвращает в консоль строку без глаголов.
        public static void RemoveVerbsFromString(string text)
        {
            string[] arrayOfEnds = { "ать", "ять", "ешь", "ют" };
            string[] arrayOfWords = text.ToLower().Replace(".", string.Empty).Replace(",", string.Empty).Split(" ");
            StringBuilder resultString = new StringBuilder();

            bool isVerb = false;

            foreach (string word in arrayOfWords)
            {
                isVerb = false;

                foreach (string end in arrayOfEnds)
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

        /*
         * Найти во входной строке слова с одинаковым основанием (совпадающие части двух и более слов, 3 буквы и более) и разбить эти слова на 3 части
         *  – префикс, то что стоит до основания слева,
         *  – основа, то что совпадает с частью другого слова,
         *  – окончание.
         * Обратите внимание, что некоторые из этих 1,3 частей могут отсутствовать.
         */
        public static void Stemmer(StringBuilder str)
        {
            StringBuilder[] words = str.Split(' ');
            StringBuilder prefixFirst, prefixSecond, stem, endFirst, endSecond;

            for (var i = 0; i < words.Length; i++)
            {
                for (var j = i + 1; j < words.Length; j++)
                {
                    stem = FindLongestCommonSubstring(words[i], words[j]);

                    if (stem.Length > 2)
                    {
                        prefixFirst = words[i].SubString(0, words[i].IndexOf(stem));
                        prefixSecond = words[j].SubString(0, words[j].IndexOf(stem));

                        var lengthOfTheEnd = words[i].Length - prefixFirst.Length - stem.Length;
                        endFirst = words[i].SubString(words[i].IndexOf(stem) + stem.Length, lengthOfTheEnd);

                        lengthOfTheEnd = words[j].Length - prefixSecond.Length - stem.Length;
                        endSecond = words[j].SubString(words[j].IndexOf(stem) + stem.Length, lengthOfTheEnd);

                        Console.WriteLine(new string('*', 40) + "\n");
                        Console.WriteLine(words[i] + " and " + words[j]);
                        Console.WriteLine(prefixFirst + " " + stem + " " + endFirst);
                        Console.WriteLine(prefixSecond + " " + stem + " " + endSecond);
                        Console.WriteLine(new string('*', 40) + "\n");
                    }
                }
            }
        }

        /*
         * Поиск общей наибольшей подстроки при помощи динамического программирования.
         * Есть множество алгоритмов, но конкретном в этом, мы жертвуем памятью, но выигрываем
         * в скорости.
         */
        public static StringBuilder FindLongestCommonSubstring(StringBuilder firstWord, StringBuilder secondWord)
        {
            var lengthsArray = new int[firstWord.Length, secondWord.Length];
            int maxLength = 0;
            StringBuilder result = new StringBuilder("");

            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] == secondWord[j])
                    {
                        lengthsArray[i, j] = i == 0 || j == 0 ? 1 : lengthsArray[i - 1, j - 1] + 1;

                        if (lengthsArray[i, j] > maxLength)
                        {
                            maxLength = lengthsArray[i, j];
                            result = firstWord.SubString(i - maxLength + 1, maxLength);
                        }
                    }
                    else
                    {
                        lengthsArray[i, j] = 0;
                    }
                }
            }
            return result;
        }
    }
}
