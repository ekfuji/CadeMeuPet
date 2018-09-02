using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CadeMeuPet.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbCadeMeuPet") {}

        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Porte> Portes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(250));
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 2));

        }


    }
}