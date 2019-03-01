using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Models
{
    public class PointOfInterestViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Distance { get; set; }
        public string NomCategorie { get; set; }
        public string NomEpreuve { get; set; }
    }
}