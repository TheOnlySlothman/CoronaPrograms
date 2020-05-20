using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace Pizzaria_3
{

    public class PizzaProperties
    {
        public List<PizzaProperty> sauce;
        public List<PizzaProperty> cheese;
        public List<PizzaProperty> toppings;
        public List<PizzaProperty> sizes;
        public List<PizzaProperty> dough;
        public List<PizzaProperty> spice;

        public PizzaProperties()
        {
            sauce = new List<PizzaProperty>();
            cheese = new List<PizzaProperty>();
            toppings = new List<PizzaProperty>();
            sizes = new List<PizzaProperty>();
            dough = new List<PizzaProperty>();
            spice = new List<PizzaProperty>();
        }
    }

    public class PizzaProperty
    {
        public string name;
        public double price;

        public PizzaProperty(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
