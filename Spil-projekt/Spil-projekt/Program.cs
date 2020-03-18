using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int tries = 3;

            while(NewGame(tries, out int newTries))
            {
                score++;
                tries = newTries;
            }
            EndGame(score);
        }

        static bool NewGame(int tries, out int newTries)
        {
            int number = new Random().Next(0,11);
            Console.Clear();
            Console.WriteLine("I am thinking of a number between 0 and 10. ");
            int guess;
            int.TryParse(Console.ReadLine(), out guess);
            
            for (int i = tries; i > 0; i--)
            {
                if (guess == number)
                {
                    Console.WriteLine("you got it");
                    Console.ReadKey();
                    newTries = i + 3;
                    return true;
                }
                else if (guess <= number)
                {
                    Console.WriteLine("too low");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                else if (guess >= number)
                {
                    Console.WriteLine("too high");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
            }
            newTries = 0;
            return false;
        }

        static void EndGame(int scores)
        {
            throw new NotImplementedException();
        }
    }
}
