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
using Praktika.Resursi.DataBase;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для Registracia.xaml
    /// </summary>
    public partial class Registracia : Window
    {
        public Registracia()
        {
            InitializeComponent();
            LabelMeropriyatia.Visibility = Visibility.Hidden;
            MeropriyatiyaCombo.Visibility = Visibility.Hidden;
            using (DB db = new DB())
            {
                Random rnd = new Random();
                Avatar.Source = new BitmapImage(new Uri($"Resursi/Foto/JuriFoto/foto{rnd.Next(1, 30)}.jpg", UriKind.Relative));
                IdNumber.Text = $"{db.Polzovateli.ToList().Last().ID + 1}";
                MeropriyatiyaCombo.ItemsSource = db.MeropriyatiaTipi.ToList().Select(x => x.TipMeropriyatia);
                Napravlenie.ItemsSource = db.Napravleniya.ToList().Select(x => x.Napravleniya1);
                Napravlenie.SelectedIndex = 0;
                MeropriyatiyaCombo.SelectedIndex = 0;
            }
        }
        public bool prikrepitMeropriyatie { get; set; }

        private void PrikrepitMeropryatie_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelMeropriyatia.Visibility = Visibility.Hidden;
            MeropriyatiyaCombo.Visibility = Visibility.Hidden;
            this.prikrepitMeropriyatie = false;
        }

        private void PrikrepitMeropryatie_Checked(object sender, RoutedEventArgs e)
        {
            LabelMeropriyatia.Visibility = Visibility.Visible;
            MeropriyatiyaCombo.Visibility = Visibility.Visible;
            this.prikrepitMeropriyatie = true;
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите прекратить регистрацию?", "Отменить регистрацию?", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                this.Close();
                mw.ShowDialog();
            }
            else
            {
                return;
            }
        }

        public bool PravilniyTelefon(string telefon)
        {
            telefon = telefon.Replace(" ", "");
            telefon = telefon.Replace("+7", "8");
            telefon = telefon.Replace("_", "");
            telefon = telefon.Replace("(", "");
            telefon = telefon.Replace(")", "");
            telefon = telefon.Replace("-", "");
            MessageBox.Show(telefon);
            if (telefon.Length == 11) return true;
            else return false;
        }
        public string ConvertirovanieTelefona(string telefon)
        {
            telefon = telefon.Replace(" ", "");
            telefon = telefon.Replace("+7", "8");
            telefon = telefon.Replace("_", "");
            telefon = telefon.Replace("(", "");
            telefon = telefon.Replace(")", "");
            telefon = telefon.Replace("-", "");
            return telefon;
        }

        public bool ProverkaParola(string parol)
        {
            List<char> specialsimvol = new List<char>() { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '=',
                                                        '"', '№',';', ':', '?', '_', '+', '[', ']','{', '}','<',
                                                        '>', ',', '.', '/', '\\', '|', '~'};
            if (parol.Length < 6) return false;
            if ((parol.Any(s => (s >= 'A' && s <= 'Z')) &&
               parol.Any(s => (s >= 'a' && s <= 'z'))) ||
                (parol.Any(s => (s >= 'А' && s <= 'Я')) &&
                    parol.Any(s => (s >= 'а' && s <= 'я'))) &&
                    parol.Any( s=> s == specialsimvol.FirstOrDefault(x => x == s)) &&
                    parol.Any(s => s >= '0' && s <= '9'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ProverkaFIOEMail ()
        {
            if(string.IsNullOrEmpty(FIO.Text) ||
                string.IsNullOrEmpty(Email.Text))
            {
                return "Некорректный ввод ФИО/Email (пустые строки)";
            }
            else
            {
                if (Email.Text.Any(s => s == '@')) return "+";
                else return "Некорректный ввод Email (отсутствие @)";
            }
        }

        public string ProverkaParola()
        {
            if(string.IsNullOrEmpty(Parol.Text) || string.IsNullOrEmpty(PovtorParola.Text))
            {
                return "Некорректный ввод пароля: пустые строки";
            }
            else
            {
                if(ProverkaParola(Parol.Text.Replace(" ", "")))
                {
                    if(PovtorParola.Text.Replace(" ", "") == Parol.Text.Replace(" ", ""))
                    {
                        return "+";
                    }
                    else
                    {
                        return "Пароли не совпадают";
                    }
                }
                else
                {
                    return  "Некорректный ввод пароля. Возможно отсутствуют:\n -заглавные и строчные боквы(A-Z / А-Я)\n-" +
                        " отсутсвуют цифры (0 - 9)\n - отсутствуют спец. символы (!,@ и др)";
                }
            }
        }


        private void Ok_Click(object sender, RoutedEventArgs e)
        { 
            using (DB db = new DB()) 
            { 
                string proverkaParola = ProverkaParola();
                string proverkaFIOEmail = ProverkaFIOEMail(); 
                bool telefon = PravilniyTelefon(Telefon.Text);
                if (proverkaParola == "+" &&
                    proverkaFIOEmail == "+" && telefon)
                {
                        Polzovateli polz = new Polzovateli();
                        polz.FIO = FIO.Text;
                        polz.ID = int.Parse(IdNumber.Text.Replace(" ", ""));
                        polz.Pochta = Email.Text.Replace(" ", "");
                        polz.Parol = Parol.Text.Replace(" ", "");
                        polz.Foto = Avatar.Source.ToString().Split('/')[3].Replace(" ", "");
                        polz.Telefon = ConvertirovanieTelefona(Telefon.Text);
                        polz.DataRojdenia = DateTime.Now.AddYears(-18);

                        db.Polzovateli.Add(polz);

                    Napravleniya_Polzovateli napr = new Napravleniya_Polzovateli()
                    {
                        IDNapravleniya = db.Napravleniya.FirstOrDefault(x => x.Napravleniya1 == Napravlenie.Text).ID,
                        IDPolzovatela = int.Parse(IdNumber.Text.Replace(" ", ""))
                    };
                    db.Napravleniya_Polzovateli.Add(napr);

                    Roli_Polzovateli rol = new Roli_Polzovateli()
                    {
                        IDPolzovatelya = int.Parse(IdNumber.Text.Replace(" ", "")),
                        IDRoli = db.Roli.FirstOrDefault(x => x.Navanie == Rol.Text).ID
                    };
                    Pol_Polzovateli pp = new Pol_Polzovateli()
                    {
                        IDPola = db.Pol.FirstOrDefault(x => x.Pol1 == Pol.Text.ToLower()).ID,
                        IDPolzovatelya = int.Parse(IdNumber.Text.Replace(" ", ""))
                    };
                    db.Roli_Polzovateli.Add(rol);
                    db.Pol_Polzovateli.Add(pp);
                    if (PrikrepitMeropryatie.IsChecked == true)
                        {
                        Polzovateli_MeropriyatiaTipi pm = new Polzovateli_MeropriyatiaTipi()
                        {
                            IDPolzovatela = int.Parse(IdNumber.Text.Replace(" ", "")),
                            IDTipMeropriyatia = db.MeropriyatiaTipi.FirstOrDefault(x => x.TipMeropriyatia == MeropriyatiyaCombo.Text).ID
                        };
                        db.Polzovateli_MeropriyatiaTipi.Add(pm);
                        }
                    db.SaveChanges();
                    MessageBox.Show("Пользователь зарегестрирован!");
                }
                else
                {
                    if(telefon)
                    {
                            string oshibka = (proverkaParola == "+") ? proverkaFIOEmail : proverkaParola;
                            MessageBox.Show($"Ошибка: {oshibka}");
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: Некорректный ввод телефона");
                    }
                }
            }
        }
    }
}
