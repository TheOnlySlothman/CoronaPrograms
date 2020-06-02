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

        public Checkout(double total)
        {
            InitializeComponent();
            this.total = total;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            label1.Text = total.ToString();
        }
    }
}
