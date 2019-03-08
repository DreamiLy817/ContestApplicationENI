using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class Resultat
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Epreuve))]
        public int EpreuveId { get; set; }
        public DateTime Temps { get; set; }
        public int Positionfinale { get; set; }
        public Epreuve Epreuve { get; set; }

    }
}
