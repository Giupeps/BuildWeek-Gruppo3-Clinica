using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BuildWeek_Gruppo3_Clinica.Models
{
    public class Email
    {
        [Key]
        public int IdEmail { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailMittente { get; set; }
        [Required]
        public string Messaggio { get; set; }
    }
}