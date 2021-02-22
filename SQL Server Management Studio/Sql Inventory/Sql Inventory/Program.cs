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
            int num = rpgInventory.PlayerSelect();
            rpgInventory.Menu(num);
            

        }
    }
}
