using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.Clinica.Web.ViewModels.Animal
{
    public class AnimalExibicaoViewModel
    {


        public long Id { get; set; }

        [Display(Name = "Nome do Animal")]
        public string Nome { get; set; }

        [Display(Name = "Idade do Animal")]
        public int Idade { get; set; }

        [Display(Name = "Raça do Animal")]
        public string Raca { get; set; }

        [Display(Name = "Nome do Dono do Animal")]
        public string NomeDoDono { get; set; }


    }
}