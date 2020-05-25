using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pizzaria_3
{
    public class Pizzaria
    {
        public List<Pizza> Pizzas;
        public PizzaProperties Properties;

        Pizzaria()
        {
            Pizzas = new List<Pizza>();
            Pizzas.Add(new Pizza("pizza1", new List<PizzaProperty>() { 
                Properties.cheese.Find(x => x.name == "pizza cheese")
            
            }));
        }
    }

    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double getPrice()
        {
            IEnumerable<double> i = from x in Ingredients
                                    select x.price;
            return i.Sum() * Size.price;
        }

        public List<PizzaProperty> Ingredients { get; set; }

        public PizzaProperty Size { get; set; }

        public Pizza()
        {
            Ingredients = new List<PizzaProperty>();
        }

        public Pizza(string name, List<PizzaProperty> ingredients)
        {

        }

    }

    public class PizzaProperties
    {
        public List<PizzaProperty> sauce;
        public List<PizzaProperty> cheese;
        public List<PizzaProperty> toppings;
        public List<PizzaProperty> sizes;
        public List<PizzaProperty> dough;

        public PizzaProperties()
        {
            sauce = new List<PizzaProperty>();
            cheese = new List<PizzaProperty>();
            toppings = new List<PizzaProperty>();
            sizes = new List<PizzaProperty>();
            dough = new List<PizzaProperty>();

            cheese.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("none", 0),
                new PizzaProperty("pizza cheese", 10),
                new PizzaProperty("cheddar", 10)
            });

            dough.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("normal", 20),
                new PizzaProperty("Gluten-free", 40)
            });

            sauce.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("none", 0),
                new PizzaProperty("tomato", 10),
                new PizzaProperty("bearnaise", 10)
            });

            sizes.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("normal", 1),
                new PizzaProperty("family", 2)
            });

            toppings.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("ham", 10),
                new PizzaProperty("peperoni", 10),
                new PizzaProperty("mushroom", 10),
                new PizzaProperty("kebab", 10),
                new PizzaProperty("pineapple", 10),
                new PizzaProperty("meatballs", 10),

                new PizzaProperty("oregano", 5),
                new PizzaProperty("paprika", 5),
                new PizzaProperty("chili", 0)
            });
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
