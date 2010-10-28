using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace FuAsync.Examples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<string> TextItems;

        public MainWindow()
        {
            InitializeComponent();
            TextItems = new BindingList<string>();

            TheItems.ItemsSource = TextItems;
        }

        private void TheButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMovies();
        }

        private void LoadMovies()
        {
            for(int i = 0; i < 10; i++)
            {
                var number = GetNumber(i);
                TextItems.Add("New number: " + number.ToString());
            }
        }

        private int GetNumber(int i)
        {   
            Thread.Sleep(1000);
            return i;
        }
    }
}
