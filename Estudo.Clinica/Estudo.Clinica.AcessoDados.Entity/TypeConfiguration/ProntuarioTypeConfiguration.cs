using Estudo.Clinica.Dominio;
using Estudo.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudo.Clinica.AcessoDados.Entity.TypeConfiguration
{
    class ProntuarioTypeConfiguration : EstudoEntityAbstractConfig<Prontuario>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("PRO_ID");

            Property(p => p.DataHora)
                .IsRequired()
                .HasColumnName("PRO_DATA");

            Property(p => p.Observacoes)
                .IsRequired()
                .HasColumnName("PRO_OBSERVACOES")
                .HasMaxLength(100);


            Property(p => p.IdAnimal)
                .HasColumnName("ANI_ID")
                .IsRequired();

            Property(p => p.IdMedico)
                .HasColumnName("MED_ID")
                .IsRequired();


        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {

            

            this.HasRequired(p => p.Animal)
                .WithMany()
                .HasForeignKey(p => p.IdAnimal);

            this.HasRequired(p => p.Medico)
                .WithMany()
                .HasForeignKey(p => p.IdMedico);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("PRO_PRONTUARIO");
        }
    }
}
