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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PizzaProperty nDough = new PizzaProperty("Normal", 1);
            PizzaProperty gDough = new PizzaProperty("Gluten Free Dough", 2);

            PizzaProperty nSize = new PizzaProperty("Normal Size", 1);
            PizzaProperty fSize = new PizzaProperty("Family Size", 2);

            PizzaProperty tSauce = new PizzaProperty("tomato", 1);

            PizzaProperty cheese = new PizzaProperty("cheese", 1);

            PizzaProperty spice = new PizzaProperty("spice", 1);



            Pizza pizza1 = new Pizza();
            pizza1.Dough = nDough;
            pizza1.Size = nSize;
            pizza1.Ingredients.Add(tSauce);
            pizza1.Ingredients.Add(cheese);
            pizza1.Ingredients.Add(spice);


        }
    }
}
