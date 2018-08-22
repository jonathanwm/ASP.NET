namespace Estudo.Clinica.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAlteracaoCamposDataeHora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PRO_PRONTUARIO", "PRO_HORA", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PRO_PRONTUARIO", "PRO_HORA");
        }
    }
}
