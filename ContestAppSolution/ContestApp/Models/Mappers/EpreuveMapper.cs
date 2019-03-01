using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Models.Mappers
{
    public static class EpreuveMapper
    {
        public static EpreuveViewModel Map(Epreuve epreuve)
        {
            return new EpreuveViewModel
            {
                Id = epreuve.Id,
                Nom = epreuve.Nom,
                Distance = epreuve.Distance,
                Date = epreuve.Date,
                Inscription = epreuve.Inscription,
                NomVille = epreuve.Ville.Nom

            };
        }

       
    }
}