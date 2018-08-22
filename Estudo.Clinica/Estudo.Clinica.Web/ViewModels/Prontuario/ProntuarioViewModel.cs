using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Prontuario
{
    public class ProntuarioViewModel
    {

        public long Id { get; set; }

        [Display(Name = "Data do atendimento")]
        [Required(ErrorMessage = "A data é Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Display(Name = "Hora do atendimento")]
        [Required(ErrorMessage = "A Hora do atendimento é Obrigatório")]
        public TimeSpan Hora { get; set; }

        [Display(Name = "Obvervações do atendimento")]
        [Required(ErrorMessage = "A Observação é obrigatória")]
        [MaxLength(100, ErrorMessage = "A Observação poderá ter no máximo 100 caracteres")]
        public string Observacoes { get; set; }

        [Display(Name = "Nome do médico")]
        public long IdMedico { get; set; }

        [Display(Name = "Nome do animal")]
        public long IdAnimal { get; set; }
    }
}