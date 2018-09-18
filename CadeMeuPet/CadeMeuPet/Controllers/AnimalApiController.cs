using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CadeMeuPet.Controllers
{
    [RoutePrefix("api/Animal")]
    public class AnimalApiController : ApiController
    {
        [Route("Animais")]
        public List<Animal> GetAnimais()
        {
            return AnimalDAO.BuscarAnimais();
        }
        //GET: api/Animal/AnimalById/2
        [Route("AnimalById/{id}")]
        public dynamic GetAnimalById(int id)
        {
           Animal animal =  AnimalDAO.BuscarById(id);

            if( animal != null)
            {
                dynamic animalDinamico = new
                {
                     Id = animal.AnimalId,
                     Nome = animal.NomeAnimal,
                     Caracteristicas = animal.Caracteristicas,
                     Porte = animal.Porte.Tamanho,
                     Especie = animal.Tipo.Especie,
                     Endereco = animal.Endereco.Logradouro,
                     Usuario = animal.Usuario.Nome,
                     DataCadastro = animal.DataCadastro.ToShortDateString()

                };
                return new {Animal =  animalDinamico};
            }

            return NotFound();
        }

        [Route("CadastrarAnimal")]
        public IHttpActionResult PostCadastrarAnimal(Animal animal)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (AnimalDAO.CadastrarAnimal(animal))
            {
                return Created("", animal);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
