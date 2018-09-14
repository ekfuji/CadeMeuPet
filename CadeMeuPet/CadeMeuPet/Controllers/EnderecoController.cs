using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuPet.Models;
using CadeMeuPet.DAL;

namespace CadeMeuPet.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class EnderecoController : Controller
    {
        #region VIEW LISTA DE ENDEREÇOS
       
        public ActionResult Index()
        {
            return View(EnderecoDAO.ListarEnderecos());
        }

        #endregion

        #region  VIEW PAGINA CADASTRAR ENDEREÇO
        public ActionResult CadastrarEndereco()
        {   
            return View();
        }
        #endregion

        #region VIEW PAGINA ALTERAR ENDERECO
        public ActionResult AlterarEndereco(int id)
        {
            return View(EnderecoDAO.BuscarEnderecoById(id));
        }
        #endregion

        #region CADASTRAR ENDEREÇO

        [HttpPost]
        public ActionResult CadastrarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
               
                if (EnderecoDAO.CadastrarEndereco(endereco))
                {
                    
                    return RedirectToAction("CadastrarAnimal", "Home",new { EnderecoId = endereco.EnderecoId });
                }
                else
                {
                    ModelState.AddModelError("", "Endereço já está cadastrado!");
                    return View(endereco);
                }
            }
            else
            {
                return View(endereco);
            }
        }


        #endregion

        #region ALTERAR ENDEREÇO

        [HttpPost]
        public ActionResult AlterarEndereco(Endereco endereco)
        {
            Endereco original = EnderecoDAO.BuscarEnderecoById(endereco.EnderecoId);
            original.Logradouro = endereco.Logradouro;
            original.Latitude = endereco.Latitude;
            original.Longitude = endereco.Longitude;


            if (ModelState.IsValid)
            {
                EnderecoDAO.AlterarEndereco(original);
                int animalId = AnimalDAO.BuscarAnimalByEnderecoId(endereco.EnderecoId);
                return RedirectToAction("DetalhesAnimal", "Home", new { id = animalId });
            }

            return View(endereco);
        }

        #endregion


    }
}