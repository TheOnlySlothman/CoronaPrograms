﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria_3
{
    public partial class PizzaShop : Form
    {
        public PizzaShop()
        {
            InitializeComponent();
        }

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public DrinkProperties drinkProperties = new DrinkProperties();

        public bool ready = false;
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




            BindingList<string> doughList = new BindingList<string>();
            BindingList<string> pizzaSizeList = new BindingList<string>();
            BindingList<string> drinkSizeList = new BindingList<string>();


            foreach (var item in pizzaProperties.dough)
                doughList.Add(item.name);

            foreach (var item in pizzaProperties.sizes)
                pizzaSizeList.Add(item.name);

            foreach (var item in drinkProperties.sizes)
                drinkSizeList.Add(item.name);

            DoughBox.DataSource = doughList;
            PizzaSizeBox.DataSource = pizzaSizeList;
            DrinkSizeBox.DataSource = drinkSizeList;

            LabelUpdate();

            ready = true;

            PizzaPriceUpdate(sender, e);
            DrinkNameUpdate(sender, e);

        }

        private void LabelUpdate()
        {
            GlutenBreadPrice.Text = $"Pizza can be made Gluten free for +{Pizzaria.PProperties.dough.Find(x => x.name == "Gluten-free").price - Pizzaria.PProperties.dough.First().price}";

            SizePrice.Text = $"Family size is {Pizzaria.PProperties.sizes.Find(x => x.name == "family size").price} times the price";

            DrinkPrice.Text = $"Drinks:\n" +
                $"Small: {new Drink(Pizzaria.DProperties.sizes.Find(x => x.name == "small")).Price}\n" +
                $"Medium: {new Drink(Pizzaria.DProperties.sizes.Find(x => x.name == "medium")).Price}\n" +
                $"Large: {new Drink(Pizzaria.DProperties.sizes.Find(x => x.name == "large")).Price}";
        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            PizzaEditor EditorForm = new PizzaEditor(this, MakePizza(ItemChoice()));
            EditorForm.Show();
               this.Hide();
        }

        private int ItemChoice()
        {
            List<RadioButton> ItemChoice = new List<RadioButton>()
            {
                Pizza1RadioButton,
                Pizza2RadioButton,
                Pizza3RadioButton,
                Drink1RadioButton,
                Drink2RadioButton,
                Drink3RadioButton
            };

            return Convert.ToInt32(ItemChoice.Find(x => x.Checked).Tag);
        }

        private Pizza MakePizza(int i)
        {

            Pizza pizza;

            try
            {
                pizza = Pizzaria.Pizzas.Find(x => x.Id == i).GetPizza();
            }
            catch (NullReferenceException)
            {
                pizza = new Pizza(i, "", new List<ItemProperty>
                {
                    Pizzaria.PProperties.cheese.Find(x => x.name == "pizza cheese"),
                    Pizzaria.PProperties.sauce.Find(x => x.name == "tomato sauce"),
                });
            }
            pizza.Ingredients.Insert(0, pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));

            pizza.Size = pizzaProperties.sizes.Find(x => x.name == PizzaSizeBox.SelectedValue.ToString());

            pizza.Amount = Convert.ToInt32(ItemAmount.Value);

            return pizza;
        }

        private Drink MakeDrink(int i)
        {
            Drink drink;

            try
            {
                drink = Pizzaria.Drinks.Find(x => x.Id == i).GetDrink();
            }
            catch (NullReferenceException)
            {
                drink = new Drink();
            }

            drink.Size = drinkProperties.sizes.Find(x => x.name == DrinkSizeBox.SelectedValue.ToString());

            drink.Amount = Convert.ToInt32(ItemAmount.Value);

            return drink;
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            int i = ItemChoice();

            if (i > 0 && i < 50)
            {
                Pizzaria.AddPizza(MakePizza(ItemChoice()));
            }
            else if (i >= 50)
            {
                Pizzaria.AddDrink(MakeDrink(ItemChoice()));
            }
            else
            {
                return;
            }

            UpdateDataGrid();

            #region
            /*
            Pizza selectedPizza = MakePizza(ItemChoice());




            selectedPizza.Amount = Convert.ToInt32(PizzaAmount.Value);

            List<PizzaProperty> pizza1 = new List<PizzaProperty>();
            List<PizzaProperty> pizza2 = new List<PizzaProperty>();

            pizza1.AddRange(selectedPizza.Ingredients);

            foreach (var item in pizzaria.Checkout)
            {
                item.Ingredients
            }

            selectedPizza.Ingredients.Sort(delegate (PizzaProperty property1, PizzaProperty property2) { return property1.name.CompareTo(property2.name); }) ;
           
            Pizza pizza3 = pizzaria.Pizzas.Find(x => x.Id == 3);
            Pizza pizza4 = pizzaria.Pizzas.Find(x => x.Id == 4);

            pizza3.Ingredients.
            */
            #endregion

            #region
            /*
             * Control.ControlCollection controlCollection = panel1.Controls;
        Control[] controls = new Control[controlCollection.Count];
        List<Control> controlsList = new List<Control>();

        controlCollection.CopyTo(controls, 0);


        controlsList.AddRange(controls);
        */
            #endregion
        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();

            Pizzaria.RemoveZeroes();

            foreach (Item item in Pizzaria.Checkout)
            {
                dataGridView1.Rows.Add(item.ToStringArray());
            }
        }

        private void PizzaPriceUpdate(object sender, EventArgs e)
        {
            if (!ready) return;

            List<Panel> panels = new List<Panel>
            {
                panel1,
                panel2,
                panel3
            };

            foreach (Panel panel in panels)
            {
                UpdatePanel(panel);
            }
        }

        private void UpdatePanel(Panel panel)
        {
            Control.ControlCollection controlCollection = panel.Controls;
            Control[] controls = new Control[controlCollection.Count];
            List<Control> controlsList = new List<Control>();

            controlCollection.CopyTo(controls, 0);


            controlsList.AddRange(controls);

            Pizza selectedPizza = Pizzaria.Pizzas.Find(y => y.Id == Convert.ToInt32(panel.Tag)).GetPizza();

            selectedPizza.Ingredients.Insert(0, pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));

            selectedPizza.Size = pizzaProperties.sizes.Find(x => x.name == PizzaSizeBox.SelectedValue.ToString());

            controlsList.First(x => x.Name.Contains("name")).Text = selectedPizza.Name;
            controlsList.First(x => x.Name.Contains("price")).Text = selectedPizza.Price.ToString();
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            int pizzaAmount = 0;
            int drinkAmount = 0;
            string checkoutText;

            foreach (Pizza pizza in Pizzaria.Checkout.Where(x => x.GetType() == new Pizza().GetType()))
                pizzaAmount += pizza.Amount;

            foreach (Drink drink in Pizzaria.Checkout.Where(x => x.GetType() == new Drink().GetType()))
                drinkAmount += drink.Amount;

            double discount = 0.0;
            if (pizzaAmount >= 2 && drinkAmount >= 2)
            {
                foreach (Pizza pizza in Pizzaria.Checkout.Where(x => x.GetType() == new Pizza().GetType()))
                {

                        IEnumerable<ItemProperty> i = from dough in Pizzaria.PProperties.dough
                                                      where pizza.Ingredients.Any(x => x.name == dough.name)
                                                      select dough;

                        if (discount < (i.First().price * pizza.Size.price))
                        {
                            discount = i.First().price * pizza.Size.price;
                        }
                }
                    
            }

            checkoutText = "discount: " + discount;


            Checkout checkout = new Checkout(this, Pizzaria.Total - discount, checkoutText);
            this.Hide();
            checkout.Show();
            Pizzaria.Checkout.Clear();
            UpdateDataGrid();
            //discount = 0.0;
        }

        private void DrinkNameUpdate(object sender, EventArgs e)
        {
            if (!ready) return;

            List<RadioButton> DrinkRadioButtons = new List<RadioButton>
            {
                Drink1RadioButton,
                Drink2RadioButton,
                Drink3RadioButton
            };

            foreach (var item in DrinkRadioButtons)
            {
                item.Text = Pizzaria.Drinks.Find(y => y.Id == Convert.ToInt32(item.Tag)).Name;
            }

        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            List<int> i = new List<int>();

            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                i.Add(item.Index);
                
            }

            foreach (int item in i)
            {
                Pizzaria.Checkout.RemoveAt(item);
                UpdateDataGrid();
            }
        }
    }
}
