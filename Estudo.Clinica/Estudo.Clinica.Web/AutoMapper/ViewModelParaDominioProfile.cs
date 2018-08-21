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
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            
            Mapper.CreateMap<AnimalViewModel, Animal>();
            Mapper.CreateMap<MedicoViewModel, Medico>();

        }
    }
}