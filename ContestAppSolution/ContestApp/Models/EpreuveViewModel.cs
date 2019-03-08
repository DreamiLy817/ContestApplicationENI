﻿using BO;
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
        //public List<string> ListeVilleForSelectListId { get; set;}
        //[Required]
        //public List<SelectListItem> ListeVilleForSelectList { get; set; }

        public EpreuveViewModel()
        {
        
            //this.ListeVilleForSelectList = db.Ville.Select(a => new SelectListItem
            //{
            //    Value = a.Id.ToString(),
            //    Text = a.Nom
            //}).ToList();



        }
    }
}