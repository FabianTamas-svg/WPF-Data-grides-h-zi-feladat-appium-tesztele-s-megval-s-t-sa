using System.Collections.ObjectModel;
using System.Windows;
using WpfGyakorlat;

namespace WpfGyakorlat_Fabian 
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Diak> Diakok { get; set; }

        public MainWindow()
        {
            InitializeComponent(); 

            Diakok = new ObservableCollection<Diak>
            {
                new Diak { Nev = "Fábián Tamás", Osztaly = "13.SZFT", Matek = 5, Fizika = 4 },
                new Diak { Nev = "Teszt Elek", Osztaly = "13.SZFT", Matek = 3, Fizika = 5 }
            };

            dgDiakok.ItemsSource = Diakok;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgDiakok.Items.Refresh();
            MessageBox.Show("Adatok frissítve!");
        }
    }
}