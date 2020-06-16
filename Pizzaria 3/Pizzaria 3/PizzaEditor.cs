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
        readonly PizzaShop f1;
        readonly Pizza pizza;

        public PizzaEditor(PizzaShop f1, Pizza pizza)
        {
            InitializeComponent();
            this.f1 = f1;
            this.pizza = pizza;
        }

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public List<CheckBox> toppingBoxes = new List<CheckBox>();
        public List<CheckBox> spiceBoxes = new List<CheckBox>();

        public bool ready = false;

        public void PizzaEditor_Load(object sender, EventArgs e)
        {


            BindingList<string> doughList = new BindingList<string>();
            BindingList<string> sizeList = new BindingList<string>();
            BindingList<string> cheeseList = new BindingList<string>();
            BindingList<string> sauceList = new BindingList<string>();


            foreach (var item in pizzaProperties.dough)
                doughList.Add(item.name);

            foreach (var item in pizzaProperties.sizes)
                sizeList.Add(item.name);

            foreach (var item in pizzaProperties.cheese)
                cheeseList.Add(item.name);

            foreach (var item in pizzaProperties.sauce)
                sauceList.Add(item.name);



            DoughBox.DataSource = doughList;
            SizeBox.DataSource = sizeList;
            CheeseBox.DataSource = cheeseList;
            SauceBox.DataSource = sauceList;
            /*
            DoughBox. = doughList.First();
            SizeBox.SelectedValue = sizeList.Last();
            */

            toppingBoxes.AddRange(GetCheckBoxes(ToppingPanel));

            spiceBoxes.AddRange(GetCheckBoxes(SpicePanel));

            CheckBoxSetup(toppingBoxes, Pizzaria.PProperties.toppings);
            CheckBoxSetup(spiceBoxes, Pizzaria.PProperties.spice);

            LabelUpdate();


            ready = true;

            //makes the pizza chosen from PizzaShop in the PizzaEditor
            foreach (var x in
            from x in pizzaProperties.cheese
            from y in pizza.Ingredients
            where x.name == y.name
            select x)
            {
                CheeseBox.Text = x.name;
            }

            foreach (var x in
            from x in pizzaProperties.sauce
            from y in pizza.Ingredients
            where x.name == y.name
            select x)
            {
                SauceBox.Text = x.name;
            }

            foreach (var (x, y) in from x in toppingBoxes
                                   from y in pizza.Ingredients
                                   select (x, y))
            {
                if (x.Text == y.name)
                {
                    x.Checked = true;
                }
            }

            foreach (var (x, y) in from x in spiceBoxes
                                   from y in pizza.Ingredients
                                   select (x, y))
            {
                if (x.Text == y.name)
                {
                    x.Checked = true;
                }
            }
        }

        //makes a list of checkboxes from inside a panel
        private List<CheckBox> GetCheckBoxes(Panel panel)
        {
            Control.ControlCollection controlCollection = panel.Controls;
            Control[] controls = new Control[controlCollection.Count];
            List<Control> controlsList = new List<Control>();
            List<CheckBox> checkBoxList = new List<CheckBox>();

            controlCollection.CopyTo(controls, 0);


            controlsList.AddRange(controls);

            foreach (CheckBox item in controlsList)
            {
                checkBoxList.Add(item);
            }

            checkBoxList.Reverse();

            return checkBoxList;
        }

        //sets the name of an array of checkboxes with names of ItemProperties
        private void CheckBoxSetup(List<CheckBox> checkBoxes, List<ItemProperty> properties)
        {
            List<ItemProperty> multIngredients = new List<ItemProperty>();

            multIngredients.AddRange(
                properties
                );

            CheckBox[] checkBoxArr = checkBoxes.ToArray();
            ItemProperty[] multIngredientsArr = multIngredients.ToArray();

            int amount = Math.Min(checkBoxArr.Length, multIngredientsArr.Length);

            for (int i = 0; i < amount; i++)
            {
                checkBoxArr[i].Text = multIngredients[i].name.ToString();
                checkBoxArr[i].Visible = true;
            }
        }

        //adds a Pizza to Checkout 
        private void AddPizzaButton_Click(object sender, EventArgs e)
        {

            IEnumerable<ItemProperty> i = from x in pizzaProperties.toppings
                                           where toppingBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;
            if (i.Count() > 4)
            {
                return;
            }

            Pizzaria.AddPizza(MakePizza());

            Pizzaria.RemoveZeroes();

            f1.dataGridView1.Rows.Clear();

            foreach (Item item in Pizzaria.Checkout)
            {
                f1.dataGridView1.Rows.Add(item.ToStringArray());
            }
            Close();
        }

        private void PizzaProperty_Changed(object sender, EventArgs e)
        {
            if (!ready) return;

            Pizza customPizza = MakePizza();

            textBox1.Text = customPizza.Price.ToString();
        }

        private Pizza MakePizza()
        {
            Pizza customPizza = new Pizza
            {
                Name = "custom pizza"
            };
            customPizza.Ingredients.Add(pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.sauce.Find(x => x.name == SauceBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.cheese.Find(x => x.name == CheeseBox.SelectedValue.ToString()));

            IEnumerable<ItemProperty> i = from x in pizzaProperties.toppings
                                           where toppingBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;
            customPizza.Ingredients.AddRange(i);

            IEnumerable<ItemProperty> j = from x in pizzaProperties.spice
                                           where spiceBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;
            customPizza.Ingredients.AddRange(j);


            customPizza.Size = pizzaProperties.sizes.Find(x => x.name == SizeBox.SelectedValue.ToString());

            customPizza.Amount = Convert.ToInt32(PizzaAmount.Value);

            return customPizza;
        }

        private void LabelUpdate()
        {
            GlutenBreadPrice.Text = $"Pizza can be made Gluten free for + {Pizzaria.PProperties.dough.Find(x => x.name == "Gluten-free").price - Pizzaria.PProperties.dough.First().price}";

            SizePrice.Text = $"Family size is {Pizzaria.PProperties.sizes.Find(x => x.name == "family size").price} times the price";

            ToppingPrice.Text = $"Toppings are 10 each";

            SpicePrice.Text = $"Spice is 5 each, chili is free";
        }

        private void PizzaEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }
    }
}
