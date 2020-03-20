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
            int points = 0;
            int tries = 3;

            Highscores m_sys = Highscores.ScoreReader("..\\..\\Score_Data.xml");

            while (NewGame(tries, out int newTries))
            {
                points++;
                tries = newTries;
            }
            EndGame(points, m_sys);
        }

        static bool NewGame(int tries, out int newTries)
        {
            int number = new Random().Next(0,11);
            Console.Clear();
            Console.WriteLine("I am thinking of a number between 0 and 10. ");
            Console.WriteLine($"you have {tries} left");
            int guess;
            
            for (int i = tries; i > 0; i--)
            {
            int.TryParse(Console.ReadLine(), out guess);
                if (guess < number)
                {
                    Console.WriteLine("too low");
                }
                else if (guess > number)
                {
                    Console.WriteLine("too high");
                }
                else if (guess == number)
                {
                    Console.WriteLine("you got it");
                    Console.ReadKey();
                    newTries = i + 2;
                    return true;
                }
            }
            newTries = 0;
            return false;
        }

        static void EndGame(int points, Highscores sys)
        {
            Console.Clear();
            Console.WriteLine("game over");
            Console.WriteLine("Please input name");
            string name = Console.ReadLine();

            Score score = new Score
            {
                Name = name,
                Points = points.ToString()
            };

            sys.Scores.Add(score);
            sys.Save();

            IEnumerable<Score> query = sys.Scores.OrderBy(order => order.Points).Reverse();

            Console.Clear();

            foreach (Score i in query)
            {
                Console.WriteLine("{0} - {1}", i.Points, i.Name);
            }

            Console.ReadKey();
        }

    }
}
