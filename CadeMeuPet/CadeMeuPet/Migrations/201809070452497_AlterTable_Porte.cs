namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable_Porte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(nullable: false, maxLength: 45, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(maxLength: 250));
        }
    }
}
