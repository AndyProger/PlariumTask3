using System;
using System.Collections.Generic;
using System.Text;

namespace PlariumTask3
{
    public static class StringBuilderExtension
    {
        public static StringBuilder SubString(this StringBuilder input, int index, int length)
        {
            return new StringBuilder(input.ToString(index, length));
        }

        public static int IndexOf(this StringBuilder sb, StringBuilder s)
        {
            if (sb == null)
                throw new ArgumentNullException("sb");
            if (s == null)
                s = new StringBuilder("");

            for (int i = 0; i < sb.Length; i++)
            {
                int j;
                for (j = 0; j < s.Length && i + j < sb.Length && sb[i + j] == s[j]; j++) ;
                if (j == s.Length)
                    return i;
            }

            return -1;
        }

        public static StringBuilder[] Split(this StringBuilder input, char separator)
        {
            List<StringBuilder> results = new List<StringBuilder>();

            StringBuilder current = new StringBuilder();
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == separator)
                {
                    results.Add(current);
                    current = new StringBuilder();
                }
                else
                    current.Append(input[i]);
            }

            if (current.Length > 0)
                results.Add(current);

            return results.ToArray();
        }
    }
}

