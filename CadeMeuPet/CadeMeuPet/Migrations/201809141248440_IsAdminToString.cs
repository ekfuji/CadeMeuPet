namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAdminToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "IsAdmin", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "IsAdmin", c => c.Byte(nullable: false));
        }
    }
}
