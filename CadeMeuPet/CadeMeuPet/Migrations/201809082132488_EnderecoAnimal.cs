namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecoAnimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Animal", new[] { "EnderecoId" });
            AddColumn("dbo.Endereco", "AnimalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Endereco", "AnimalId");
            AddForeignKey("dbo.Endereco", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
            DropColumn("dbo.Animal", "EnderecoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "EnderecoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Endereco", "AnimalId", "dbo.Animal");
            DropIndex("dbo.Endereco", new[] { "AnimalId" });
            DropColumn("dbo.Endereco", "AnimalId");
            CreateIndex("dbo.Animal", "EnderecoId");
            AddForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco", "EnderecoId", cascadeDelete: true);
        }
    }
}
