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

        public PizzaProperties pizzaProperties = new PizzaProperties();
        Pizzaria pizzaria = new Pizzaria();

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Pizza pizza2 = new Pizza();
            pizza2.Dough = nDough;
            pizza2.Size = nSize;
            pizza2.Ingredients.Add(tSauce);
            pizza2.Ingredients.Add(cheese);
            pizza2.Ingredients.Add(peperoni);
            */
            Control.ControlCollection controlCollection = panel1.Controls;
            Control[] controls = new Control[controlCollection.Count];
            List<Control> controlsList = new List<Control>();

            controlCollection.CopyTo(controls, 0);


            controlsList.AddRange(controls);

            controlsList.First(x => x.Name.Contains("name")).Text = pizzaria.Pizzas.Find(y => y.Id == 1).Name;
            controlsList.First(x => x.Name.Contains("price")).Text = pizzaria.Pizzas.Find(y => y.Id == 1).GetPrice().ToString();

            BindingList<string> doughList = new BindingList<string>();
            BindingList<string> sizeList = new BindingList<string>();

            foreach (var item in pizzaProperties.dough)
                doughList.Add(item.name);

            foreach (var item in pizzaProperties.sizes)
                sizeList.Add(item.name);

            DoughBox.DataSource = doughList;
            SizeBox.DataSource = sizeList;
        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            PizzaEditor EditorForm = new PizzaEditor(this);
            EditorForm.Show();
            //   this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<RadioButton> pizzaChoice = new List<RadioButton>()
            {
                Pizza1RadioButton,
                Pizza2RadioButton
            };

            int result = Convert.ToInt32(pizzaChoice.Find(x => x.Checked).Tag);

            Pizza selectedPizza = pizzaria.Pizzas.Find(x => x.Id == result);

            selectedPizza.Ingredients.Add(pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));

            selectedPizza.Size = pizzaProperties.sizes.Find(x => x.name == SizeBox.SelectedValue.ToString());
            /*
            List<PizzaProperty> pizza1 = new List<PizzaProperty>();
            List<PizzaProperty> pizza2 = new List<PizzaProperty>();

            pizza1.AddRange(selectedPizza.Ingredients);

            foreach (var item in pizzaria.Checkout)
            {
                item.Ingredients
            }

            selectedPizza.Ingredients.Sort(delegate (PizzaProperty property1, PizzaProperty property2) { return property1.name.CompareTo(property2.name); }) ;
            */
            /*
            Pizza pizza3 = pizzaria.Pizzas.Find(x => x.Id == 3);
            Pizza pizza4 = pizzaria.Pizzas.Find(x => x.Id == 4);

            pizza3.Ingredients.
            */
            foreach (var item in pizzaria.Checkout)
            {
                if (item.Ingredients.containsall(selectedPizza.Ingredients) && item.Ingredients.Count == selectedPizza.Ingredients.Count)
                {

                }

            }


            for (int i = 0; i < PizzaAmount.Value; i++)
            {

                pizzaria.Checkout.Add(selectedPizza);

                dataGridView1.Rows.Add(selectedPizza.ToStringArray());

            }


                /*
                 * Control.ControlCollection controlCollection = panel1.Controls;
            Control[] controls = new Control[controlCollection.Count];
            List<Control> controlsList = new List<Control>();

            controlCollection.CopyTo(controls, 0);


            controlsList.AddRange(controls);
            */
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
    }
}
