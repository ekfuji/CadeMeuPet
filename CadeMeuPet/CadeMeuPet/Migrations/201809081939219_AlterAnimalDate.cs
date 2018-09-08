namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterAnimalDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animal", "DataCadastro", c => c.DateTime(nullable: false));
            AddColumn("dbo.Endereco", "Ip", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Endereco", "Navegador", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Denuncia", "AnimalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(nullable: false, maxLength: 45, unicode: false));
            CreateIndex("dbo.Denuncia", "AnimalId");
            AddForeignKey("dbo.Denuncia", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
            DropColumn("dbo.Animal", "VistoPelaUltimaVez");
            DropColumn("dbo.Endereco", "Numero");
            DropColumn("dbo.Usuario", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "UserName", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AddColumn("dbo.Endereco", "Numero", c => c.String(maxLength: 6, unicode: false));
            AddColumn("dbo.Animal", "VistoPelaUltimaVez", c => c.String(nullable: false, maxLength: 200, unicode: false));
            DropForeignKey("dbo.Denuncia", "AnimalId", "dbo.Animal");
            DropIndex("dbo.Denuncia", new[] { "AnimalId" });
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(maxLength: 250));
            DropColumn("dbo.Denuncia", "AnimalId");
            DropColumn("dbo.Endereco", "Navegador");
            DropColumn("dbo.Endereco", "Ip");
            DropColumn("dbo.Animal", "DataCadastro");
        }
    }
}
