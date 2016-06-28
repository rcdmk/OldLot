namespace OldLot.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDeVeiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Habilidades = c.String(maxLength: 255, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Fabricante_Id = c.Int(),
                        Tipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fabricante", t => t.Fabricante_Id)
                .ForeignKey("dbo.TipoDeVeiculo", t => t.Tipo_Id)
                .Index(t => t.Fabricante_Id)
                .Index(t => t.Tipo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculo", "Tipo_Id", "dbo.TipoDeVeiculo");
            DropForeignKey("dbo.Veiculo", "Fabricante_Id", "dbo.Fabricante");
            DropIndex("dbo.Veiculo", new[] { "Tipo_Id" });
            DropIndex("dbo.Veiculo", new[] { "Fabricante_Id" });
            DropTable("dbo.Veiculo");
            DropTable("dbo.TipoDeVeiculo");
            DropTable("dbo.Fabricante");
        }
    }
}
