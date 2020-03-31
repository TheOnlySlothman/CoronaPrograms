using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Pizzaria
{
    [XmlRoot(ElementName = "Pizzas")]
    public class Pizzas
    {
        public List<Pizza> PizzaList { get; set; }

        private static string m_path = "..\\..\\Pizza_Data.xml";

        public static Pizzas PizzaReader(string path)
        {
            m_path = path;
            XmlSerializer serializer = new XmlSerializer(typeof(Pizzas));
            StreamReader reader = new StreamReader(path);
            Pizzas m_sys = (Pizzas)serializer.Deserialize(reader);
            reader.Close();
            return m_sys;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Pizzas));
            StreamWriter writer = new StreamWriter(m_path);
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }

    public class Pizza
    {
        [XmlAttribute(AttributeName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "price")]
        public string Price { get; set; }

    }
}
