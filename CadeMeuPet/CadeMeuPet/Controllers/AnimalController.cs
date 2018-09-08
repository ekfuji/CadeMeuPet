using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        #region Index
        public ActionResult Index()
        {
            return View(AnimalDAO.BuscarAnimais());
        }
        #endregion

        #region Pag Cadastro do Animal
        public ActionResult CadastroAnimal()
        {
            return View();
        }
        #endregion

        #region Cadastro do Animal
        [HttpPost]
        public ActionResult CadastroAnimal(HttpPostedFileBase fupImagem , Animal animal)
        {
            if (ModelState.IsValid)
            {
                Animal animalAntigo = AnimalDAO.BuscarByNameCaracter(animal);
                if(animalAntigo == null)
                {
                    AnimalDAO.CadastrarAnimal(animal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Postagem já cadastrada no sistema!");
                    return View(animal);
                }
            
            }
            return View();
        }
        #endregion
    }
}