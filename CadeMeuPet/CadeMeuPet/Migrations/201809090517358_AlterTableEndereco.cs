namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableEndereco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "AnimalId", "dbo.Animal");
            DropIndex("dbo.Endereco", new[] { "AnimalId" });
            AddColumn("dbo.Animal", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animal", "EnderecoId");
            AddForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco", "EnderecoId", cascadeDelete: true);
            DropColumn("dbo.Endereco", "AnimalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "AnimalId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Animal", new[] { "EnderecoId" });
            DropColumn("dbo.Animal", "EnderecoId");
            CreateIndex("dbo.Endereco", "AnimalId");
            AddForeignKey("dbo.Endereco", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
        }
    }
}
