namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeropriyatiaTipi")]
    public partial class MeropriyatiaTipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MeropriyatiaTipi()
        {
            Polzovateli_MeropriyatiaTipi = new HashSet<Polzovateli_MeropriyatiaTipi>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(100)]
        public string TipMeropriyatia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Polzovateli_MeropriyatiaTipi> Polzovateli_MeropriyatiaTipi { get; set; }
    }
}
