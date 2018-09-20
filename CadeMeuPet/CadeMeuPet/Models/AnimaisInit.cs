using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace CadeMeuPet.Models
{
    public class AnimaisInit: CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context contexto)
        {
            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Nome = "Estefani Fujimoto",
                    Email = "estefani.fujimoto@hotmail.com",
                    Password = "1234",
                    Telefone = "41996860726",
                    IsAdmin = "Admin",

                },

                new Usuario()
                {
                    Nome = "Usuario1",
                    Email = "usuario1@test.com",
                    Password = "123",
                    Telefone = "000000000000",
                    IsAdmin = "Usuario",

                },
                new Usuario()
                {
                    Nome = "Usuario2",
                    Email = "usuario2@test.com",
                    Password = "123",
                    Telefone = "000000000000",
                    IsAdmin = "Usuario",

                },
                new Usuario()
                {
                    Nome = "Usuario3",
                    Email = "usuario3@test.com",
                    Password = "123",
                    Telefone = "000000000000",
                    IsAdmin = "Usuario",

                },


            };

            usuarios.ForEach(u => contexto.Usuarios.Add(u));
            List<Tipo> tipos = new List<Tipo>()
            {
                new Tipo() { Especie = "Ave" },
                new Tipo() { Especie = "Cão" },
                new Tipo() { Especie = "Felino" },
                new Tipo() { Especie = "Réptil" },
                new Tipo() { Especie = "Roedor" },

            };

            tipos.ForEach(t => contexto.Tipos.Add(t));

            List<Porte> portes = new List<Porte>()
            {
                new Porte() { Tamanho = "Grande" },
                new Porte() { Tamanho = "Médio" },
                new Porte() { Tamanho = "Pequeno" },

            };

            portes.ForEach(p => contexto.Portes.Add(p));

            List<Endereco> enderecos = new List<Endereco>()
            {
                new Endereco()
                {
                    Logradouro = "R. David Hume, 165 - Pilarzinho, Curitiba - PR, 82110-290",
                    Latitude = "-25.390250",
                    Longitude = "-49.285340",                   
                },
                new Endereco()
                {
                    Logradouro = "Av. Maringá, 1882 - Emiliano Perneta, Pinhais - PR, 83325-360",
                    Latitude = "-25.420830",
                    Longitude = "-49.191170",
                },
                new Endereco()
                {
                    Logradouro = "R. Mal. Hermes, 999 - Centro Cívico, Curitiba - PR, 80530-230",
                    Latitude = "-25.412050",
                    Longitude = "-49.265790",
                },
                new Endereco()
                {
                    Logradouro = "Km 6 Bairro, Rod. Régis Bittencourt, 5000, Mauá - PR, 83413-663",
                    Latitude = "-25.417750",
                    Longitude = "-49.223630",
                },
                new Endereco()
                {
                    Logradouro = "Rua João Gava, 999 - Abranches, Curitiba - PR, 82130-010, Brasil",
                    Latitude = "-25.385630",
                    Longitude = "-49.275070",
                },
                new Endereco()
                {
                    Logradouro = "Rua Oswaldo Maciel, 97 - Taboão, Curitiba - PR, 82130-494",
                    Latitude = "-25.379180",
                    Longitude = "-49.282260",
                },
                new Endereco()
                {
                    Logradouro = "Rua Francisco Schaffer - Vista Alegre, Curitiba - PR, 80820-200",
                    Latitude = "-25.407130",
                    Longitude = "-49.284720",
                },
                new Endereco()
                {
                    Logradouro = "R. Prof. Joaquim De Matos Barreto, 98 - São Lourenço, Curitiba - PR, 82200-210",
                    Latitude = "-25.389350",
                    Longitude = "-49.270380",
                },
                new Endereco()
                {
                    Logradouro = "R. Cel. João Maria Sobrinho, 88 - Vista Alegre, Curitiba - PR, 82100-230",
                    Latitude = "-25.401900",
                    Longitude = "-49.294200",
                },
                new Endereco()
                {
                    Logradouro = "Av. Manoel Ribas, 5455 - Santa Felicidade, Curitiba - PR, 82400-000",
                    Latitude = "-25.387730",
                    Longitude = "-49.357230",
                },
                new Endereco()
                {
                    Logradouro = "R. Via Veneto, 1888 - Santa Felicidade, Curitiba - PR, 82400-020",
                    Latitude = "-25.401310",
                    Longitude = "-49.330080",
                },

            };

            enderecos.ForEach(e => contexto.Enderecos.Add(e));


            List<Animal> animais = new List<Animal>()
            {
                new Animal() {
                    NomeAnimal = "Flash",
                    DataCadastro= DateTime.Now,
                    Caracteristicas = "Alguém viu está gatinho? Está perdido desde 02/09/2018, na região do Cascatinha e parque Barigui. Se tiver alguma informação favor mandar mensagem Inbox. Se chama Flash e tinha uma plaquinha com nome e dados para contato... Se alguém viu ou tem alguma informação peço por favor que entre em contato, toda família está muito triste, principalmente meus filhos!",
                    Porte = portes.FirstOrDefault(x => x.Tamanho == "Pequeno"),
                    Tipo = tipos.FirstOrDefault(x => x.Especie == "Felino"),
                    Endereco = enderecos.FirstOrDefault(x => x.EnderecoId == 1),
                    Usuario = usuarios.FirstOrDefault(x => x.UsuarioId == 2),
                    Situacao = 0,
                    Imagem = "/Images/1.jpg",                   
                    },

                new Animal() {
                    NomeAnimal = "Banoffe",
                    DataCadastro= DateTime.Now,
                    Caracteristicas = "É uma vira-lata de 6 meses e atende pelo nome de Banoffee. Ela tá sem coleira... Caso alguém a viu ou tenha alguma informação, me avisem por favor.",
                    Porte = portes.FirstOrDefault(x => x.Tamanho == "Pequeno"),
                    Tipo = tipos.FirstOrDefault(x => x.Especie == "Felino"),
                    Endereco = enderecos.FirstOrDefault(x => x.EnderecoId == 1),
                    Usuario = usuarios.FirstOrDefault(x => x.UsuarioId == 2),
                    Situacao = 0,
                    Imagem = "/Images/2.jpg",
                },


            };
            animais.ForEach(a => contexto.Animais.Add(a));
            contexto.SaveChanges();

        }
    }
}