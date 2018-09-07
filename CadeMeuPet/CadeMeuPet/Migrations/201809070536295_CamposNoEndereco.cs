namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposNoEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Ip", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Endereco", "Navegador", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Endereco", "Navegador");
            DropColumn("dbo.Endereco", "Ip");
        }
    }
}
