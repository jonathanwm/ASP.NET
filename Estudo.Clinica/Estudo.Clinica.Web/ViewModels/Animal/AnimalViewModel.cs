using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Animal
{
    public class AnimalViewModel
    {

        
        public long Id { get; set; }

        [Display(Name = "Nome do Animal")]
        [Required(ErrorMessage = "O nome do Animal é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do Animal poderá ter no máximo 100 caracteres")]
        public string Nome { get; set; }
          
        [Display(Name = "Idade do Animal")]
        [Required(ErrorMessage = "A Idade do Animal é obrigatório")]
        public int Idade { get; set; }

        [Display(Name = "Raça do Animal")]
        [Required(ErrorMessage = "O nome do Animal é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do Animal poderá ter no máximo 100 caracteres")]
        public string Raca { get; set; }

        [Display(Name = "Nome do Dono do Animal")]
        [Required(ErrorMessage = "O nome do Dono é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do Dono poderá ter no máximo 100 caracteres")]
        public string NomeDoDono { get; set; }
    }
}