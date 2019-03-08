using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ContestApp.Models
{
    public class ResultatViewModel
    {
        public int Id { get; set; }
        public TimeSpan Temps { get; set; }
        [DisplayName("Position Finale")]
        public int Positionfinale { get; set; }
       
        [DisplayName("Epreuve")]
        public CourseViewModel Epreuve { get; set; }

       
     
    }
}