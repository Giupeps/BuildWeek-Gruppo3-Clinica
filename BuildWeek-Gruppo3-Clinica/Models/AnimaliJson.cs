using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BuildWeek_Gruppo3_Clinica.Models
{
    public class AnimaliJson
    {
        public int IdAnimale { get; set; }

        public string Nome { get; set; }

        public int IdTipo { get; set; }

        public string Colore { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DataNascita { get; set; }
        
        public DateTime DataRicovero { get; set; }

        public string NrMicrochip { get; set; }

        public bool Proprietario { get; set; }

        public string NomeProprietario { get; set; }


        public string Indirizzo { get; set; }

        public string Contatto { get; set; }

        public string Foto { get; set; }

        public string Razza { get; set; }
        public int Giorni { get; set; }

        public int GetDate()
        {
            Giorni = DateTime.Now.Day - DataRicovero.Day; 
            return Giorni; 
        }
    }
}