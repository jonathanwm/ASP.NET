using AutoMapper;
using Estudo.Clinica.Dominio;
using Estudo.Clinica.Web.ViewModels.Animal;
using Estudo.Clinica.Web.ViewModels.Medico;
using Estudo.Clinica.Web.ViewModels.Prontuario;
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

            Mapper.CreateMap<Prontuario, ProntuarioExibicaoViewModel>()
                .ForMember(p => p.NomeAnimal, opt =>
                            opt.MapFrom(src => src.Animal.Nome)
                            )
                 .ForMember(p => p.NomeMedico, opt =>
                            opt.MapFrom(src => src.Medico.Nome)
                            )
                 .ForMember(p => p.Hora, opt =>
                            opt.MapFrom(src => src.Data.ToShortTimeString())
                            );

            Mapper.CreateMap<Prontuario, ProntuarioViewModel>()
                .ForMember(p => p.Hora, opt =>
                           opt.MapFrom(src => src.Data.ToShortTimeString())

                );



        }
    }
}