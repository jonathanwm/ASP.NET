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
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            
            Mapper.CreateMap<AnimalViewModel, Animal>();
            Mapper.CreateMap<MedicoViewModel, Medico>();
            Mapper.CreateMap<ProntuarioViewModel, Prontuario>();
                //.ForMember(p => p.Data, opt => {
                    
                //    opt.MapFrom(src => src.Hora);



                //});

                    

        }
    }
}