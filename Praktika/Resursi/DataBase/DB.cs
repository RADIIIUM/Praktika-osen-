using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Praktika.Resursi.DataBase
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Aktivnosti> Aktivnosti { get; set; }
        public virtual DbSet<Aktivnosti_Meropriyatia> Aktivnosti_Meropriyatia { get; set; }
        public virtual DbSet<Aktivnosti_Polzovateli> Aktivnosti_Polzovateli { get; set; }
        public virtual DbSet<Goroda> Goroda { get; set; }
        public virtual DbSet<Goroda_Meropriyatia> Goroda_Meropriyatia { get; set; }
        public virtual DbSet<Meropriyatia> Meropriyatia { get; set; }
        public virtual DbSet<MeropriyatiaTipi> MeropriyatiaTipi { get; set; }
        public virtual DbSet<Napravleniya> Napravleniya { get; set; }
        public virtual DbSet<Napravleniya_Polzovateli> Napravleniya_Polzovateli { get; set; }
        public virtual DbSet<Pol> Pol { get; set; }
        public virtual DbSet<Pol_Polzovateli> Pol_Polzovateli { get; set; }
        public virtual DbSet<Polzovateli> Polzovateli { get; set; }
        public virtual DbSet<Polzovateli_MeropriyatiaTipi> Polzovateli_MeropriyatiaTipi { get; set; }
        public virtual DbSet<Roli> Roli { get; set; }
        public virtual DbSet<Roli_Polzovateli> Roli_Polzovateli { get; set; }
        public virtual DbSet<Strana> Strana { get; set; }
        public virtual DbSet<Strana_Polzovateli> Strana_Polzovateli { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aktivnosti>()
                .HasMany(e => e.Aktivnosti_Meropriyatia)
                .WithOptional(e => e.Aktivnosti)
                .HasForeignKey(e => e.NomerAktivnosti)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Aktivnosti>()
                .HasMany(e => e.Aktivnosti_Polzovateli)
                .WithOptional(e => e.Aktivnosti)
                .HasForeignKey(e => e.NomerAktivnosti)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Goroda>()
                .HasMany(e => e.Goroda_Meropriyatia)
                .WithOptional(e => e.Goroda)
                .HasForeignKey(e => e.IDGoroda)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Meropriyatia>()
                .HasMany(e => e.Aktivnosti_Meropriyatia)
                .WithOptional(e => e.Meropriyatia)
                .HasForeignKey(e => e.NomerAktivnosti)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Meropriyatia>()
                .HasMany(e => e.Goroda_Meropriyatia)
                .WithOptional(e => e.Meropriyatia)
                .HasForeignKey(e => e.IDMeropriyatia)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MeropriyatiaTipi>()
                .HasMany(e => e.Polzovateli_MeropriyatiaTipi)
                .WithOptional(e => e.MeropriyatiaTipi)
                .HasForeignKey(e => e.IDTipMeropriyatia)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Napravleniya>()
                .HasMany(e => e.Napravleniya_Polzovateli)
                .WithOptional(e => e.Napravleniya)
                .HasForeignKey(e => e.IDNapravleniya)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pol>()
                .HasMany(e => e.Pol_Polzovateli)
                .WithOptional(e => e.Pol)
                .HasForeignKey(e => e.IDPola)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Aktivnosti_Polzovateli)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IDPolzovateli)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Napravleniya_Polzovateli)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IDPolzovatela)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Pol_Polzovateli)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IDPolzovatelya)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Polzovateli_MeropriyatiaTipi)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IDPolzovatela)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Roli_Polzovateli)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IDPolzovatelya)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Polzovateli>()
                .HasMany(e => e.Strana_Polzovateli)
                .WithOptional(e => e.Polzovateli)
                .HasForeignKey(e => e.IdPolzovatelya)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Roli>()
                .HasMany(e => e.Roli_Polzovateli)
                .WithOptional(e => e.Roli)
                .HasForeignKey(e => e.IDRoli)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Strana>()
                .HasMany(e => e.Strana_Polzovateli)
                .WithOptional(e => e.Strana)
                .HasForeignKey(e => e.IDStrani)
                .WillCascadeOnDelete();
        }
    }
}
