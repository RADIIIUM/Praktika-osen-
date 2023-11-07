using Praktika.Resursi.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    public static partial class Dannie
    {
        public static bool Autorization { get; set; }
        public static Polzovateli User { get; set; }

        public static string Role { get; set; }
    }
}
