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
            bool isInt;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Players");
                Console.WriteLine("2. Admin");
                Console.WriteLine("ESC. Quit");

                keyInfo = Console.ReadKey();
                isInt = int.TryParse(keyInfo.KeyChar.ToString(), out int num);

                if (isInt)
                {
                    switch (num)
                    {
                        case 1:
                            Player(rpgInventory);
                            break;
                        case 2:
                            Admin(rpgInventory);
                            break;
                        default:
                            break;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void Player(SqlRpgInventory rpgInventory)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = rpgInventory.PlayerSelectMenu();
                if (int.TryParse(keyInfo.KeyChar.ToString(), out int num))
                {
                    rpgInventory.PlayersMenu(num);
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void Admin(SqlRpgInventory rpgInventory)
        {
            rpgInventory.AdminMenu();
        }
    }
}
