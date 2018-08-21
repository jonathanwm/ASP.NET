using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Medico
{
    public class MedicoExibicaoViewModel
    {

        public long Id { get; set; }

        [Display(Name ="Nome do Médico")]
        public string Nome { get; set; }

        [Display(Name = "Especialidade do Médico")]
        public string Especialidade { get; set; }

        [Display(Name = "Número do CRV")]
        public long NumeroCRV { get; set; }

    }
}