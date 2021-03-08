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
        static SqlConnection connection;
        static readonly string exitWord = "exit";

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

        #region Menu

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

        void AdminMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Select table to edit");
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
                    case '3':
                        ClassMenu();
                        break;
                    case '4':
                        PlayerMenu();
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
                Console.WriteLine("Items");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Delete Item");
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
                Console.WriteLine("Item Types");
                Console.WriteLine("1. Add ItemType");
                Console.WriteLine("2. Delete ItemType");
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

        void ClassMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Classes");
                Console.WriteLine("1. Add Class");
                Console.WriteLine("2. Delete Class");
                Console.WriteLine("3. See Class");
                Console.WriteLine("4. Update Class");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddClass();
                        break;
                    case '2':
                        DeleteClass();
                        break;
                    case '3':
                        ShowClasses();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        UpdateClass();
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void PlayerMenu()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Players");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Delete Player");
                Console.WriteLine("3. See Player");
                Console.WriteLine("4. Update Player");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddPlayer();
                        break;
                    case '2':
                        DeletePlayer();
                        break;
                    case '3':
                        ShowPlayers();
                        Console.ReadKey(true);
                        break;
                    case '4':
                        UpdatePlayers();
                        break;
                    default:
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void PlayersMenu(int playerId)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Inventory");
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

        ConsoleKeyInfo PlayerSelectMenu()
        {
            Console.Clear();
            ConsoleKeyInfo keyInfo;
            do
            {
                ShowPlayers();

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();
            } while (!int.TryParse(keyInfo.KeyChar.ToString(), out _) && keyInfo.Key != ConsoleKey.Escape);
            return keyInfo;
        }

        public void MainMenu()
        {
            ConsoleKeyInfo keyInfo;
            bool isInt;
            do
            {
                Console.Clear();
                Console.WriteLine("Select a menu");
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
                            Player(this);
                            break;
                        case 2:
                            Admin(this);
                            break;
                        default:
                            break;
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        void Player(SqlRpgInventory rpgInventory)
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

        #endregion

        #region ItemType

        void AddItemType()
        {
            Console.Clear();
            Console.WriteLine("Name");
            Console.WriteLine($"type {exitWord} to exit");
            string name = Console.ReadLine();


            if (name.ToLower() != exitWord)
            {
                SqlCommandQuery($"insert into ITypes values('{name}')");
            }
        }

        void DeleteItemType()
        {
            int itemTypeId;
            string input;

            do
            {
                ShowITypes();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemTypeId) && GetIds("ITypes").Contains(itemTypeId)) || input.ToLower() == exitWord));

            if (GetIds("ITypes").Contains(itemTypeId))
            {
                SqlCommandQuery($"Delete from ITypes where Id = {itemTypeId}");
            }
        }

        void UpdateItemType()
        {
            int itemTypeId;
            string input;
            do
            {
                ShowITypes();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemTypeId) && GetIds("ITypes").Contains(itemTypeId)) || input.ToLower() == exitWord));

            Console.Clear();
            Console.WriteLine("Name");
            Console.WriteLine($"type {exitWord} to exit");
            string name = Console.ReadLine();

            if (GetIds("ITypes").Contains(itemTypeId))
            {
                SqlCommandQuery($"update ITypes set Name = '{name}' where Id = {itemTypeId}");
            }
        }

        #endregion

        #region Item

        void AddItem()
        {
            // ShowItems();
            int type;
            double weight;
            Console.Clear();
            Console.WriteLine("Name");
            Console.WriteLine($"type {exitWord} to exit");

            string name = Console.ReadLine();

            if (name.ToLower() == exitWord)
            {
                return;
            }

            string input;


            do
            {
                ShowITypes();
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out type) && GetIds("ITypes").Contains(type)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Weight");
                Console.WriteLine($"type {exitWord} to exit");
            } while (!double.TryParse(Console.ReadLine(), out weight) || input.ToLower() == exitWord);

            if (input.ToLower() != exitWord)
            {
                SqlCommandQuery($"insert into Items values('{name}', {type}, '{weight}')");
            }
        }

        void DeleteItem()
        {
            int itemId;
            string input;

            do
            {
                ShowItems();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemId) && GetIds("Items").Contains(itemId)) || input.ToLower() == exitWord));

            if (input.ToLower() != exitWord)
            {
                SqlCommandQuery($"execute DeleteItem  @itemId = {itemId}");
            }
        }

        void UpdateItem()
        {
            int itemId;
            int type;
            double weight;
            string name;
            string input;

            do
            {
                ShowItems();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemId) && GetIds("Items").Contains(itemId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("Name");
            name = Console.ReadLine();

            do
            {
                ShowITypes();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out type) && GetIds("ITypes").Contains(type)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Weight");
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((double.TryParse(input, out weight)) || input.ToLower() == exitWord));

            if (input.ToLower() != exitWord)
            {
                SqlCommandQuery($"update Items set Name = '{name}', TypeId = {type}, Weight = '{weight}' where Id = {itemId}");
            }
        }

        #endregion

        #region Classes

        void AddClass()
        {
            Console.Clear();
            Console.WriteLine("Name");
            Console.WriteLine($"type {exitWord} to exit");
            string name = Console.ReadLine();

            if (name.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"insert into Classes values('{name}')");
        }

        void DeleteClass()
        {
            int classID;
            string input;

            do
            {
                ShowClasses();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out classID) && GetIds("Classes").Contains(classID)) || input.ToLower() == exitWord));

            if (input.ToLower() != exitWord)
            {
                SqlCommandQuery($"Delete from Classes where Id = {classID}");
            }
        }

        void UpdateClass()
        {
            int classID;
            string input;

            do
            {
                ShowClasses();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out classID) && GetIds("Classes").Contains(classID)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();

            if (name.ToLower() == exitWord)
            {
                return;
            }


            SqlCommandQuery($"update Classes set Name = '{name}' where Id = {classID}");
        }

        #endregion

        #region Player

        void AddPlayer()
        {
            Console.Clear();
            Console.WriteLine("Name");
            Console.WriteLine($"type {exitWord} to exit");
            string name = Console.ReadLine();
            int classId;
            string input;

            if (name.ToLower() == exitWord)
            {
                return;
            }

            do
            {
                ShowClasses();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out classId) && GetIds("Classes").Contains(classId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"insert into Players values('{name}', {classId})");
        }

        void DeletePlayer()
        {
            int playerId;
            string input;

            do
            {
                ShowPlayers();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out playerId) && GetIds("Players").Contains(playerId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"Delete from Players where Id = {playerId}");

        }

        void UpdatePlayers()
        {
            int playerId;
            int classId;
            string input;

            do
            {
                ShowPlayers();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out playerId) && GetIds("Players").Contains(playerId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            Console.Clear();
            Console.WriteLine("Name");
            string name = Console.ReadLine();

            if (name.ToLower() == exitWord)
            {
                return;
            }

            do
            {
                ShowClasses();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out classId) && GetIds("Classes").Contains(classId)) || input.ToLower() == exitWord));

            if (name.ToLower() == exitWord)
            {
                return;
            }


            SqlCommandQuery($"update Players set Name = '{name}', ClassId = {classId} where Id = {playerId}");
        }
        #endregion


        #region Inventory
        void AddInventoryItem(int playerId)
        {
            int itemId;
            string input;
            do
            {
                ShowItems();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemId) && GetIds("Items").Contains(itemId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"execute ItemToInventory @playerId = {playerId}, @itemId = {itemId}");
        }

        void DropInventoryItem(int playerId)
        {
            int inventoryId;
            string input;

            do
            {
                ShowInventory(playerId);
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out inventoryId) && GetIds("Inventory").Contains(inventoryId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"execute DropInventoryItem @playerId = {playerId}, @inventoryId = {inventoryId}");
        }

        void UpdateInventory(int playerId)
        {
            int inventoryId;
            int itemId;
            string input;

            do
            {
                ShowInventory(playerId);
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out inventoryId) && GetIds("Inventory").Contains(inventoryId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            do
            {
                ShowItems();
                Console.WriteLine($"type {exitWord} to exit");
                input = Console.ReadLine();
            } while (!((int.TryParse(input, out itemId) && GetIds("Items").Contains(itemId)) || input.ToLower() == exitWord));

            if (input.ToLower() == exitWord)
            {
                return;
            }

            SqlCommandQuery($"execute UpdateItem @playerId = {playerId}, @itemId = {itemId}, @inventoryId = {inventoryId}");
        }
        #endregion

        #region Show Methods

        void ShowInventory(int playerId)
        {
            Console.Clear();
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

        void ShowClasses()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("select * from Classes");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]}");
            }
            reader.Close();
        }

        void ShowPlayers()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("execute GetPlayers");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}. {reader["Name"]}, {reader["Class"]}");
            }
            reader.Close();
        }
        #endregion
    }
}
