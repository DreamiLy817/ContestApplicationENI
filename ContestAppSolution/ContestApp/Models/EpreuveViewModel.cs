using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Models
{
    public class EpreuveViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public Boolean Inscription { get; set; }
        public VilleViewModel Ville { get; set; }
    }
}