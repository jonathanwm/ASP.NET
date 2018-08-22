using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Prontuario
{
    public class ProntuarioExibicaoViewModel
    {

        public long Id { get; set; }
        [Display(Name = "Data do atendimento")]
        public DateTime Data { get; set; }

        [Display(Name = "Hora do atendimento")]
        public TimeSpan Hora { get; set; }

        [Display(Name = "Obvervações do atendimento")]
        public string Observacoes { get; set; }

        [Display(Name = "Nome do médico")]
        public string NomeMedico { get; set; }

        [Display(Name = "Nome do animal")]
        public string NomeAnimal { get; set; }
    }
}