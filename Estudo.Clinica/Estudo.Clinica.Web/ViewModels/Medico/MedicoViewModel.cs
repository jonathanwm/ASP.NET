using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Medico
{
    public class MedicoViewModel
    {

        public long Id { get; set; }

        [Display(Name = "Nome do Médico")]
        [Required(ErrorMessage ="O Nome do Médico é Obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do Médico poderá ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Especialidade do Médico")]
        [Required(ErrorMessage = "A Especialidade do Médico é Obrigatório")]
        [MaxLength(100, ErrorMessage = "A Especialidade poderá ter no máximo 100 caracteres")]
        public string Especialidade { get; set; }

        [Display(Name = "Número do CRV")]
        [Required(ErrorMessage = "O Número do CRV é Obrigatório")]
        public long NumeroCRV { get; set; }

    }
}