using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Repository
{
    public class RepositoryResultat : Repository<Resultat>
    {
        public RepositoryResultat(ContextContest context) : base(context)
        {
        }

        public List<Resultat> GetResultatsDUneEpreuve(Epreuve epreuve)
        {
            List<Resultat> resultats = this.GetAll().Where(r => r.EpreuveId == epreuve.Id).ToList();

            return resultats;
        }

        public List<Resultat> GetResultatsDUnUser(Profil user)
        {
            List<Resultat> resultats = this.GetAll().Where(r => r.ProfilId == user.Id).ToList();

            return resultats;
        }
    }
}
