using Estudo.Clinica.AcessoDados.Entity;
using Estudo.Clinica.Dominio;
using Estudo.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Estudo.Clinica.Repositorio.Entity
{
    public class ProntuarioRepositorio : RepositorioGenericoEntity<Prontuario, long>
    {
        public ProntuarioRepositorio(Contexto contexto)
            :base (contexto)
        {
            
        }

        public override List<Prontuario> Selecionar()
        {
            return _contexto.Set<Prontuario>().Include(a => a.Animal).Include(m => m.Medico).ToList();

        }
    }
}
