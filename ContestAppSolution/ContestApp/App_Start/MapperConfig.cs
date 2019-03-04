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
                config.CreateMap<Ville, VilleViewModel>();
                config.CreateMap<VilleViewModel, Ville>();

                config.CreateMap<Course, CourseViewModel>();
                config.CreateMap<CourseViewModel, Course>();

            });

        }
    }
}