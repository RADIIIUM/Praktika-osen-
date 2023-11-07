namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Meropriyatia")]
    public partial class Meropriyatia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meropriyatia()
        {
            Aktivnosti_Meropriyatia = new HashSet<Aktivnosti_Meropriyatia>();
            Goroda_Meropriyatia = new HashSet<Goroda_Meropriyatia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nomer { get; set; }

        [StringLength(100)]
        public string Sobitie { get; set; }

        public DateTime? Data { get; set; }

        public int? Dni { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aktivnosti_Meropriyatia> Aktivnosti_Meropriyatia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goroda_Meropriyatia> Goroda_Meropriyatia { get; set; }
    }
}
