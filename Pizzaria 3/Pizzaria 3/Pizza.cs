using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Pizzaria_3
{
    public class Pizzaria
    {
        public List<Pizza> Pizzas;
        public List<Drink> Drinks;
        public PizzaProperties PProperties = new PizzaProperties();
        public DrinkProperties DProperties = new DrinkProperties();
        public List<Item> Checkout = new List<Item>();

        public Pizzaria()
        {
            int pid = 1;
            int did = 50;
            Pizzas = new List<Pizza>
            {
                new Pizza(pid++, "pizza1", new List<ItemProperty>()
                {
                    PProperties.sauce.Find(x => x.name == "tomato sauce"),
                    PProperties.cheese.Find(x => x.name == "pizza cheese"),
                    PProperties.toppings.Find(x => x.name == "ham"),
                    PProperties.spice.Find(x => x.name == "oregano")
                }),

                new Pizza(pid++, "pizza2", new List<ItemProperty>()
                {
                    PProperties.sauce.Find(x => x.name == "tomato sauce"),
                    PProperties.cheese.Find(x => x.name == "pizza cheese"),
                    PProperties.toppings.Find(x => x.name == "peperoni"),
                    PProperties.spice.Find(x => x.name == "oregano")
                }),

                new Pizza(pid++, "pizza3", new List<ItemProperty>()
                {
                    PProperties.sauce.Find(x => x.name == "tomato sauce"),
                    PProperties.cheese.Find(x => x.name == "pizza cheese"),
                    PProperties.toppings.Find(x => x.name == "ham"),
                    PProperties.toppings.Find(x => x.name == "peperoni"),
                    PProperties.toppings.Find(x => x.name == "kebab"),
                    PProperties.toppings.Find(x => x.name == "meatballs"),
                    PProperties.spice.Find(x => x.name == "oregano")
                }),
            };

            Drinks = new List<Drink>
            {
                new Drink(did++, "sprite"),
                new Drink(did++, "cola"),
                new Drink(did++, "fanta")
            };
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (var item in Checkout)
            {
                total += item.GetPrice() * item.Amount;
            }
            return total;
        }
    }

    public class Pizza : Item
    {

        public override double GetPrice()
        {
            IEnumerable<double> i = from x in Ingredients
                                    select x.price;

            return Size == null ? i.Sum() : i.Sum() * Size.price;
        }

        public List<ItemProperty> Ingredients { get; set; }


        public Pizza() => Ingredients = new List<ItemProperty>();

        public string[] ToStringArray()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Ingredients)
            {
                sb.Append(item.name + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return new string[] { Amount.ToString(), Name, sb.ToString(), GetPrice().ToString() };
        }

        public Pizza(int id, string name, List<ItemProperty> ingredients)
        {
            Id = id;

            Name = name;

            Ingredients = new List<ItemProperty>();
            Ingredients.AddRange(ingredients);
        }

        public Pizza GetPizza() => new Pizza(Id, Name, Ingredients);
    }

    public class PizzaProperties
    {
        public List<ItemProperty> sauce;
        public List<ItemProperty> cheese;
        public List<ItemProperty> toppings;
        public List<ItemProperty> sizes;
        public List<ItemProperty> dough;
        public List<ItemProperty> spice;

        public PizzaProperties()
        {
            sauce = new List<ItemProperty>();
            cheese = new List<ItemProperty>();
            toppings = new List<ItemProperty>();
            sizes = new List<ItemProperty>();
            dough = new List<ItemProperty>();
            spice = new List<ItemProperty>();

            cheese.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("none", 0),
                new ItemProperty("pizza cheese", 10),
                new ItemProperty("cheddar", 10)
            });

            dough.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("normal bread", 20),
                new ItemProperty("Gluten-free", 40)
            });

            sauce.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("no sauce", 0),
                new ItemProperty("tomato sauce", 10),
                new ItemProperty("bearnaise sauce", 10)
            });

            sizes.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("normal size", 1),
                new ItemProperty("family size", 2)
            });

            toppings.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("ham", 10),
                new ItemProperty("peperoni", 10),
                new ItemProperty("mushroom", 10),
                new ItemProperty("kebab", 10),
                new ItemProperty("pineapple", 60),
                new ItemProperty("meatballs", 10),
            });

            spice.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("oregano", 5),
                new ItemProperty("paprika", 5),
                new ItemProperty("chili", 0)
            });
        }


    }

    public class ItemProperty
    {
        public string name;
        public double price;

        public ItemProperty(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }

    public abstract class Item
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        public ItemProperty Size { get; set; }

        public abstract double GetPrice();
    }

    public class Drink : Item
    {
        readonly double i = 10;

        public override double GetPrice()
        {

            return Size == null ? i : i * Size.price;
        }

        public Drink(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Drink(PizzaProperty size)
        {

        }
    }

    public class DrinkProperties
    {
        public List<ItemProperty> sizes;

        public DrinkProperties()
        {
            sizes = new List<ItemProperty>();

            sizes.AddRange(new List<ItemProperty>()
            {
                new ItemProperty("small", 1),
                new ItemProperty("medium", 1.5),
                new ItemProperty("large", 2)
            });
        }
    }
}
