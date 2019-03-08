using BO;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContestApp.Models
{
    public class PointOfInterestViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public Categorie Categorie { get; set; }

        public int CategorieId { get; set; }
        public Epreuve Epreuve { get; set; }
        public int EpreuveId { get; set; }
        public List<SelectListItem> listeEpreuve { get; set; }
        public List<SelectListItem> listeCategorie { get; set; }

        public PointOfInterestViewModel()
        {
            ContextContest db = new ContextContest();

            listeEpreuve = db.Epreuves.Select(e => new SelectListItem
            {
                Text = e.Nom,
                Value = e.Id.ToString()
            }).ToList();

            listeCategorie = db.Categories.Select(c => new SelectListItem
            {
                Text = c.Nom,
                Value = c.Id.ToString()
            }).ToList();


        }
    }
}