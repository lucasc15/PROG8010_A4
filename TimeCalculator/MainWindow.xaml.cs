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

namespace TimeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        // KeyConverter kc = new KeyConverter();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void btnCalculateClick(object sender, RoutedEventArgs e)
        {
            vm.ConvertTime();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int _;
            TextBox txtBox = (TextBox)sender;
            for (var i=0; i<txtBox.Text.Length; i++)
            {
                if (!int.TryParse(txtBox.Text[i].ToString(), out _))
                {
                    txtBox.Text = txtBox.Text.Remove(i, 1);
                }
            }
        }
    }
}
