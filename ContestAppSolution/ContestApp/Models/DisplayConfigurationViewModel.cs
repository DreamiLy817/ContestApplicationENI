using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ContestApp.Models
{
    public enum UniteTemps
    {
        [Display(Name="Seconde")]
        Seconde = 0,
        [Display(Name = "Minute")]
        Minute = 1,
        [Display(Name = "Heure")]
        Heure = 2
    }

    public enum UniteMesure
    {
        [Display(Name = "Kilomètres")]
        Kilometres = 0,
        [Display(Name = "Miles")]
        Miles = 1
        
    }


    public class DisplayConfigurationViewModel
    {
        public int Id { get; set; }
        [DisplayName("Unité de temps")]
        public UniteTemps UniteTemps { get; set; }
        [DisplayName("Unité de mesure")]
        public UniteMesure UniteMesure { get; set; }
        public float Temps { get; set; }


        public DisplayConfigurationViewModel()
        {
            this.UniteTemps = ContestApp.Models.UniteTemps.Heure;
            this.UniteMesure = ContestApp.Models.UniteMesure.Kilometres;
            this.Temps = 25.35f;
        }
        public void CalculVitesse(float distance, float temps, UniteMesure uniteMesure, UniteTemps uniteTemps)
        {
            int uMesure = Int32.Parse(uniteMesure.ToString(), NumberStyles.Integer);
            int uTemps = Int32.Parse(uniteTemps.ToString(), NumberStyles.Integer);
           float resultDistance = convertMesure(distance, uMesure);
           float resultTemps = convertTemps(temps, uTemps);

        }

        /*
         * Convertit l'unité de mesure en miles ou en kilomètres
         * Retourne la distance convertie
         *
         */
        private float convertMesure(float distance, int uniteMesure)
        {
            
            if (distance != 0 && uniteMesure == 1)
            {
                distance *= 1.609344f;
            }
            else if (distance != 0 && uniteMesure == 0)
            {
                distance /=  1.609344f;
            }
            return distance;
        }

        /*
         * Convertit l'unité de temps en secondes, minutes ou heures
         * Retourne le temps converti
         *
         */
        private float convertTemps(float temps, int uniteTemps)
        {
            
            if (temps != 0 && uniteTemps == 1)
            {
                temps *= 1.609344f;
            }
            else if (temps != 0 && uniteTemps == 0)
            {
                temps /= 1.609344f;
            }
            
            return temps;
        }
    }
}