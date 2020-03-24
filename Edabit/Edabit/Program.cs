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


        public static string LandscapeType(int[] arr)
        {

            /*
             * Mountains or Valleys
             * A mountain is an array with exactly one peak.
             *
             * All numbers to the left of the peak are increasing.
             * All numbers to the right of the peak are decreasing.
             * The peak CANNOT be on the boundary.
             * A valley is an array with exactly one trough.

                All numbers to the left of the trough are decreasing.
                All numbers to the right of the trough are increasing.
                The trough CANNOT be on the boundary.
                Some examples of mountains and valleys:
             */
            string terrain = "";
            int x = 0;
            int y = 0;

            while (terrain == "")
            {
                if (arr[x] < arr[x + 1])
                {

                    terrain = "mountain";
                    for (int i = 1; i < arr.Length - 1; i++)
                    {
                        if (arr[y] < arr[i])
                            y = i;
                    }
                }
                else if (arr[x] > arr[x + 1])
                {

                    terrain = "valley";
                    for (int i = 1; i < arr.Length - 1; i++)
                    {
                        if (arr[y] > arr[i])
                            y = i;
                    }
                }
                else
                    x++;
            }

            for (int i = y; i < arr.Length - 1; i++)
            {
                if (terrain == "mountain")
                {
                    if (arr[i] < arr[i + 1])
                        return "neither";
                }
                else if (terrain == "valley")
                {
                    if (arr[i] > arr[i + 1])
                        return "neither";
                }
            }

            for (int i = y; i > 0; i--)
            {
                if (terrain == "mountain")
                {
                    if (arr[i] < arr[i - 1])
                        return "neither";
                }
                else if (terrain == "valley")
                {
                    if (arr[i] > arr[i - 1])
                        return "neither";
                }
            }


            return terrain;

        }

        public static bool IsIsogram(string str)
        {
            /*
             * Is the Word an Isogram?
             * 
             * An isogram is a word that has no repeating letters, consecutive or nonconsecutive. Create a function that takes a string and returns either true or false depending on whether or not it's an "isogram".
             */
            char[] charr = str.ToLower().ToCharArray();
            List<char> letters = new List<char>();

            foreach (char item in charr)
            {
                if (letters.Contains(item))
                {
                    return false;
                }
                else
                {
                    letters.Add(item);
                }
            }
            return true;
        }

        public static int MysteryFunc(int num)
        {
            /*
             * Reverse Coding Challenge #6
             * 
             * This is a reverse coding challenge. Normally you're given explicit directions with how to create a function. Here, you must generate your own function to satisfy the relationship between the inputs and outputs.
             * Your task is to create a function that, when fed the inputs below, produces the sample outputs shown.
             * MysteryFunc(152) ➞ 10
             * MysteryFunc(832) ➞ 48
             * MysteryFunc(19) ➞ 9
             * MysteryFunc(133) ➞ 9
             */

            char[] charr = Convert.ToString(num).ToCharArray();
            List<int> numbers = new List<int>();

            foreach (char item in charr)
            {
                numbers.Add(item - '0');
            }
            return numbers.Aggregate(1, (num1, num2) => num1 *= num2);
        }
        /*
        public static int SockPairs(string socks)
        {
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);

            }
        }
        */
    }
}
