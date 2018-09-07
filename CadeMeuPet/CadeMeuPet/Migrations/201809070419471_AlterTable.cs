namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Usuario", new[] { "EnderecoId" });
            AddColumn("dbo.Animal", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animal", "EnderecoId");
            AddForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco", "EnderecoId", cascadeDelete: true);
            DropColumn("dbo.Usuario", "EnderecoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EnderecoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Animal", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.Animal", new[] { "EnderecoId" });
            DropColumn("dbo.Animal", "EnderecoId");
            CreateIndex("dbo.Usuario", "EnderecoId");
            AddForeignKey("dbo.Usuario", "EnderecoId", "dbo.Endereco", "EnderecoId", cascadeDelete: true);
        }
    }
}
