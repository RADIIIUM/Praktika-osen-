using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Praktika
{
    public partial class Metodi
    {
        public BitmapImage ZagruskaAvatara()
        {
            BitmapImage image = new BitmapImage();
            switch (Dannie.Role)
            { 
                case "Жюри":

                    image = new BitmapImage(new Uri($"Resursi/Foto/JuriFoto/{Dannie.User.Foto.Replace(" ", "")}", UriKind.Relative));
                    return image;
                case "Участники":
                    image = new BitmapImage(new Uri($"Resursi/Foto/UchastnikiFoto/{Dannie.User.Foto.Replace(" ", "")}", UriKind.Relative));
                    return image;
                case "Организаторы":
                    image = new BitmapImage(new Uri($"Resursi/Foto/OrganizatoriFoto/{Dannie.User.Foto.Replace(" ", "")}", UriKind.Relative));
                    return image;
                case "Модераторы":
                    image = new BitmapImage(new Uri($"Resursi/Foto/ModeratoriFoto/{Dannie.User.Foto.Replace(" ", "")}", UriKind.Relative));
                    return image;
            }
            return image;
        }
    }
}
