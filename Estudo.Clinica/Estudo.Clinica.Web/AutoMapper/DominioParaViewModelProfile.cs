using AutoMapper;
using Estudo.Clinica.Dominio;
using Estudo.Clinica.Web.ViewModels.Animal;
using Estudo.Clinica.Web.ViewModels.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {

            Mapper.CreateMap<Animal, AnimalExibicaoViewModel>()
                .ForMember(p => p.Nome, opt => {

                    opt.MapFrom(src =>
                        string.Format("{0} ({1})", src.Nome, src.Raca.ToString())

                        );
                });

            Mapper.CreateMap<Animal, AnimalViewModel>();

            Mapper.CreateMap<Medico, MedicoExibicaoViewModel>();
            Mapper.CreateMap<Medico, MedicoViewModel>();



        }
    }
}