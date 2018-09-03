namespace CadeMeuPet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        NomeAnimal = c.String(nullable: false, maxLength: 45, unicode: false),
                        Imagem = c.String(maxLength: 250, unicode: false),
                        Características = c.String(nullable: false, maxLength: 200, unicode: false),
                        VistoPelaUltimaVez = c.String(nullable: false, maxLength: 200, unicode: false),
                        Situacao = c.Byte(nullable: false),
                        PorteId = c.Int(nullable: false),
                        TipoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Porte", t => t.PorteId, cascadeDelete: true)
                .ForeignKey("dbo.Tipo", t => t.TipoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.PorteId)
                .Index(t => t.TipoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Porte",
                c => new
                    {
                        PorteId = c.Int(nullable: false, identity: true),
                        Tamanho = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.PorteId);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Especie = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.TipoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 45, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 20, unicode: false),
                        Password = c.String(nullable: false, maxLength: 60, unicode: false),
                        Telefone = c.String(maxLength: 12, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        IsAdmin = c.Byte(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        UsuarioGuid = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(maxLength: 150, unicode: false),
                        Numero = c.String(maxLength: 6, unicode: false),
                        CEP = c.String(maxLength: 8, unicode: false),
                        Latitude = c.String(maxLength: 250, unicode: false),
                        Longitude = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        idComentario = c.Int(nullable: false, identity: true),
                        Mensagem = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataComentario = c.DateTime(nullable: false),
                        NomeComentario = c.String(maxLength: 45, unicode: false),
                        EmailComentario = c.String(maxLength: 100, unicode: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idComentario)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .Index(t => t.AnimalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.Animal", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Animal", "TipoId", "dbo.Tipo");
            DropForeignKey("dbo.Animal", "PorteId", "dbo.Porte");
            DropIndex("dbo.Comentario", new[] { "AnimalId" });
            DropIndex("dbo.Usuario", new[] { "EnderecoId" });
            DropIndex("dbo.Animal", new[] { "UsuarioId" });
            DropIndex("dbo.Animal", new[] { "TipoId" });
            DropIndex("dbo.Animal", new[] { "PorteId" });
            DropTable("dbo.Comentario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Usuario");
            DropTable("dbo.Tipo");
            DropTable("dbo.Porte");
            DropTable("dbo.Animal");
        }
    }
}
