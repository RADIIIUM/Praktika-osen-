namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Strana_Polzovateli
    {
        public int ID { get; set; }

        public int? IdPolzovatelya { get; set; }

        public int? IDStrani { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }

        public virtual Strana Strana { get; set; }
    }
}
