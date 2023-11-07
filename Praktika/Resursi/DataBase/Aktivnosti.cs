namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aktivnosti")]
    public partial class Aktivnosti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aktivnosti()
        {
            Aktivnosti_Meropriyatia = new HashSet<Aktivnosti_Meropriyatia>();
            Aktivnosti_Polzovateli = new HashSet<Aktivnosti_Polzovateli>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nomer { get; set; }

        public DateTime? DataNachala { get; set; }

        public double? Dni { get; set; }

        [StringLength(100)]
        public string Aktivnost { get; set; }

        public int? Den { get; set; }

        public DateTime? VremyaNachala { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aktivnosti_Meropriyatia> Aktivnosti_Meropriyatia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aktivnosti_Polzovateli> Aktivnosti_Polzovateli { get; set; }
    }
}
