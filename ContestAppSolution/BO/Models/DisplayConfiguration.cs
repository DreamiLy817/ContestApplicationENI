using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Models
{
    public enum UniteTemps
    {
        Seconde = 0,
        Minute = 1,
        Heure = 2
    }

    public enum UniteMesure
    {
        Miles = 0,
        Metres = 1
    }
    public class DisplayConfiguration
    {
        public int Id { get; set; }
        public UniteTemps UniteTemps { get; set; }
        public UniteMesure UniteMesure { get; set; }


    }
}
