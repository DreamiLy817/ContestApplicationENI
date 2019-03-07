using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
     public class Epreuve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public Boolean Inscription { get; set; }
        public Ville Ville { get; set; }

    }
}
