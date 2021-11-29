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
using System.Windows.Shapes;

namespace cw7
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public static string text1;
        public static string text2;
        private void Imie_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            text1 = Imie.Text;
        }
        private void Nazwisko_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            text2 = Nazwisko.Text;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
