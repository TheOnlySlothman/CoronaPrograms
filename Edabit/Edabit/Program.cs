using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edabit
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static int[] ArrayOfMultiples(int num, int length)
        {
            /*
             * Array of Multiples
             * Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num up to length.
             */

            IEnumerable<int> l = Enumerable.Range(1, length).Select(x => num * x);

            return l.ToArray();
        }

        public static bool IsAnagram(string str1, string str2)
        {
            /*
             * Check for Anagrams
             * Create a function that takes two strings and returns either true or false depending on whether they're anagrams or not.
             */

            List<char> charr1 = str1.ToLower().ToList();
            List<char> charr2 = str2.ToLower().ToList();

            charr1.Sort();
            charr2.Sort();

            for (int i = 0; i < str1.Length; i++)
            {
                if (charr1[i] != charr2[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
