using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
             InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //forms has made me a broken man, so i have to write this painful code
            PizzaProperties pizzaProperties = new PizzaProperties();
            pizzaProperties.cheese.Add(new PizzaProperty("pizza cheese", 1));
            pizzaProperties.cheese.Add(new PizzaProperty("cheddar", 1));

            pizzaProperties.dough.Add(new PizzaProperty("normal", 1));
            pizzaProperties.dough.Add(new PizzaProperty("Gluten-free", 1));

            pizzaProperties.sauce.Add(new PizzaProperty("tomato", 1));
            pizzaProperties.sauce.Add(new PizzaProperty("bearnaise", 1));

            pizzaProperties.sizes.Add(new PizzaProperty("normal", 1));
            pizzaProperties.sizes.Add(new PizzaProperty("family", 1));

            pizzaProperties.spice.Add(new PizzaProperty("oregano", 1));
            pizzaProperties.spice.Add(new PizzaProperty("paprika", 1));
            pizzaProperties.spice.Add(new PizzaProperty("chili", 1));

            pizzaProperties.toppings.Add(new PizzaProperty("ham", 1));
            pizzaProperties.toppings.Add(new PizzaProperty("peperoni", 1));
            pizzaProperties.toppings.Add(new PizzaProperty("mushroom", 1));
            pizzaProperties.toppings.Add(new PizzaProperty("kebab", 1));
            pizzaProperties.toppings.Add(new PizzaProperty("pineapple", 1));
            pizzaProperties.toppings.Add(new PizzaProperty("meatballs", 1));


            /*
            Pizza pizza2 = new Pizza();
            pizza2.Dough = nDough;
            pizza2.Size = nSize;
            pizza2.Ingredients.Add(tSauce);
            pizza2.Ingredients.Add(cheese);
            pizza2.Ingredients.Add(peperoni);
            */
        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            PizzaEditor EditorForm = new PizzaEditor();
            EditorForm.Show();
            this.Hide();
        }
    }
}
