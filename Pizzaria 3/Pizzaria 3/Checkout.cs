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
    public partial class Checkout : Form
    {
        readonly double total;
        readonly string discount;
        readonly Form f1;

        public Checkout(Form f1, double total, string discount)
        {
            InitializeComponent();
            this.total = total;
            this.discount = discount;
            this.f1 = f1;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            label1.Text = total.ToString();
            label2.Text = discount;
        }

        private void Checkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }
    }
}
