using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRpgInventory rpgInventory = new SqlRpgInventory();
            ConsoleKeyInfo keyInfo;
            int num;
            bool isInt;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Players");
                Console.WriteLine("2. God");
                Console.WriteLine("ESC. Quit");

                keyInfo = Console.ReadKey();
                isInt = int.TryParse(keyInfo.KeyChar.ToString(), out num);

                if (isInt)
                {
                    switch (num)
                    {
                        case 1:
                            do
                            {
                                keyInfo = rpgInventory.PlayerSelect();
                                if (Int32.TryParse(keyInfo.KeyChar.ToString(), out num))
                                {
                                    rpgInventory.PlayerMenu(num);
                                }
                            } while (keyInfo.Key != ConsoleKey.Escape);
                            break;
                        default:
                            break;
                    }
                }

            } while (!isInt && keyInfo.Key != ConsoleKey.Escape);

        }
    }
}
