namespace OldLot.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustesnasrelações : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veiculo", "Fabricante_Id", "dbo.Fabricante");
            DropForeignKey("dbo.Veiculo", "Tipo_Id", "dbo.TipoDeVeiculo");
            DropIndex("dbo.Veiculo", new[] { "Fabricante_Id" });
            DropIndex("dbo.Veiculo", new[] { "Tipo_Id" });
            RenameColumn(table: "dbo.Veiculo", name: "Fabricante_Id", newName: "IdFabricante");
            RenameColumn(table: "dbo.Veiculo", name: "Tipo_Id", newName: "IdTipoDeVeiculo");
            AlterColumn("dbo.Veiculo", "IdFabricante", c => c.Int(nullable: false));
            AlterColumn("dbo.Veiculo", "IdTipoDeVeiculo", c => c.Int(nullable: false));
            CreateIndex("dbo.Veiculo", "IdFabricante");
            CreateIndex("dbo.Veiculo", "IdTipoDeVeiculo");
            AddForeignKey("dbo.Veiculo", "IdFabricante", "dbo.Fabricante", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Veiculo", "IdTipoDeVeiculo", "dbo.TipoDeVeiculo", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculo", "IdTipoDeVeiculo", "dbo.TipoDeVeiculo");
            DropForeignKey("dbo.Veiculo", "IdFabricante", "dbo.Fabricante");
            DropIndex("dbo.Veiculo", new[] { "IdTipoDeVeiculo" });
            DropIndex("dbo.Veiculo", new[] { "IdFabricante" });
            AlterColumn("dbo.Veiculo", "IdTipoDeVeiculo", c => c.Int());
            AlterColumn("dbo.Veiculo", "IdFabricante", c => c.Int());
            RenameColumn(table: "dbo.Veiculo", name: "IdTipoDeVeiculo", newName: "Tipo_Id");
            RenameColumn(table: "dbo.Veiculo", name: "IdFabricante", newName: "Fabricante_Id");
            CreateIndex("dbo.Veiculo", "Tipo_Id");
            CreateIndex("dbo.Veiculo", "Fabricante_Id");
            AddForeignKey("dbo.Veiculo", "Tipo_Id", "dbo.TipoDeVeiculo", "Id");
            AddForeignKey("dbo.Veiculo", "Fabricante_Id", "dbo.Fabricante", "Id");
        }
    }
}
