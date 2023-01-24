namespace BuildWeek_Gruppo3_Clinica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("Tipologia")]
    public partial class Tipologia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipologia()
        {
            Anagr_Animale = new HashSet<Anagr_Animale>();
        }

        [Key]
        public int idTipo { get; set; }

        [Required]
        [StringLength(20)]
        public string Animale { get; set; }

        [Required]
        public string Razza { get; set; }

        [NotMapped()]
        public static List<SelectListItem> SelectListTipo
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                ModelDBContext db = new ModelDBContext();
                List<Tipologia> listTipo = db.Tipologia.ToList();


                foreach (var item in listTipo)
                {
                    SelectListItem f = new SelectListItem
                    {
                        Text= item.Animale + " " + item.Razza,
                        Value = item.idTipo.ToString(),
                    };
                    list.Add(f);
                }
                return list;
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anagr_Animale> Anagr_Animale { get; set; }
    }
}
