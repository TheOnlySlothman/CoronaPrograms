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

        public int PlayerSelect()
        {
            Console.Clear();
            int num;
            SqlDataReader reader = SqlRead("execute GetPlayers");
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"].ToString());
                    Console.WriteLine(reader["Name"].ToString());
                }
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out num));
            reader.Close();
            return num;
        }

        public void Menu(int playerId)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Drop Item");
                Console.WriteLine("3. See Inventory");

                Console.WriteLine("ESC. Quit");
                keyInfo = Console.ReadKey();

                switch (keyInfo.KeyChar)
                {
                    case '1':
                        AddItem(playerId);
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
                    Console.WriteLine(reader["Id"].ToString());
                    Console.WriteLine(reader["Name"].ToString());
                }
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));
            reader.Close();
            SqlCommandQuery($"execute ItemToInventory @playerId = {playerId}, @itemId = {itemId}");
        }

        void SeeInventory()
        {
            Console.Clear();
            SqlDataReader reader = SqlRead("select * from Items");
            int itemId;
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"].ToString());
                    Console.WriteLine(reader["Name"].ToString());
                }
            } while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemId));
            reader.Close();
        }
    }
}
