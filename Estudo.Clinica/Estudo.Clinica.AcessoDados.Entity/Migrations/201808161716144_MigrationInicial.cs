namespace Estudo.Clinica.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ANI_ANIMAL",
                c => new
                    {
                        ANI_ID = c.Long(nullable: false, identity: true),
                        ANI_NOME = c.String(nullable: false, maxLength: 100),
                        ANI_IDADE = c.Int(nullable: false),
                        ANI_RACA = c.String(nullable: false, maxLength: 100),
                        ANI_NOMEDONO = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ANI_ID);
            
            CreateTable(
                "dbo.MED_MEDICO",
                c => new
                    {
                        MED_ID = c.Long(nullable: false, identity: true),
                        MED_NOME = c.String(nullable: false, maxLength: 100),
                        MED_ESPECIALIDADE = c.String(nullable: false, maxLength: 100),
                        MED_NUMEROCRV = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.MED_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MED_MEDICO");
            DropTable("dbo.ANI_ANIMAL");
        }
    }
}
