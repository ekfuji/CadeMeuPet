namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(nullable: false, maxLength: 45, unicode: false));
            DropColumn("dbo.Animal", "VistoPelaUltimaVez");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "VistoPelaUltimaVez", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Porte", "Tamanho", c => c.String(maxLength: 250));
        }
    }
}
