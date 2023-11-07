using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using Praktika.Resursi.DataBase;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                Metodi m = new Metodi();
            if (Dannie.Role == "Организаторы")
            {
                Organizator.Visibility = Visibility.Visible;
                Registracia.Visibility = Visibility.Visible;
            }
            else
            {
                Organizator.Visibility = Visibility.Collapsed;
                Registracia.Visibility = Visibility.Collapsed;
            }
                Avatar.Source = m.ZagruskaAvatara();
                List<MeropriyatiaItem> ls = ListMeropriyatiy(new List<MeropriyatiaItem>());
            Tablica.ItemsSource = ls.ToList();
        }

        public List<MeropriyatiaItem> ListMeropriyatiy (List<MeropriyatiaItem> list)
        {
            using (DB db = new DB())
            {
                foreach (var item in db.Meropriyatia)
                {
                    MeropriyatiaItem n = new MeropriyatiaItem(item.Sobitie, item.Data.Value.Date.ToShortDateString().ToString());     
                    list.Add(n);
                }
                return list;
            }
        }

        private void Avtorizacia_Click(object sender, RoutedEventArgs e)
        {
            Avtorizacia av = new Avtorizacia();
            this.Close();
            av.ShowDialog();
        }

        private void Organizator_Click(object sender, RoutedEventArgs e)
        {
            OknoOrganizatora org = new OknoOrganizatora();
            this.Close();
            org.ShowDialog();
        }

        private void Registracia_Click(object sender, RoutedEventArgs e)
        {
            Registracia reg = new Registracia();
            this.Close();
            reg.ShowDialog();
        }
    }
}
