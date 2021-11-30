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
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace cw7
{
    public class Wiersz
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Wiersz(string imie, int id, string nazwisko)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public Wiersz()
        {

        }
    }
    public class Wiersz_ksiazki
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Wypozyczona { get; set; }
        public Wiersz_ksiazki(string tytul, int id, string autor, string wypozyczona)
        {
            Id = id;
            Tytul = tytul;
            Autor = autor;
            Wypozyczona = wypozyczona;
        }
        public Wiersz_ksiazki()
        {

        }
    }
    public partial class MainWindow : Window
    {
        int index = 0;
        int id = 0; 
        public List<Wiersz> lista_czytelnikow = new List<Wiersz>();
        public List<Wiersz_ksiazki> lista_ksiazek = new List<Wiersz_ksiazki>();
        public MainWindow()
        {
            InitializeComponent();
            string plik = "zapis_czytelnikow.xml";
            lista_czytelnikow = WczytajXML<Wiersz>(plik);
            foreach (var zmienna in lista_czytelnikow)
            {
                Czytelnicy.Items.Add(zmienna);
            }
            string plik2 = "zapis_ksiazek.xml";
            lista_ksiazek = WczytajXML_ksiazki<Wiersz_ksiazki>(plik2);
            foreach (var zmienna in lista_ksiazek)
            {
                Ksiazki.Items.Add(zmienna);
            }
        }
        public List<Wiersz> WczytajXML<Wiersz>(string sciezka)
        {
            List<Wiersz> result = new List<Wiersz>();
            if (!System.IO.File.Exists(sciezka))
            {
                return new List<Wiersz>();
            }
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Wiersz>));
            using (FileStream myFileStream = new FileStream(sciezka, FileMode.Open))
            {
                result = (List<Wiersz>)serialiser.Deserialize(myFileStream);
            }
            return result;
        }
        public List<Wiersz_ksiazki> WczytajXML_ksiazki<Wiersz_ksiazki>(string sciezka)
        {
            List<Wiersz_ksiazki> result = new List<Wiersz_ksiazki>();
            if (!System.IO.File.Exists(sciezka))
            {
                return new List<Wiersz_ksiazki>();
            }
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Wiersz_ksiazki>));
            using (FileStream myFileStream = new FileStream(sciezka, FileMode.Open))
            {
                result = (List<Wiersz_ksiazki>)serialiser.Deserialize(myFileStream);
            }
            return result;
        }
        private void Dodaj_czytelnika_Click(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1();
            okno.ShowDialog();
            index = lista_czytelnikow.Count() + 1;
            Czytelnicy.Items.Add(new Wiersz(Window1.text1, index, Window1.text2));
            lista_czytelnikow.Add(new Wiersz(Window1.text1, index, Window1.text2));
        }
        private void Dodaj_ksiazke_Click(object sender, RoutedEventArgs e)
        {
            Window2 okno = new Window2();
            okno.ShowDialog();
            id = lista_ksiazek.Count() + 1;
            Ksiazki.Items.Add(new Wiersz_ksiazki(Window2.text3, id, Window2.text4, "--"));
            lista_ksiazek.Add(new Wiersz_ksiazki(Window2.text3, id, Window2.text4, "--"));
        }
        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Wypozycz_Click(object sender, RoutedEventArgs e)
        {
            var id_czytelnika = Czytelnicy.SelectedItem as Wiersz;
            var item = Ksiazki.SelectedItem as Wiersz_ksiazki;
            int i;
            i = item.Id - 1;
            if (item.Wypozyczona == "--")
            {
                item.Wypozyczona = id_czytelnika.Id.ToString();
                Ksiazki.Items[i] = new Wiersz_ksiazki(item.Tytul, item.Id, item.Autor, item.Wypozyczona);
                lista_ksiazek[i] = new Wiersz_ksiazki(item.Tytul, item.Id, item.Autor, item.Wypozyczona);
            }
        }

        private void Oddaj_Click(object sender, RoutedEventArgs e)
        {
            var item = Ksiazki.SelectedItem as Wiersz_ksiazki;
            int i;
            i = item.Id - 1;
            Ksiazki.Items[i] = new Wiersz_ksiazki(item.Tytul, item.Id, item.Autor, "--");
            lista_ksiazek[i] = new Wiersz_ksiazki(item.Tytul, item.Id, item.Autor, "--");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Wiersz_ksiazki>));
            StreamWriter Zapis = new StreamWriter("zapis_ksiazek.xml");
            serialiser.Serialize(Zapis, lista_ksiazek);
            Zapis.Close();
            XmlSerializer ser = new XmlSerializer(typeof(List<Wiersz>));
            StreamWriter Zapis2 = new StreamWriter("zapis_czytelnikow.xml");
            ser.Serialize(Zapis2, lista_czytelnikow);
            Zapis2.Close();
            base.OnClosing(e);
        }
    }
}
