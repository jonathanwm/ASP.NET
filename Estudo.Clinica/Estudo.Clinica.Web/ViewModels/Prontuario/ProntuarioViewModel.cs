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

        [Required(ErrorMessage = "A data é Obrigatório")]
        [Display(Name = "Data do atendimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A Hora do atendimento é Obrigatório")]
        [Display(Name = "Hora do atendimento")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "A Observação é obrigatória")]
        [Display(Name = "Obvervações do atendimento")]
        [MaxLength(100, ErrorMessage = "A Observação poderá ter no máximo 100 caracteres")]
        public string Observacoes { get; set; }

        [Display(Name = "Nome do médico")]
        public long IdMedico { get; set; }

        [Display(Name = "Nome do animal")]
        public long IdAnimal { get; set; }
    }
}