using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GF2_Lommeregner_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char sign;
        double result = 0.0;
        bool hasResult = false;

        public MainWindow()
        {
            InitializeComponent();
        }



        private double Square(double height, double width)
        {
            return height * width;
        }

        private double Circle(double radius)
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

        private double Triangle(double height, double width)
        {
            return height * width / 2;
        }

        private double Trapezoid(double width1, double width2, double height)
        {
            return 0.5 * (width1 + width2) * height;
        }

        private double Cone(double radius, double height)
        {
            return Math.Pow(radius, 2) * Math.PI * height / 3;
        }
        #region numbers
        private void _0_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "0";
            text.Text = input;
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "1";
            text.Text = input;
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "2";
            text.Text = input;
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "3";
            text.Text = input;
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "4";
            text.Text = input;
        }

        private void _5_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "5";
            text.Text = input;
        }

        private void _6_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "6";
            text.Text = input;
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "7";
            text.Text = input;
        }

        private void _8_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "8";
            text.Text = input;
        }

        private void _9_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += "9";
            text.Text = input;
        }

        private void _Dot_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input += ",";
            text.Text = input;
        }
        #endregion
        private void _Clear_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            result = 0.0;
            hasResult = false;
        }

        #region operators
        private void _Add_Click(object sender, RoutedEventArgs e)
        {
            sign = '+';
            Calculate();
            input = string.Empty;

        }


        private void _Minus_Click(object sender, RoutedEventArgs e)
        {

            sign = '-';
            Calculate();
            input = string.Empty;
        }

        private void _Multiply_Click(object sender, RoutedEventArgs e)
        {
            sign = '*';
            Calculate();
            input = string.Empty;
        }

        private void _Divide_Click(object sender, RoutedEventArgs e)
        {
            sign = '/';
            Calculate();
            input = string.Empty;
        }
        #endregion
        private void _Equal_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            if (hasResult)
            {
                operand2 = input;
            }
            else
            {
                operand1 = input;
                hasResult = true;
                return;
            }
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            switch (sign)
            {
                case '+':
                    result = num1 + num2;
                    text.Text = result.ToString();
                    break;
                case '-':
                    result = num1 - num2;
                    text.Text = result.ToString();
                    break;
                case '*':
                    result = num1 * num2;
                    text.Text = result.ToString();
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        text.Text = result.ToString();
                    }
                    else
                    {
                        text.Text = "can't divide by 0";
                    }
                    break;
            }
            operand1 = result.ToString();
        }

        private void _Square_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
