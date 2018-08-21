using Estudo.Clinica.Dominio;
using Estudo.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.AcessoDados.Entity.TypeConfiguration
{
    class MedicoTypeConfiguration : EstudoEntityAbstractConfig<Medico>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MED_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("MED_NOME")
                .HasMaxLength(100);

            Property(p => p.Especialidade)
                .IsRequired()
                .HasColumnName("MED_ESPECIALIDADE")
                .HasMaxLength(100);

            Property(p => p.NumeroCRV)
                .IsRequired()
                .HasColumnName("MED_NUMEROCRV");
                
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("MED_MEDICO");
        }
    }
}
