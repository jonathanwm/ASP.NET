using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.Dominio
{
    public class Prontuario
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Observacoes { get; set; }
        public long IdMedico { get; set; }
        public virtual Medico Medico { get; set; }
        public long IdAnimal { get; set; }
        public virtual Animal Animal { get; set; }
        
    }
}
