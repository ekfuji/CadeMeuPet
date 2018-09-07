namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animal", "VistoPelaUltimaVez");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "VistoPelaUltimaVez", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
    }
}
