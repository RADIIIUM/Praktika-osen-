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
using Praktika.Resursi.DataBase;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для OknoOrganizatora.xaml
    /// </summary>
    public partial class OknoOrganizatora : Window
    {
        public OknoOrganizatora()
        {
            InitializeComponent();
            using (DB db = new DB()) 
            {
                Metodi metodi = new Metodi();
                Avatar.Source = metodi.ZagruskaAvatara();
                string pol = db.Pol.FirstOrDefault(x => x.ID ==
                (db.Pol_Polzovateli.FirstOrDefault(y => y.IDPolzovatelya == Dannie.User.ID)).IDPola).Pol1;
                TimeSpan time = DateTime.Now.TimeOfDay;
                if (time.Hours >= 9 && (time.Hours <= 11 && time.Minutes == 0))
                {
                    SutkiText.Content = $"Доброе утро !";
                }
                if ((time.Hours >= 11 && time.Minutes > 0) && time.Hours <= 18)
                {
                    SutkiText.Content = $"Добрый день !";
                }
                if ((time.Hours >= 18 && time.Minutes > 0) && time.Hours <= 24)
                {
                    SutkiText.Content = $"Добрый вечер !";
                }
                switch (pol)
                {
                    case "женский":
                        Imya.Content = $"Mrs {Dannie.User.FIO.Split(' ')[1]}";
                        break;
                    case "мужской":
                        Imya.Content = $"Mr {Dannie.User.FIO.Split(' ')[1]}";
                        break;
                }
            }
        }

        private void Meropriyatia_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.ShowDialog();
        }

        private void Zaglushka_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заглушка");
        }
    }
}
