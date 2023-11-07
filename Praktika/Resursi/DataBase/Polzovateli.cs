namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Polzovateli")]
    public partial class Polzovateli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Polzovateli()
        {
            Aktivnosti_Polzovateli = new HashSet<Aktivnosti_Polzovateli>();
            Napravleniya_Polzovateli = new HashSet<Napravleniya_Polzovateli>();
            Pol_Polzovateli = new HashSet<Pol_Polzovateli>();
            Polzovateli_MeropriyatiaTipi = new HashSet<Polzovateli_MeropriyatiaTipi>();
            Roli_Polzovateli = new HashSet<Roli_Polzovateli>();
            Strana_Polzovateli = new HashSet<Strana_Polzovateli>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(100)]
        public string FIO { get; set; }

        [StringLength(100)]
        public string Pochta { get; set; }

        public DateTime? DataRojdenia { get; set; }

        [StringLength(50)]
        public string Parol { get; set; }

        [StringLength(100)]
        public string Foto { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aktivnosti_Polzovateli> Aktivnosti_Polzovateli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Napravleniya_Polzovateli> Napravleniya_Polzovateli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pol_Polzovateli> Pol_Polzovateli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Polzovateli_MeropriyatiaTipi> Polzovateli_MeropriyatiaTipi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Roli_Polzovateli> Roli_Polzovateli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Strana_Polzovateli> Strana_Polzovateli { get; set; }
    }
}
