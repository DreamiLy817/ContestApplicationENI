using BO.Models;
using BO.Repository;
using ContestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContestApp.Extensions;
using Unity;

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

                config.CreateMap<Course, CourseViewModel>()
                    .AfterMap((modele, vm) =>
                    {
                        Repository<Ville> villeRepository = UnityConfig.Container.Resolve<Repository<Ville>>();
                        Ville ville = villeRepository.GetAll(v => v.Id == modele.Ville?.Id).FirstOrDefault();

                        if (ville != null)
                        {
                            vm.Ville = ville.Map<VilleViewModel>();
                        }
                    });

                config.CreateMap<Course, CreateEditEpreuveViewModel>()
                    .ForMember(vm => vm.VilleId, o => o.Ignore())
                    .AfterMap((modele, vm) =>
                    {
                        Repository<Ville> villeRepository = UnityConfig.Container.Resolve<Repository<Ville>>();

                        vm.VilleId = villeRepository.GetAll(v => v.Id == modele.Ville?.Id).FirstOrDefault()?.Id;

                        
                    });

                config.CreateMap<CreateEditEpreuveViewModel, Course>()
                    .AfterMap((vm, modele) =>
                {
                    Repository<Ville> villeRepository = UnityConfig.Container.Resolve<Repository<Ville>>();

                    Ville villeActuelle = villeRepository.Get(vm.VilleId);
               

                    if (villeActuelle != null)
                    {
                        villeActuelle = modele.Ville;
                    }

                });

                config.CreateMap<DisplayConfiguration, DisplayConfigurationViewModel>();
                config.CreateMap<DisplayConfigurationViewModel, DisplayConfiguration>();

                config.CreateMap<Resultat, ResultatViewModel>()
                    .ForMember(vm => vm.EpreuveId, o => o.Ignore())
                    .AfterMap((modele, vm) =>
                    {
                        Repository<Epreuve> epreuveRepository = UnityConfig.Container.Resolve<Repository<Epreuve>>();

                        vm.EpreuveId = epreuveRepository.GetAll(e => e.Id == modele.Epreuve?.Id).FirstOrDefault()?.Id;

                       
                    });

                config.CreateMap<ResultatViewModel, Resultat>()
                    .AfterMap((vm, modele) => 
                    {
                        Repository<Epreuve> epreuveRepository = UnityConfig.Container.Resolve<Repository<Epreuve>>();

                        Epreuve epreuveActuelle = epreuveRepository.Get(vm.EpreuveId);

                        if (epreuveActuelle != null)
                        {
                            epreuveActuelle = modele.Epreuve;
                        }

                    });

                config.CreateMap<Epreuve, EpreuveViewModel>();
                config.CreateMap<EpreuveViewModel, Epreuve>();

            });
        }
    }
}