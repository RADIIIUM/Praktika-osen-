namespace Praktika.Resursi.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Strana")]
    public partial class Strana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Strana()
        {
            Strana_Polzovateli = new HashSet<Strana_Polzovateli>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cod { get; set; }

        [StringLength(10)]
        public string Cod2 { get; set; }

        [StringLength(100)]
        public string NazvanieStrani { get; set; }

        [StringLength(100)]
        public string AngliskoeNazvanie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Strana_Polzovateli> Strana_Polzovateli { get; set; }
    }
}
