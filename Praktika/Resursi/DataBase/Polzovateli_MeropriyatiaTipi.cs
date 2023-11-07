namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Polzovateli_MeropriyatiaTipi
    {
        public int ID { get; set; }

        public int? IDTipMeropriyatia { get; set; }

        public int? IDPolzovatela { get; set; }

        public virtual MeropriyatiaTipi MeropriyatiaTipi { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }
    }
}
