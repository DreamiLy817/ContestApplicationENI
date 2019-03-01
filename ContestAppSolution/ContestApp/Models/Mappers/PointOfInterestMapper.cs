using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Models.Mappers
{
    public  static class PointOfInterestMapper
    {
        public static PointOfInterestViewModel Map(PointOfInterest poi)
        {
            return new PointOfInterestViewModel
            {
                Id = poi.Id,
                Nom = poi.Nom,
                Distance = poi.Distance,
                NomCategorie = poi.Categorie.Nom,
                NomEpreuve = poi.Epreuve.Nom
            };
        }
    }
}