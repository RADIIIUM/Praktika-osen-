namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aktivnosti_Polzovateli
    {
        public int ID { get; set; }

        public int? IDPolzovateli { get; set; }

        public int? NomerAktivnosti { get; set; }

        public virtual Aktivnosti Aktivnosti { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }
    }
}
