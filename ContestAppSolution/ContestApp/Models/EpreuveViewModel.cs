using BO;
using BO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestApp.Models
{
    public abstract class EpreuveViewModel
    {
        private ContextContest db = new ContextContest();
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public Boolean Inscription { get; set; }
        public VilleViewModel Ville { get; set; }
        public DateTime Date { get; set; }
        public List<PointOfInterest> listePointOfInterests { get; set; } = new List<PointOfInterest>();

        public void chargerPoi()
        {
            this.listePointOfInterests = db.PointOfInterest.Where(p => p.Epreuve.Id == this.Id).ToList();
        }
    }
}