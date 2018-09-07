namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoNumeroEndereco : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Endereco", "Numero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Numero", c => c.String(maxLength: 6, unicode: false));
        }
    }
}
