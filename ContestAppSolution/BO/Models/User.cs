using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Identifiant {get; set;}
        public string Password { get; set; }
        public Boolean Active { get; set; }
        public Role Role { get; set; }
        //public DisplayConfiguration DisplayConfiguration { get; set; }
    }

}
