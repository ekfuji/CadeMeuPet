namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDenuncia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Denuncia", "AnimalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Denuncia", "AnimalId");
            AddForeignKey("dbo.Denuncia", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Denuncia", "AnimalId", "dbo.Animal");
            DropIndex("dbo.Denuncia", new[] { "AnimalId" });
            DropColumn("dbo.Denuncia", "AnimalId");
        }
    }
}
