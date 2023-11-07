using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Window
    {
        public Avtorizacia()
        {
            InitializeComponent();
        }

        private void PokazatParol_Unchecked(object sender, RoutedEventArgs e)
        {
            PBParol.Password = TBParol.Text;
            TBParol.Text = null;
            PBParol.Visibility = Visibility.Visible;
            TBParol.Visibility = Visibility.Hidden;
        }

        private void PokazatParol_Checked(object sender, RoutedEventArgs e)
        {
            TBParol.Text = PBParol.Password;
            PBParol.Password = null;
            PBParol.Visibility = Visibility.Hidden;
            TBParol.Visibility = Visibility.Visible;
        }

        private void AvtorizaciaButton_Click(object sender, RoutedEventArgs e)
        {
            string login;
            string parol;
            if(string.IsNullOrEmpty(TBParol.Text))
            {
                login = Login.Text;
                parol = PBParol.Password;
            }
            else
            {
                login = Login.Text;
                parol = TBParol.Text;
            }

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(parol))
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка!");
            }
            else
            {
                using(DB db = new DB())
                {
                    Polzovateli polzovatel = db.Polzovateli.FirstOrDefault(x => x.ID.ToString() == login && x.Parol == parol);
                    if(polzovatel != null)
                    {
                        Dannie.Role = db.Roli.FirstOrDefault(x => x.ID == (db.Roli_Polzovateli.FirstOrDefault(y => y.IDPolzovatelya == polzovatel.ID).IDRoli)).Navanie;
                        Dannie.User = polzovatel;
                        Dannie.Autorization = true;
                        MessageBox.Show($"Успешная авторизация") ;
                        MainWindow mw = new MainWindow();
                        this.Close();
                        mw.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин/пароль", "Ошибка!");
                    }
                }
            }
        }

        private void GlavnoeMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.ShowDialog();
        }
    }
}
