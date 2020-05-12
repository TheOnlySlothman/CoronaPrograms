using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria_3
{
    class Pizza
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public List<PizzaProperty> Ingredients { get; set; }

        public PizzaProperty Size { get; set; }

        public PizzaProperty Dough { get; set; }

        public Pizza()
        {
            Ingredients = new List<PizzaProperty>();
        }

    }
    public class PizzaProperties
    {
        public List<PizzaProperty> sauce;
        public List<PizzaProperty> cheese;
        public List<PizzaProperty> toppings;
        public List<PizzaProperty> sizes;
        public List<PizzaProperty> dough;
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
