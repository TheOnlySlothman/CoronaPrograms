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
                Margin = new Thickness(10, 0, 10, 10),
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
            RowDefinition rowDef3 = new RowDefinition();

            rowDef1.Height = GridLength.Auto;
            rowDef3.Height = GridLength.Auto;

            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);
            myGrid.RowDefinitions.Add(rowDef3);

            Border border = new Border
            {
                Background = Brushes.LightBlue,
                Height = 35,
                Padding = new Thickness(5),
            };
            Label label = new Label
            {
                VerticalAlignment = VerticalAlignment.Center,
                Content = "Pizza's",
            };

            border.Child = label;

            Grid.SetColumnSpan(border, 2);
            Grid.SetRow(border, 0);

            ListBox listBox = new ListBox();
            ListBoxItem[] listBoxItems = new ListBoxItem[3];

            for (int i = 0; i < listBoxItems.Length; i++)
            {
                listBoxItems[i] = new ListBoxItem();
                listBoxItems[i].Content = $"Pizza{i}";
            }
            listBox.ItemsSource = listBoxItems;


            Grid.SetColumn(listBox, 0);
            Grid.SetRow(listBox, 1);

            myGrid.Children.Add(border);
            myGrid.Children.Add(listBox);

            Content = myGrid;
            Show();
        }
    }
}
