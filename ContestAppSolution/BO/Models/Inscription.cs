using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class Inscription
    {
        public virtual int Id { get; set; }
        public virtual string UtilisateurName { get; set; }
        public virtual Epreuve Epreuve { get; set; }
        public virtual DateTime dateInscription { get; set; }

    }
}
