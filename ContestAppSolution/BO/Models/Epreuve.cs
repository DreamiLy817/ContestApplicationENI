using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
     public abstract class Epreuve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [ForeignKey(nameof(Ville))]
        public virtual int? VilleId { get; set; }
        public decimal Distance { get; set; }
        public DateTime Date { get; set; }
        public Boolean Inscription { get; set; }
        public virtual Ville Ville { get; set; }
        public virtual List<PointOfInterest> listePointOfInterests { get; set; }

    }
}
