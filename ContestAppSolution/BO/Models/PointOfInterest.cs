using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public Categorie Categorie { get; set; }
        public Epreuve Epreuve { get; set; }
    }
}
