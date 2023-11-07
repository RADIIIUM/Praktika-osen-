namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goroda_Meropriyatia
    {
        public int ID { get; set; }

        public int? IDGoroda { get; set; }

        public int? IDMeropriyatia { get; set; }

        public virtual Goroda Goroda { get; set; }

        public virtual Meropriyatia Meropriyatia { get; set; }
    }
}
