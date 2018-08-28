namespace Estudo.Clinica.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTirandoOCampoHora : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PRO_PRONTUARIO", "PRO_HORA");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PRO_PRONTUARIO", "PRO_HORA", c => c.Time(nullable: false, precision: 7));
        }
    }
}
