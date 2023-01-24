namespace BuildWeek_Gruppo3_Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Anagr_Animale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anagr_Animale()
        {
            Visite = new HashSet<Visite>();
        }

        [Key]
        public int IdAnimale { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }


        public int IdTipo { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Colore Mantello")]
        public string Colore { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Nascita")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascita { get; set; }

        [StringLength(6)]
        [Display(Name = "Cod. Microchip")]
        public string NrMicrochip { get; set; }

        public bool Proprietario { get; set; }

        [StringLength(20)]
        [Display(Name = "Proprietario")]
        public string NomeProprietario { get; set; }

        [StringLength(50)]
       
        public string Indirizzo { get; set; }

        [StringLength(20)]
        public string Contatto { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }
        [NotMapped()]
        public HttpPostedFileBase FileFoto { get; set; }

        public virtual Tipologia Tipologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visite> Visite { get; set; }
    }
}
