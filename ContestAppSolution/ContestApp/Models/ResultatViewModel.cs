using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ContestApp.Models
{
    public class ResultatViewModel
    {
        public int Id { get; set; }
        public DateTime Temps { get; set; }
        [DisplayName("Position Finale")]
        public int Positionfinale { get; set; }
        [DisplayName("Utilisateur")]
        public ProfilViewModel Profil { get; set; }
        [DisplayName("Epreuve")]
        public EpreuveViewModel Epreuve { get; set; }
        public int? EpreuveId { get; internal set; }
        public int? ProfilId { get; internal set; }
    }
}