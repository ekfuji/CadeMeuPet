namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoCEP : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Endereco", "CEP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "CEP", c => c.String(maxLength: 8, unicode: false));
        }
    }
}
