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
using FuAsync.Futures;

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
            var result = LoadMovies();
            var futureSeq = new FutureSequence(result.GetEnumerator());
            futureSeq.Await(null);
        }

        private IEnumerable<IFuture> LoadMovies()
        {
            for(int i = 0; i < 10; i++)
            {
                var number = GetNumberAsync(i);
                yield return number;
                TextItems.Add("New number: " + number.Value);
            }
        }

        private IFuture<int> GetNumberAsync(int i)
        {   
            return FuA.DoInBackground<int>(() => {

                Thread.Sleep(1000);
                return i;  

            });
        }
    }
}
