using Estudo.Clinica.AcessoDados.Entity;
using Estudo.Clinica.Dominio;
using Estudo.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.Repositorio.Entity
{
    public class AnimalRepositorio : RepositorioGenericoEntity<Animal, long>
    {
        public AnimalRepositorio(Contexto contexto)
            : base(contexto)
        {

        }
    }
}
