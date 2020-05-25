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

        public PizzaProperties pizzaProperties = new PizzaProperties();
        public List<CheckBox> checkBoxes = new List<CheckBox>();

        public void PizzaEditor_Load(object sender, EventArgs e)
        {
            Pizzaria pizzaria;

            BindingList<string> doughList = new BindingList<string>();
            BindingList<string> sizeList = new BindingList<string>();
            BindingList<string> cheeseList = new BindingList<string>();
            BindingList<string> sauceList = new BindingList<string>();


            foreach (var item in pizzaProperties.dough)
            {
                doughList.Add(item.name);
            }
            foreach (var item in pizzaProperties.sizes)
            {
                sizeList.Add(item.name);
            }
            foreach (var item in pizzaProperties.cheese)
            {
                cheeseList.Add(item.name);
            }
            foreach (var item in pizzaProperties.sauce)
            {
                sauceList.Add(item.name);
            }


            DoughBox.DataSource = doughList;
            SizeBox.DataSource = sizeList;
            CheeseBox.DataSource = cheeseList;
            SauceBox.DataSource = sauceList;

            
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
            customPizza.Ingredients.Add(pizzaProperties.cheese.Find(x => x.name == CheeseBox.SelectedValue.ToString()));
            customPizza.Ingredients.Add(pizzaProperties.sauce.Find(x => x.name == SauceBox.SelectedValue.ToString()));

            IEnumerable<PizzaProperty> j = from x in pizzaProperties.toppings
                                    where checkBoxes.Any(y => y.Checked == true && x.name == y.Text)
                                    select x;
            customPizza.Ingredients.AddRange(j);
            customPizza.Size = pizzaProperties.sizes.Find(x => x.name == SizeBox.SelectedValue.ToString());

            textBox1.Text = customPizza.getPrice().ToString();
        }
    }
}
