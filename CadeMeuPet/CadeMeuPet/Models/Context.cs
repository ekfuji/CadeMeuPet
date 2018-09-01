using System;
using System.Collections.Generic;
using System.Data.Entity;
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


    }
}