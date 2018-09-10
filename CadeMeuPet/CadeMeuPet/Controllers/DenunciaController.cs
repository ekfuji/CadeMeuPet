using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    public class DenunciaController : Controller
    {

        #region Index
        // GET: Denuncia
        [Authorize]
        public ActionResult Index()
        {
            return View(DenunciaDAO.BuscarDenuncias());
        }
        #endregion

        #region Pag Cadastrar Denúncia
        public ActionResult CadastrarDenuncia(int id)
        {
            Animal animal = AnimalDAO.BuscarById(id);
            TempData["AnimalId"] = animal.AnimalId;
            return View();
        }
        #endregion

        #region Cadastrar Denúncia
        [HttpPost]
        public ActionResult CadastrarDenuncia(Denuncia denuncia)
        {
            denuncia.AnimalId = Convert.ToInt32(TempData["AnimalId"]);
            denuncia.DataDenuncia = DateTime.Now;
            if (ModelState.IsValid)
            {
                if(denuncia.AnimalId != 0)
                {
                    DenunciaDAO.CadastrarDenuncia(denuncia);
                    return RedirectToAction("DetalhesAnimal", "Home", new { id = denuncia.AnimalId });
                }
                ModelState.AddModelError("", "Não foi possível enviar a denuncia, volte para página inicial e tente novamente!");
            }
            return View(denuncia);
        }
        #endregion

        #region Remover Denúncia
        public ActionResult RemoverDenuncia(int id)
        {
            if(id != 0)
            {
                DenunciaDAO.RemoverDenuncia(id);
            }
            return RedirectToAction("Index","Denuncia");
        }
        #endregion
    }
}