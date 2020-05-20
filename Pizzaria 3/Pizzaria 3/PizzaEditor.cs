using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria_3
{
    public partial class PizzaEditor : Form
    {
        public PizzaEditor()
        {
            InitializeComponent();
        }

        private void PizzaEditor_Load(object sender, EventArgs e)
        {
            PizzaProperties pizzaProperties = new PizzaProperties();
            pizzaProperties.cheese.Add(new PizzaProperty("pizza cheese", 1));
            pizzaProperties.cheese.Add(new PizzaProperty("cheddar", 1));

            pizzaProperties.dough.Add(new PizzaProperty("normal", 1));
            pizzaProperties.dough.Add(new PizzaProperty("Gluten-free", 1));

            pizzaProperties.sauce.Add(new PizzaProperty("tomato", 1));
            pizzaProperties.sauce.Add(new PizzaProperty("bearnaise", 1));

            pizzaProperties.sizes.Add(new PizzaProperty("normal", 1));
            pizzaProperties.sizes.Add(new PizzaProperty("family", 1));

            pizzaProperties.spice.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("oregano", 1),
                new PizzaProperty("paprika", 1),
                new PizzaProperty("chili", 1)
            });

            pizzaProperties.toppings.AddRange(new List<PizzaProperty>()
            {
                new PizzaProperty("ham", 1),
                new PizzaProperty("peperoni", 1),
                new PizzaProperty("mushroom", 1),
                new PizzaProperty("kebab", 1),
                new PizzaProperty("pineapple", 1),
                new PizzaProperty("meatballs", 1)
            });

            // foreach (var item in pizzaProperties.dough)
            {
                DoughBox.DataSource = pizzaProperties.dough;
            }

        }
            public string[] strArr = { "1", "2", "3" };
    }
}
