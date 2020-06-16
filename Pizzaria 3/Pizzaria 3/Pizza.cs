using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Pizzaria_3
{
    public static class Pizzaria
    {
        public static PizzaProperties PProperties = new PizzaProperties();
        public static DrinkProperties DProperties = new DrinkProperties();
        public static List<Item> Checkout = new List<Item>();
        static int pid = 1;
        static int did = 50;
        public static List<Pizza> Pizzas = new List<Pizza>
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

        public static List<Drink> Drinks = new List<Drink>
        {
                new Drink(did++, "sprite"),
                new Drink(did++, "cola"),
                new Drink(did++, "fanta")
        };

        //Items = new List<Item>();
        //Items.AddRange(Pizzas);
        //Items.AddRange(Drinks);

        public static double Total
        {
            get
            {
                double total = 0;

                foreach (var item in Checkout)
                {
                    total += item.Price * item.Amount;
                }
                return total;
            }
        }

        public static void AddPizza(Pizza selectedPizza, int amount, ItemProperty size)
        {
            bool alreadyAdded = false;
            selectedPizza.Amount = Convert.ToInt32(amount);
            selectedPizza.Size = size;

            foreach (Pizza pizza in Checkout.Where(x => x.GetType() == selectedPizza.GetType()))
                if (selectedPizza.Ingredients.All(x => selectedPizza.Ingredients.Contains(x) && pizza.Ingredients.Count == selectedPizza.Ingredients.Count && selectedPizza.Size == pizza.Size))
                {
                    pizza.Amount += selectedPizza.Amount;
                    alreadyAdded = true;
                    break;
                }
            if (!alreadyAdded)
                Checkout.Add(selectedPizza);
        }

        public static void AddPizza(Pizza selectedPizza)
        {
            bool alreadyAdded = false;

            foreach (Pizza pizza in Checkout.Where(x => x.GetType() == selectedPizza.GetType()))
                if (selectedPizza.Ingredients.All(x => pizza.Ingredients.Contains(x) && pizza.Ingredients.Count == selectedPizza.Ingredients.Count && selectedPizza.Size == pizza.Size))
                {
                    pizza.Amount += selectedPizza.Amount;
                    alreadyAdded = true;
                    break;
                }
            if (!alreadyAdded)
                Checkout.Add(selectedPizza);
        }

        public static void AddDrink(Drink selectedDrink, int amount, ItemProperty size)
        {
            bool alreadyAdded = false;

            selectedDrink.Amount = amount;
            selectedDrink.Size = size;

            foreach (Drink drink in Checkout.Where(x => x.GetType() == selectedDrink.GetType()))
                if (drink.Size == selectedDrink.Size && drink.Name == selectedDrink.Name)
                {
                    drink.Amount += selectedDrink.Amount;
                    alreadyAdded = true;
                    break;
                }

            if (!alreadyAdded)
                Checkout.Add(selectedDrink);


        }

        //removes pizzas with 0 Amount;
        public static void RemoveZeroes()
        {
            List<Item> zeroes = new List<Item>();

            foreach (Item item in Checkout)
            {
                if (item.Amount <= 0)
                {
                    zeroes.Add(item);
                }
            }

            foreach (Item item in zeroes)
            {
                if (item.Amount <= 0)
                {
                    Checkout.Remove(item);
                }
            }
        }

        public static void AddDrink(Drink selectedDrink)
        {
            bool alreadyAdded = false;

            foreach (Drink drink in Checkout.Where(x => x.GetType() == selectedDrink.GetType()))
                if (drink.Size == selectedDrink.Size && drink.Name == selectedDrink.Name)
                {
                    drink.Amount += selectedDrink.Amount;
                    alreadyAdded = true;
                    break;
                }

            if (!alreadyAdded)
                Checkout.Add(selectedDrink);
        }
    }
    public abstract class Item
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string Name { get; set; }

        public ItemProperty Size { get; set; }

        public abstract double Price { get; }

        public abstract string[] ToStringArray();
    }
    public class Pizza : Item
    {

        //price of a single pizza
        public override double Price
        {
            get
            {
                IEnumerable<double> i = from x in Ingredients
                                        select x.price;

                return Size == null ? i.Sum() : i.Sum() * Size.price;
            }
        }

        public List<ItemProperty> Ingredients { get; set; }


        public Pizza() => Ingredients = new List<ItemProperty>();

        //creates a string array for use in datagrid
        public override string[] ToStringArray()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Ingredients)
            {
                sb.Append(item.name + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return new string[] { Amount.ToString(), Size.name, Name, sb.ToString(), (Price * Amount).ToString() };
        }

        public Pizza(int id, string name, List<ItemProperty> ingredients)
        {
            Id = id;

            Name = name;

            Ingredients = new List<ItemProperty>();
            Ingredients.AddRange(ingredients);
        }

        //creates a copy of selected pizza
        public Pizza GetPizza() => new Pizza(Id, Name, Ingredients);
    }
    public class Drink : Item
    {
        readonly double i = 10;

        //price of a single drink
        public override double Price => Size == null ? i : i * Size.price;

        public Drink(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Drink(ItemProperty size)
        {
            this.Size = size;
        }

        public Drink()
        {

        }

        //creates a string array for use in datagrid
        public override string[] ToStringArray()
        {
            return new string[] { Amount.ToString(), Size.name, Name, "", (Price * Amount).ToString() };
        }

        public Drink GetDrink() => new Drink(Id, Name);
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
                new ItemProperty("no cheese", 0),
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
                new ItemProperty("pineapple", 10),
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
