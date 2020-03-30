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

namespace Pizzaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Grid myGrid = new Grid
            {
                Width = 150,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ShowGridLines = true
            };

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);

            Grid x = PizzaGrid("test1", "test2", "test3");

            Grid.SetColumn(x, 0);
            Grid.SetRow(x, 0);
            
            Grid y = PizzaGrid("test4", "test5", "test6");

            Grid.SetColumn(y, 1);
            Grid.SetRow(y, 0);
            
            Content = myGrid;
            Show();
        }

        public Grid PizzaGrid(string name, string price, string description)
        {
            Grid myGrid = new Grid
            {
                Width = 150,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ShowGridLines = true
            };

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);

            // Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock
            {
                Text = name,
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            Grid.SetColumn(txt1, 0);
            Grid.SetRow(txt1, 0);

            // Add the second text cell to the Grid
            TextBlock txt2 = new TextBlock
            {
                Text = price,
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(txt2, 0);
            Grid.SetColumn(txt2, 1);

            // Add the third text cell to the Grid
            TextBlock txt3 = new TextBlock
            {
                Text = description,
                FontSize = 12,
                FontWeight = FontWeights.Bold
            };
            Grid.SetRow(txt3, 1);
            Grid.SetColumnSpan(txt3, 2);

            // Add the TextBlock elements to the Grid Children collection
            myGrid.Children.Add(txt1);
            myGrid.Children.Add(txt2);
            myGrid.Children.Add(txt3);

            return myGrid;
        }
    }
}
