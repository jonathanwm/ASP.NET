using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.Dominio
{
    public class Medico
    {

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public long NumeroCRV { get; set; }

    }
}
