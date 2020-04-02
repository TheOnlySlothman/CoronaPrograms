using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace Pizzaria
{
    [DataContract(Name = "Pizzaria")]
    public class Pizzaria
    {
        [DataMember()]
        public List<Pizza> Pizzas;
        [DataMember()]
        public PizzaProperties Properties;

        private static string m_path = "..\\..\\Pizza_Data.xml";

        public static Pizzaria PizzaReader()
        {
            Console.WriteLine("Deserializing an instance of the object.");
            FileStream fs = new FileStream(m_path,
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Pizzaria));

            Pizzaria pizzaria = (Pizzaria)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();

            return pizzaria;

        }
        public void Save()
        {
            Console.WriteLine(
                "Creating a Person object and serializing it.");
            FileStream writer = new FileStream(m_path, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(Pizzaria));
            ser.WriteObject(writer, this);
            writer.Close();
        }
    }

    [DataContract(Name = "Pizza")]
    public class Pizza
    {
        [DataMember()]
        public int Id { get; set; }

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public string Price { get; set; }

        [DataMember()]
        public List<int> Sauce { get; set; }

        [DataMember()]
        public List<int> Cheese { get; set; }

        [DataMember()]
        public List<int> Topping { get; set; }

        [DataMember()]
        public int Size { get; set; }

        [DataMember()]
        public int Dough { get; set; }

        [DataMember()]
        public List<int> Spice { get; set; }

    }

    [DataContract(Name = "Properties")]
    public class PizzaProperties
    {
        [DataMember()]
        public List<PizzaProperty> sauce;
        [DataMember()]
        public List<PizzaProperty> cheese;
        [DataMember()]
        public List<PizzaProperty> toppings;
        [DataMember()]
        public List<PizzaProperty> sizes;
        [DataMember()]
        public List<PizzaProperty> dough;
        [DataMember()]
        public List<PizzaProperty> spice;

        //public string NextEid(List<PizzaProperty> PP)
        //{
        //    int m_result = 0;
        //    foreach (PizzaProperty item in PP)
        //        if (Convert.ToInt32(item.id) > m_result)
        //            m_result = Convert.ToInt32(item.id);
        //    return (++m_result).ToString();
        //}
    }

    [DataContract(Name = "Property")]
    public class PizzaProperty
    {
        [DataMember]
        public int id;
        [DataMember()]
        public string name;
        [DataMember()]
        public double price;

        public PizzaProperty(string name, double price)
        {
            this.id = 1;
            this.name = name;
            this.price = price;


        }
    }
}
