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
                Console.ReadKey(true);
                return null;
            }
        }

        void SqlCommandQuery(string query)
        {
            try
            {
            new SqlCommand(query, connection).ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey(true);
            }
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
                Console.ReadKey(true);
                return null;
            }
        }

        #region Inventory
        void AddInventoryItem(int playerId)
        {
            int itemId;
            do
            {
                ShowItems();
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));
            SqlCommandQuery($"execute ItemToInventory @playerId = {playerId}, @itemId = {itemId}");
        }

        void DropInventoryItem(int playerId)
        {
            int inventoryId;

            do
            {
                ShowInventory(playerId);
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out inventoryId));

            SqlCommandQuery($"execute DropInventoryItem @playerId = {playerId}, @inventoryId = {inventoryId}");
        }

        void UpdateInventory(int playerId)
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
        #endregion

        List<int> GetIds(string table)
        {
            SqlDataReader reader = SqlRead($"select * from {table}");
            List<int> lst = new List<int>();

            while (reader.Read())
            {
                lst.Add((int)reader["Id"]);
            }
            reader.Close();
            return lst;
        }

        #region Item
        void AddItem()
        {
            // ShowItems();
            int type;
            double weight;
            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();

            

            do
            {
                ShowITypes();
            } while (!(int.TryParse(Console.ReadKey().KeyChar.ToString(), out type) && GetIds("ITypes").Contains(type)));



            do
            {
                Console.Clear();
                Console.WriteLine("Weight");
            } while (!double.TryParse(Console.ReadLine(), out weight));

            SqlCommandQuery($"insert into Items values('{name}', {type}, '{weight}')");
        }

        void DeleteItem()
        {
            int itemId;

            do
            {
                ShowItems();
            } while (!int.TryParse(Console.ReadLine(), out itemId));

            SqlCommandQuery($"execute DeleteItem  @itemId = {itemId}");
        }

        void UpdateItem()
        {
            int itemId;
            int type;
            double weight;
            string name;

            do
            {
                ShowItems();
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));

            Console.Clear();
            Console.WriteLine("Name");
            name = Console.ReadLine();

            do
            {
                ShowITypes();
            } while (!(int.TryParse(Console.ReadKey().KeyChar.ToString(), out type) && GetIds("ITypes").Contains(type)));


            do
            {
                Console.Clear();
                Console.WriteLine("Weight");
            } while (!double.TryParse(Console.ReadLine(), out weight));

            SqlCommandQuery($"update Items set Name = '{name}', TypeId = {type}, Weight = '{weight}' where Id = {itemId}");
        }

        #endregion

        #region Show Methods

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

        void ShowItems()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("execute ShowItems");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]}, {reader["TypeName"]}, {reader["Weight"]}");
            }
            reader.Close();
        }

        void ShowITypes()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("select * from ITypes");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]}");
            }
            reader.Close();
        }
        #endregion

        #region Menus
        public void AdminMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Item Types");
                Console.WriteLine("2. Items");
                Console.WriteLine("3. Classes");
                Console.WriteLine("4. Players");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        ItemTypeMenu();
                        break;
                    case '2':
                        ItemMenu();
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void ItemMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Drop Item");
                Console.WriteLine("3. See Items");
                Console.WriteLine("4. Update Items");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddItem();
                        break;
                    case '2':
                        DeleteItem();
                        break;
                    case '3':
                        ShowItems();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        UpdateItem();
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void ItemTypeMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add ItemType");
                Console.WriteLine("2. Drop ItemType");
                Console.WriteLine("3. See ItemsType");
                Console.WriteLine("4. Update ItemsType");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddItemType();
                        break;
                    case '2':
                        DeleteItemType();
                        break;
                    case '3':
                        ShowITypes();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        UpdateItemType();
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
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
                        AddInventoryItem(playerId);
                        break;
                    case '2':
                        DropInventoryItem(playerId);
                        break;
                    case '3':
                        ShowInventory(playerId);
                        Console.ReadKey(true);
                        break;
                    case '4':
                        UpdateInventory(playerId);
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public ConsoleKeyInfo PlayerSelectMenu()
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

        #endregion

        #region ItemType
        void AddItemType()
        {
            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();

            SqlCommandQuery($"insert into ITypes values('{name}')");
        }

        void DeleteItemType()
        {
            int itemTypeId;

            do
            {
                ShowITypes();
            } while (!int.TryParse(Console.ReadLine(), out itemTypeId));

            SqlCommandQuery($"Delete from ITypes where Id = {itemTypeId}");
        }

        void UpdateItemType()
        {
            int itemTypeId;

            do
            {
                ShowITypes();
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemTypeId));

            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();


            SqlCommandQuery($"update ITypes set Name = '{name}' where Id = {itemTypeId}");
        }


        #endregion
    }
}
