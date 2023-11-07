namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Napravleniya_Polzovateli
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDPolzovatela { get; set; }

        public int? IDNapravleniya { get; set; }

        public virtual Napravleniya Napravleniya { get; set; }

        public virtual Polzovateli Polzovateli { get; set; }
    }
}
