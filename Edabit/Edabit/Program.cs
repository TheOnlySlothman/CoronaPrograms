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
        

    }
}
