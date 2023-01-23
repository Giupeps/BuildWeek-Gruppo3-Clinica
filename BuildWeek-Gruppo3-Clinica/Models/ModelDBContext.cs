using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BuildWeek_Gruppo3_Clinica.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Anagr_Animale> Anagr_Animale { get; set; }
        public virtual DbSet<Tipologia> Tipologia { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }
        public virtual DbSet<Visite> Visite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anagr_Animale>()
                .HasMany(e => e.Visite)
                .WithRequired(e => e.Anagr_Animale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipologia>()
                .HasMany(e => e.Anagr_Animale)
                .WithRequired(e => e.Tipologia)
                .WillCascadeOnDelete(false);
        }
    }
}
