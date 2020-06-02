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
        readonly Form1 f1;
        Pizza pizza;

        public PizzaEditor(Form1 f1, Pizza pizza)
        {
            InitializeComponent();
            this.f1 = f1;
            this.pizza = pizza;
        }

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public List<CheckBox> checkBoxes = new List<CheckBox>();
        readonly Pizzaria pizzaria = new Pizzaria();

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

            checkBoxes.AddRange(new List<CheckBox>
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5,
                checkBox6,
                checkBox7,
                checkBox8,
                checkBox9,
                checkBox10
            });

            List<PizzaProperty> multIngredients = new List<PizzaProperty>();

            multIngredients.AddRange(
                pizzaProperties.toppings
                );

            CheckBox[] checkBoxArr = checkBoxes.ToArray();
            PizzaProperty[] multIngredientsArr = multIngredients.ToArray();

            int amount = Math.Min(checkBoxArr.Length, multIngredientsArr.Length);

            for (int i = 0; i < amount; i++)
            {
                checkBoxArr[i].Text = multIngredients[i].name.ToString();
            }
            ready = true;

            //CheeseBox.DisplayMember = pizza.Ingredients.Find(x => pizzaria.Properties.cheese).name;
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

            foreach (var (x, y) in from x in checkBoxes
                                   from y in pizza.Ingredients
                                   select (x, y))
            {
                if (x.Text == y.name)
                {
                    x.Checked = true;
                    break;
                }
                else
                {
                    x.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            IEnumerable<double> i = from x in pizzaProperties.dough
                    where x.name == DoughBox.SelectedValue.ToString()
                    select x.price;
                    */

            Pizza customPizza = new Pizza();
            customPizza.Ingredients.Add(pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.sauce.Find(x => x.name == SauceBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.cheese.Find(x => x.name == CheeseBox.SelectedValue.ToString()));

            IEnumerable<PizzaProperty> j = from x in pizzaProperties.toppings
                                           where checkBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;

            customPizza.Ingredients.AddRange(j);
            customPizza.Size = pizzaProperties.sizes.Find(x => x.name == SizeBox.SelectedValue.ToString());

            pizzaria.Checkout.Add(customPizza);

            customPizza.Name = "Custom Pizza";

            customPizza.Amount = Convert.ToInt32(PizzaAmount.Value);

            string[] row = customPizza.ToStringArray();

            f1.dataGridView1.Rows.Add(row);
            Close();
        }

        private void PizzaProperty_Changed(object sender, EventArgs e)
        {
            if (!ready) return;

            Pizza customPizza = new Pizza();
            customPizza.Ingredients.Add(pizzaProperties.sauce.Find(x => x.name == SauceBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.cheese.Find(x => x.name == CheeseBox.SelectedValue.ToString()));
            IEnumerable<PizzaProperty> j = from x in pizzaProperties.toppings
                                           where checkBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;
            customPizza.Ingredients.AddRange(j);
            customPizza.Ingredients.Add(pizzaProperties.dough.Find(x => x.name == DoughBox.SelectedValue.ToString()));


            customPizza.Size = pizzaProperties.sizes.Find(x => x.name == SizeBox.SelectedValue.ToString());

            customPizza.Amount = Convert.ToInt32(PizzaAmount.Value);

            textBox1.Text = customPizza.GetPrice().ToString();
        }
    }
}
