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
        public PizzaProperties Properties = new PizzaProperties();
        public List<Pizza> Checkout = new List<Pizza>();

        public Pizzaria()
        {
            int id = 1;
            Pizzas = new List<Pizza>
            {
                new Pizza(id++, "pizza1", new List<PizzaProperty>()
                {
                    Properties.sauce.Find(x => x.name == "tomato"),
                    Properties.cheese.Find(x => x.name == "pizza cheese"),
                    Properties.toppings.Find(x => x.name == "ham"),
                    Properties.toppings.Find(x => x.name == "oregano")
                }),

                new Pizza(id++, "pizza2", new List<PizzaProperty>()
                {
                    Properties.sauce.Find(x => x.name == "tomato"),
                    Properties.cheese.Find(x => x.name == "pizza cheese"),
                    Properties.toppings.Find(x => x.name == "peperoni"),
                    Properties.toppings.Find(x => x.name == "oregano")
                }),

                new Pizza(id++, "pizza3", new List<PizzaProperty>()
                {
                    Properties.sauce.Find(x => x.name == "tomato"),
                    Properties.cheese.Find(x => x.name == "pizza cheese"),
                    Properties.toppings.Find(x => x.name == "ham"),
                    Properties.toppings.Find(x => x.name == "oregano")
                }),

                new Pizza(id++, "pizza3", new List<PizzaProperty>()
                {
                    Properties.sauce.Find(x => x.name == "tomato"),
                    Properties.cheese.Find(x => x.name == "pizza cheese"),
                    Properties.toppings.Find(x => x.name == "ham"),
                    Properties.toppings.Find(x => x.name == "oregano")
                }),
            };
        }
    }

    public class Pizza
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        public double GetPrice()
        {
            IEnumerable<double> i = from x in Ingredients
                                    select x.price;

            if (Size == null)
            {
                return i.Sum();
            }
            else
            {
                return i.Sum() * Size.price;
            }
        }

        public List<PizzaProperty> Ingredients { get; set; }

        public PizzaProperty Size { get; set; }

        public Pizza() => Ingredients = new List<PizzaProperty>();
        
        public string[] ToStringArray()
        {
            return new string[] { Amount.ToString(), Name, "", GetPrice().ToString() };
        }

        public Pizza(int id, string name, List<PizzaProperty> ingredients)
        {
            Id = id;

            Name = name;

            Ingredients = new List<PizzaProperty>();
            Ingredients.AddRange(ingredients);
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
                new PizzaProperty("normal bread", 20),
                new PizzaProperty("Gluten-free", 40)
            });

            sauce.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("no sauce", 0),
                new PizzaProperty("tomato", 10),
                new PizzaProperty("bearnaise", 10)
            });

            sizes.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("normal size", 1),
                new PizzaProperty("family size", 2)
            });

            toppings.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("ham", 10),
                new PizzaProperty("peperoni", 10),
                new PizzaProperty("mushroom", 10),
                new PizzaProperty("kebab", 10),
                new PizzaProperty("pineapple", 60),
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
