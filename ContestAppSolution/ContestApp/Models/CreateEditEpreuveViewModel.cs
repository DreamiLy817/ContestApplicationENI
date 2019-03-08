using BO.Models;
using BO.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace ContestApp.Models
{
    public class CreateEditEpreuveViewModel : CourseViewModel
    {
        public int? VilleId { get; set; }
        [Required]
        public List<SelectListItem> ListeVilleForSelectList { get; set; }
        public CreateEditEpreuveViewModel()
        {
            this.InitList();
        }

        public void InitList()
        {
            IRepository<Ville> villeRepository =
               UnityConfig.Container.Resolve<IRepository<Ville>>();

            this.ListeVilleForSelectList = villeRepository.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nom
            }).ToList();
        }
    }
}