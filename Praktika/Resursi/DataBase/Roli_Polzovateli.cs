namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roli_Polzovateli
    {
        public int ID { get; set; }

        public int? IDPolzovatelya { get; set; }

        public int? IDRoli { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }

        public virtual Roli Roli { get; set; }
    }
}
