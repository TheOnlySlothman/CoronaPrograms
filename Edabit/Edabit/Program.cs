using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Edabit
{
    class Program
    {
        static void Main(string[] args)
        {
            CorrectSigns("3 < 7 < 11");
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
            char[] charr = socks.ToCharArray();
            IEnumerable<char> dist = socks.Distinct();

            charr.
        }
        */

        public static bool IsPalindrome(string str)
        {
            /*
             * Check if the String is a Palindrome
             * 
             * A palindrome is a word, phrase, number or other sequence of characters which reads the same backward or forward, such as madam or kayak.
             * Write a function that takes a string and determines whether it's a palindrome or not. The function should return a boolean (true or false value).
             */

            Regex rx = new Regex(@"([\W])",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string onlyLetters = rx.Replace(str, "").ToLower();

            if (onlyLetters == string.Concat(onlyLetters.Reverse()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ValidatePIN(string pin)
        {
            /*
             * ATM PIN Code Validation
             * 
             * ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits. Your task is to create a function that takes a string and returns true if the PIN is valid and false if it's not.
             */
            return Regex.IsMatch(pin, @"^\d{4}(?:\d{2})?$");
        }

        public static bool IsSymmetrical(int num)
        {
            /*
             * Is the Number Symmetrical?
             * 
             * Create a function that takes a number as an argument and returns true or false depending on whether the number is symmetrical or not. A number is symmetrical when it is the same as its reverse.
             */
            return num.ToString() == string.Concat(num.ToString().Reverse());
        }

        public static string AlternatingCaps(string str)
        {
            /*
             * AlTeRnAtInG cApS
             * 
             * Create a function that alternates the case of the letters in a string (known as Spongecase).
             */
            Regex rx = new Regex(@"([\w])");

            char[] charr = str.ToCharArray();
            bool capitalize = true;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < charr.Length; i++)
            {
                if (rx.IsMatch(charr[i].ToString()))
                {
                    if (capitalize)
                    {
                        charr[i] = char.ToUpper(charr[i]);
                        capitalize = false;
                    }
                    else
                    {
                        charr[i] = char.ToLower(charr[i]);
                        capitalize = true;
                    }
                }
                sb.Append(charr[i]);
            }
            return sb.ToString();
        }

        public static string[] CapMe(string[] arr)
        {
            /*
             * Capitalize the Names
             * 
             * Create a function that takes an array of names and returns an array with only the first letter capitalized.
             */
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = myTI.ToTitleCase(arr[i].ToLower());
            }

            return arr;
        }

        public static string ReverseAndNot(int i)
        {
            /*
             * ReverseAndNot
             * 
             * Write a function that takes an integer i and returns a string with the integer backwards followed by the original integer.
             */
            return new string(i.ToString().Reverse().ToArray()) + i.ToString();
        }

        public static string LongestCommonEnding(string str1, string str2)
        {
            /*
             * Longest Common Ending
             * 
             * Write a function that returns the longest common ending between two strings.
             */
            char[] charr1 = str1.Reverse().ToArray();
            char[] charr2 = str2.Reverse().ToArray();

            int arrLength = (charr1.Length < charr2.Length) ? charr1.Length : charr2.Length;

            string reversedResult = "";

            for (int i = 0; i < arrLength; i++)
            {
                if (charr1[i] == charr2[i])
                {
                    reversedResult += charr1[i];
                }
                else
                {
                    break;
                }
            }

            IEnumerable<char> reversedCharr = reversedResult.Reverse();

            string result = "";
            foreach (var item in reversedCharr)
            {
                result += item;
            }

            return result;
        }
        public static int FindIndex(string[] arr, string str)
        {
            /*
             * Find the Index
             * 
             * Create a function that takes an array and a string as arguments and return the index of the string.
             */
            return Array.IndexOf(arr, str);
        }

        public static bool IsPlural(string word)
        {
            return word.EndsWith("s");
        }
        public static bool CorrectSigns(string str)
        {
            /*
             * Correct Inequality Signs
             * 
             * Create a function that returns true if a given inequality expression is correct and false otherwise.
             */
            Regex rgx = new Regex(@"([0-9<>]+)");

            MatchCollection mc = rgx.Matches(str);

            List<string> list = new List<string>();

            foreach (Match item in mc)
            {
                list.Add(item.Value);
            }

            string[] arr = list.ToArray();

            for (int i = 1; i < arr.Length; i += 2)
            {

                switch (arr[i])
                {
                    case "<":
                        if (Convert.ToInt32(arr[i - 1]) >= Convert.ToInt32(arr[i + 1]))
                        {
                            return false;
                        }
                        break;
                    case ">":
                        if (Convert.ToInt32(arr[i - 1]) <= Convert.ToInt32(arr[i + 1]))
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        public static string ReverseCase(string str)
        {
            /*
             * Reverse the Case
             * 
             * Given a string, create a function to reverse the case. All lower-cased letters should be upper-cased, and vice versa.
             */
            string output = string.Empty;
            char[] charr = str.ToCharArray();
            foreach (char character in charr)
            {

                if (char.IsLower(character))
                {
                    output += character.ToString().ToUpper();
                }
                else if (char.IsUpper(character))
                {
                    output += character.ToString().ToLower();
                }
                else
                    output += character;
            }

            return output;
        }

        public static int Remainder(int x, int y)
        {
            /*
             * Return the Remainder from Two Numbers
             * 
             * There is a single operator in C#, capable of providing the remainder of a division operation. Two numbers are passed as parameters. The first parameter divided by the second parameter will have a remainder, possibly zero. Return that value.
             */
            int remainder = x % y;
            return remainder;
        }

        public static string GetMiddle(string str)
        {
            /*
             * Return the Middle Character(s) of a String
             * 
             * Create a function that takes a string and returns the middle character(s). If the word's length is odd, return the middle character. If the word's length is even, return the middle two characters.
             */
            char[] charr = str.ToCharArray();
            int left = (charr.Length - 1) / 2;
            int right = charr.Length / 2;
            if (left == right)
                return string.Concat(charr[left]);
            else
                return string.Concat(charr[left], charr[right]);
        }
        public static int NextPrime(int num)
        {
            /*
             * Next Prime
             * 
             * Given an integer, create a function that returns the next prime. If the number is prime, return the number itself.
             */
            while (true)
            {
                int num2 = num;
                int result = 0;

                while (num2 % 2 == 0)
                {
                    result = 2;
                    num2 /= 2;
                }
                int f = 3;
                while (f * f <= num2)
                {
                    if (num2 % f == 0)
                    {
                        result = f;
                        num2 /= f;
                    }
                    else
                        f += 2;
                }
                if (num == num2 || num == result)
                    return num;
                num++;
            }

        }
            public static string FormatPhoneNumber(int[] numbers)
            {
            /*
             * Phone Number Formatting
             * 
             * Create a function that takes an array of 10 numbers (between 0 and 9) and returns a string of those numbers formatted as a phone number (e.g. (555) 555-5555).
             */
                string phoneNums = String.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], numbers[6],
                          numbers[7], numbers[8], numbers[9]);
                return phoneNums;
            }

        public static int FindLargestNum(int[] arr)
        {
            /*
             * Find the Largest Number in an Array
             * 
             * Create a function that takes an array of numbers. Return the largest number in the array.
             */
            return arr.Max();

        }

        public static int FindDigitAmount(int num)
        {
            /*
             * Find the Total Number of Digits the Given Number Has
             * 
             * Create a function that takes a number as an argument and returns the amount of digits it has.
             */
            string str = Convert.ToString(num);
            return str.Length;
        }

        public static int animals(int chickens, int cows, int pigs)
        {
            /*
             * The Farm Problem
             * 
             * In this challenge, a farmer is asking you to tell him how many legs can be counted among all his animals. The farmer breeds three species:
                chickens = 2 legs
                cows = 4 legs
                pigs = 4 legs
                */
            int legs;
            return legs = (2 * chickens + 4 * cows + 4 * pigs);
        }

        public static bool divisibleByFive(int n)
        {
            /*
             * Check if an Integer is Divisible By Five
             * 
             * Create a function that returns true if an integer is evenly divisible by 5, and false otherwise.
             */
            if (0 == n % 5)
                return true;
            else
                return false;
        }

        public static int[] IndexOfCapitals(string str)
        {
            /*
             * Return the Index of All Capital Letters
             * 
             * Create a function that takes a single string as argument and returns an ordered array containing the indices of all capital letters in the string.
             */

            List<int> caps = new List<int>();
            char[] charr = str.ToCharArray();
            for (int i = 0; i < charr.Length; i++)
            {

                if (char.IsUpper(charr[i]))
                {
                    caps.Add(i);
                }

            }
            return caps.ToArray();
        }

    }

}
