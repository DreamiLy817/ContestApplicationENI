using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Models.Mappers
{
    public static class CategorieMapper
    {
        public static CategorieViewModel Map(Categorie categorie)
        {
            return new CategorieViewModel
            {
                Id = categorie.Id,
                Nom = categorie.Nom
            };
        }
    }
}