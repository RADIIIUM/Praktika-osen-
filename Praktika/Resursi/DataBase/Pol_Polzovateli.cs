namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pol_Polzovateli
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDPolzovatelya { get; set; }

        public int? IDPola { get; set; }

        public virtual Pol Pol { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }
    }
}
