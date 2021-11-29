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
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public static string text3;
        public static string text4;
        private void Tytul_TextChanged(object sender, TextChangedEventArgs e)
        {
            text3 = Tytul.Text;
        }
        private void Autor_TextChanged(object sender, TextChangedEventArgs e)
        {
            text4 = Autor.Text;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
