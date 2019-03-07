using BO.Models;
using ContestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.App_Start
{
    public class MapperConfig
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
               
                config.CreateMap<Epreuve, EpreuveViewModel>();
                config.CreateMap<EpreuveViewModel, Epreuve>();

                config.CreateMap<PointOfInterest, PointOfInterestViewModel>();
                config.CreateMap<PointOfInterestViewModel, PointOfInterest>();

            });
        }
    }
}