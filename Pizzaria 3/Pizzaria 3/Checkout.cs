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

        public Checkout(double total, string discount)
        {
            InitializeComponent();
            this.total = total;
            this.discount = discount;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            label1.Text = total.ToString();
            label2.Text = discount;
        }
    }
}
