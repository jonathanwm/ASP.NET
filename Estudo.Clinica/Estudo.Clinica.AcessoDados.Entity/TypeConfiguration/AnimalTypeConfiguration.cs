using Estudo.Clinica.Dominio;
using Estudo.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.AcessoDados.Entity.TypeConfiguration
{
    class AnimalTypeConfiguration : EstudoEntityAbstractConfig<Animal>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ANI_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("ANI_NOME")
                .HasMaxLength(100);

            Property(p => p.Idade)
                .IsRequired()
                .HasColumnName("ANI_IDADE");

            Property(p => p.NomeDoDono)
                .IsRequired()
                .HasColumnName("ANI_NOMEDONO")
                .HasMaxLength(100);

            Property(p => p.Raca)
                .IsRequired()
                .HasColumnName("ANI_RACA")
                .HasMaxLength(100);
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
            ToTable("ANI_ANIMAL");
        }
    }
}
