namespace Estudo.Clinica.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationComAnimalMedicoProntuario : DbMigration
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
            
            CreateTable(
                "dbo.PRO_PRONTUARIO",
                c => new
                    {
                        PRO_ID = c.Long(nullable: false, identity: true),
                        PRO_DATA = c.DateTime(nullable: false),
                        PRO_OBSERVACOES = c.String(nullable: false, maxLength: 100),
                        MED_ID = c.Long(nullable: false),
                        ANI_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PRO_ID)
                .ForeignKey("dbo.ANI_ANIMAL", t => t.ANI_ID, cascadeDelete: false)
                .ForeignKey("dbo.MED_MEDICO", t => t.MED_ID, cascadeDelete: false)
                .Index(t => t.MED_ID)
                .Index(t => t.ANI_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRO_PRONTUARIO", "MED_ID", "dbo.MED_MEDICO");
            DropForeignKey("dbo.PRO_PRONTUARIO", "ANI_ID", "dbo.ANI_ANIMAL");
            DropIndex("dbo.PRO_PRONTUARIO", new[] { "ANI_ID" });
            DropIndex("dbo.PRO_PRONTUARIO", new[] { "MED_ID" });
            DropTable("dbo.PRO_PRONTUARIO");
            DropTable("dbo.MED_MEDICO");
            DropTable("dbo.ANI_ANIMAL");
        }
    }
}
