namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aktivnosti_Meropriyatia
    {
        public int ID { get; set; }

        public int? NomerMeropriyatia { get; set; }

        public int? NomerAktivnosti { get; set; }

        public virtual Aktivnosti Aktivnosti { get; set; }

        public virtual Meropriyatia Meropriyatia { get; set; }
    }
}
