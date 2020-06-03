using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public DrinkProperties drinkProperties = new DrinkProperties();
        readonly Pizzaria pizzaria = new Pizzaria();

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

            GlutenBreadPrice.Text = $"Gluten-Free bread is +{pizzaria.PProperties.dough.Find(x => x.name == "Gluten-free").price - pizzaria.PProperties.dough.First().price}";

            SizePrice.Text = $"Family size is *{pizzaria.PProperties.sizes.Find(x => x.name == "family size").price} prize";

            DrinkPrice.Text = $"Drinks:\n" +
                $"Small: {new Drink(pizzaria.DProperties.sizes.Find(x => x.name == "small")).GetPrice()}\n" +
                $"Medium: {new Drink(pizzaria.DProperties.sizes.Find(x => x.name == "medium")).GetPrice()}\n" +
                $"Large: {new Drink(pizzaria.DProperties.sizes.Find(x => x.name == "large")).GetPrice()}";

            ready = true;

            PizzaPrice_Update(sender, e);
            DrinkName_Update(sender, e);

        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            PizzaEditor EditorForm = new PizzaEditor(this, MakePizza(ItemChoice()));
            EditorForm.Show();
            //   this.Hide();
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

        private Pizza MakePizza(int result)
        {

            Pizza pizza;

            try
            {
                pizza = pizzaria.Pizzas.Find(x => x.Id == result).GetPizza();
            }
            catch (NullReferenceException)
            {
                pizza = new Pizza();
            }
            pizza.Ingredients.Insert(0, pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));

            pizza.Size = pizzaProperties.sizes.Find(x => x.name == PizzaSizeBox.SelectedValue.ToString());

            return pizza;
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            int i = ItemChoice();
            bool alreadyAdded = false;

            if (i > 0 && i < 50)
            {
                Pizza selectedPizza;
                selectedPizza = MakePizza(i);
                selectedPizza.Amount = Convert.ToInt32(ItemAmount.Value);

                foreach (Pizza pizza in pizzaria.Checkout.Where(x => x.GetType() == selectedPizza.GetType()))
                    if (pizza.Ingredients.All(x => selectedPizza.Ingredients.Contains(x) && pizza.Ingredients.Count == selectedPizza.Ingredients.Count && selectedPizza.Size == pizza.Size))
                    {
                        pizza.Amount += selectedPizza.Amount;
                        alreadyAdded = true;
                        break;
                    }
                if (!alreadyAdded)
                    pizzaria.Checkout.Add(selectedPizza);
            }
            else if (i >= 50)
            {
                Drink selectedDrink = pizzaria.Drinks.Find(x => x.Id == i).GetDrink();
                selectedDrink.Amount = Convert.ToInt32(ItemAmount.Value);
                selectedDrink.Size = pizzaria.DProperties.sizes.Find(x => x.name == DrinkSizeBox.Text);

                foreach (Drink drink in pizzaria.Checkout.Where(x => x.GetType() == selectedDrink.GetType()))
                    if (drink.Size == selectedDrink.Size && drink.Name == selectedDrink.Name)
                    {
                        drink.Amount += selectedDrink.Amount;
                        alreadyAdded = true;
                        break;
                    }

                if (!alreadyAdded)
                    pizzaria.Checkout.Add(selectedDrink);
            }
            else
            {
                return;
            }


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






            dataGridView1.Rows.Clear();

            foreach (Item item in pizzaria.Checkout)
            {
                dataGridView1.Rows.Add(item.ToStringArray());
            }


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

        public void AddItem()
        {

        }

        private void PizzaPrice_Update(object sender, EventArgs e)
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

            Pizza selectedPizza = pizzaria.Pizzas.Find(y => y.Id == Convert.ToInt32(panel.Tag)).GetPizza();

            selectedPizza.Ingredients.Insert(0, pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));

            selectedPizza.Size = pizzaProperties.sizes.Find(x => x.name == PizzaSizeBox.SelectedValue.ToString());

            controlsList.First(x => x.Name.Contains("name")).Text = selectedPizza.Name;
            controlsList.First(x => x.Name.Contains("price")).Text = selectedPizza.GetPrice().ToString();
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            int pizzaAmount = 0;
            int drinkAmount = 0;
            string checkoutText;

            foreach (Pizza pizza in pizzaria.Checkout.Where(x => x.GetType() == new Pizza().GetType()))
                pizzaAmount += pizza.Amount;

            foreach (Drink drink in pizzaria.Checkout.Where(x => x.GetType() == new Drink().GetType()))
                drinkAmount += drink.Amount;

            double discount = 0.0;
            if (pizzaAmount >= 2 && drinkAmount >= 2)
            {
                foreach (Pizza pizza in pizzaria.Checkout.Where(x => x.GetType() == new Pizza().GetType()))
                {

                        IEnumerable<ItemProperty> i = from dough in pizzaria.PProperties.dough
                                                      where pizza.Ingredients.Any(x => x.name == dough.name)
                                                      select dough;

                        if (discount < (i.First().price *= pizza.Size.price))
                        {
                            discount = i.First().price;
                        }
                }
                    
            }

            checkoutText = "discount: " + discount;


            Checkout checkout = new Checkout(pizzaria.GetTotal() - discount, checkoutText);
            checkout.Show();
        }

        private void DrinkName_Update(object sender, EventArgs e)
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
                item.Text = pizzaria.Drinks.Find(y => y.Id == Convert.ToInt32(item.Tag)).Name;
            }

        }

    }
}
