/*
 * Time Calculator
 * Assignment #4 PROG8010, Group 1
 * Author: Lucas Currah, 7674542
 * Conestoga College
 * 
 * Group members:
 *      Oleksandr Rudavka
 *      Jonathan Nagata
 *      Niral Gandhi
 *      Tanmay Teckchandani
 *      Priya Tharuman
 *      Krishna Kanhaiya
 *      Lucas Currah
 * 
 * 3 October, 2016
 */
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
        {   // function for removing not digits from the input variable _seconds
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
