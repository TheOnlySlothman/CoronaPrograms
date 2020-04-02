using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace PizzariaXmlSerializer
{
    [XmlRoot(ElementName = "Pizzaria")]
    public class Pizzaria
    {
        public List<Pizza> Pizzas { get; set; }

        public PizzaProperties Properties { get; set; }

        private static string m_path = "..\\..\\Pizza_Data.xml";

        public static Pizzaria PizzaReader()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Pizzaria));
            StreamReader reader = new StreamReader(m_path);
            Pizzaria m_sys = (Pizzaria)serializer.Deserialize(reader);
            reader.Close();
            return m_sys;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Pizzaria));
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

        [XmlElement(ElementName = "sauce")]
        public List<PizzaProperty> Sauce { get; set; }

        [XmlElement(ElementName = "cheese")]
        public List<PizzaProperty> Cheese { get; set; }

        [XmlElement(ElementName = "topping")]
        public List<PizzaProperty> topping { get; set; }

        [XmlElement(ElementName = "size")]
        public PizzaProperty Size { get; set; }

        [XmlElement(ElementName = "dough")]
        public PizzaProperty Dough { get; set; }

        [XmlElement(ElementName = "spice")]
        public List<PizzaProperty> Spice { get; set; }

    }

    public class PizzaProperties
    {
        [XmlElement(ElementName = "sauce")]
        public List<PizzaProperty> sauce;
        [XmlElement(ElementName = "cheese")]
        List<PizzaProperty> cheese;
        [XmlElement(ElementName = "toppings")]
        List<PizzaProperty> toppings;
        [XmlElement(ElementName = "sizes")]
        List<PizzaProperty> sizes;
        [XmlElement(ElementName = "dough")]
        List<PizzaProperty> dough;
        [XmlElement(ElementName = "spice")]
        List<PizzaProperty> spice;
    }

    public class PizzaProperty
    {
        int id;
        string name;
        double price;

        public PizzaProperty(string name, double price)
        {
            this.id = 1;
            this.name = name;
            this.price = price;
        }
    }
}
