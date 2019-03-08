using BO.Models;
using BO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
namespace ContestApp.Models
{
    public class InscriptionViewModel
    {
        public int Id { get; set; }
        public DateTime dateInscription { get; set; }

        public  string epreuveId { get; set; }
        public List<SelectListItem> ListeEpreuveForSelectList { get; set; }

        public InscriptionViewModel()
        {
            this.InitList();
        }

        public void InitList()
        {

            IRepository<Epreuve> epreuveRepository =
               UnityConfig.Container.Resolve<IRepository<Epreuve>>();

            this.ListeEpreuveForSelectList = epreuveRepository.GetAll().Where(c => c.Inscription).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nom
            }).ToList();
        }
    }
}