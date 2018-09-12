namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIP_Navegador : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Endereco", "Ip");
            DropColumn("dbo.Endereco", "Navegador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Navegador", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Endereco", "Ip", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
