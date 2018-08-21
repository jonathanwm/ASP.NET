using Estudo.Clinica.AcessoDados.Entity.TypeConfiguration;
using Estudo.Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.AcessoDados.Entity
{
    public class Contexto : DbContext
    {

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnimalTypeConfiguration());
            modelBuilder.Configurations.Add(new MedicoTypeConfiguration());
        }
    }
}
