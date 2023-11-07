using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    public partial class MeropriyatiaItem
    {
        public MeropriyatiaItem() 
        { 

        }

        public string Nazvanie { get; set; }

        public string Data { get; set; }

        public MeropriyatiaItem(string nazvanie, string data )
        {
            this.Nazvanie = nazvanie;
            this.Data = data;
        }
    }
}
