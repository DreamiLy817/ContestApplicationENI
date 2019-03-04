using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestApp.Models
{
    public class EpreuveViewModel
    {
        private ContextContest db = new ContextContest();
        public int? Id { get; set; }
        public virtual string Nom { get; set; }
        public virtual decimal Distance { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Boolean Inscription { get; set; }
        public virtual string NomVille { get; set; }
        public virtual List<string> ListeVilleForSelectListId { get; set; }
        public List<SelectListItem> ListeVilleForSelectList { get; set; }

        public  EpreuveViewModel()
        {
            this.ListeVilleForSelectList = db.Ville.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = v.Nom
            }).ToList();
        }
    }
}