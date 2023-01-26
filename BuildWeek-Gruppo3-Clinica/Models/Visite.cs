namespace BuildWeek_Gruppo3_Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visite")]
    public partial class Visite
    {
        [Key]
        public int IdVisita { get; set; }

        public int IdAnimale { get; set; }

        [Column(TypeName = "date")]
        [Display(Name="Data ricovero")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required]
        public string Referto { get; set; }

        [Required]
        public string Diagnosi { get; set; }

        public virtual Anagr_Animale Anagr_Animale { get; set; }
    }
}
