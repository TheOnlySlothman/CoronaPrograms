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
        readonly Pizza pizza;

        public PizzaEditor(Form1 f1, Pizza pizza)
        {
            InitializeComponent();
            this.f1 = f1;
            this.pizza = pizza;
        }

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public List<CheckBox> toppingBoxes = new List<CheckBox>();
        public List<CheckBox> spiceBoxes = new List<CheckBox>();
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

            toppingBoxes.AddRange(GetCheckBoxes(ToppingPanel));

            spiceBoxes.AddRange(GetCheckBoxes(SpicePanel));

            CheckBoxSetup(toppingBoxes, pizzaria.PProperties.toppings);
            CheckBoxSetup(spiceBoxes, pizzaria.PProperties.spice);


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
            }
        }

        private void AddPizzaButton_Click(object sender, EventArgs e)
        {

            IEnumerable<ItemProperty> i = from x in pizzaProperties.toppings
                                           where toppingBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                           select x;
            if (i.Count() > 4)
            {
                return;
            }

            Pizza customPizza = MakePizza();

            string[] row = customPizza.ToStringArray();

            f1.dataGridView1.Rows.Add(row);
            Close();
        }

        private void PizzaProperty_Changed(object sender, EventArgs e)
        {
            if (!ready) return;

            Pizza customPizza = MakePizza();

            textBox1.Text = customPizza.GetPrice().ToString();
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
    }
}
