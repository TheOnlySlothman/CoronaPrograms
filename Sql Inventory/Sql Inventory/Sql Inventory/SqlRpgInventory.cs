using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_Inventory
{
    class SqlRpgInventory
    {
        public static SqlConnection connection;
        public SqlRpgInventory()
        {
            connection = SqlConnect();
        }

        SqlConnection SqlConnect()
        {
            SqlConnection connection = new SqlConnection("user id=username;" +
                                       "password=password;" +
                                       "server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=testDB; " +
                                       "connection timeout=30");

            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        void SqlCommandQuery(string query)
        {
            new SqlCommand(query, connection).ExecuteNonQuery();
        }

        static SqlDataReader SqlRead(string query)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(query, connection);
                return myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public ConsoleKeyInfo PlayerSelect()
        {
            Console.Clear();
            ConsoleKeyInfo keyInfo;
            SqlDataReader reader = SqlRead("execute GetPlayers");
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}. {reader["Name"]}");
                }
                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();
            } while (!int.TryParse(keyInfo.KeyChar.ToString(), out _) && keyInfo.Key != ConsoleKey.Escape);
            reader.Close();
            return keyInfo;
        }

        public void PlayerMenu(int playerId)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Drop Item");
                Console.WriteLine("3. See Inventory");
                Console.WriteLine("4. Update Inventory");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddItem(playerId);
                        break;
                    case '2':
                        DropItem(playerId);
                        break;
                    case '3':
                        ShowInventory(playerId);
                        Console.ReadKey(true);
                        break;
                    case '4':
                        Update(playerId);
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void AddItem(int playerId)
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("select * from Items");
            int itemId;
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}. {reader["Name"]}");
                }
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));
            reader.Close();
            SqlCommandQuery($"execute ItemToInventory @playerId = {playerId}, @itemId = {itemId}");
        }

        void ShowInventory(int playerId)
        {
            Console.Clear();
            // SqlDataReader reader = SqlRead($"select * from Inventory where Id = {playerId}");
            SqlDataReader reader = SqlRead($"select * from Inventory where Id = {playerId}");
            List<int> lst = new List<int>();

            while (reader.Read())
            {
                for (int i = 1; i < reader.FieldCount; i++)
                {
                    if (int.TryParse(reader[i].ToString(), out int num))
                    {
                        lst.Add(num);
                    }
                    else
                    {
                        lst.Add(0);
                    }
                }
            }
            reader.Close();
            for (int i = 0; i < lst.Count; i++)
            {
                reader = SqlRead($"select * from Items where Id = {lst[i]}");
                while (reader.Read())
                {
                    Console.WriteLine($"{i + 1}. {reader["Name"]}");
                }
                reader.Close();
            }
        }

        void DropItem(int playerId)
        {
            int inventoryId;

            do
            {
                ShowInventory(playerId);
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out inventoryId));

            SqlCommandQuery($"execute DropItem @playerId = {playerId}, @inventoryId = {inventoryId}");
        }

        void Update(int playerId)
        {
            int inventoryId;
            int itemId;

            do
            {
                ShowInventory(playerId);
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out inventoryId));

            do
            {
                ShowItems();
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));

            SqlCommandQuery($"execute UpdateItem @playerId = {playerId}, @itemId = {itemId}, @inventoryId = {inventoryId}");
        }

        void ShowItems()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("select * from  Items");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]}");
            }
            reader.Close();
        }
    }
}
