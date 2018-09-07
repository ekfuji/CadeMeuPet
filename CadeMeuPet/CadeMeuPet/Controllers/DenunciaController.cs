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
        public ActionResult Index()
        {
            return View(DenunciaDAO.BuscarDenuncias());
        }
        #endregion

        #region Pag Cadastrar Denúncia
        public ActionResult CadastrarDenuncia()
        {
            return View();
        }
        #endregion

        #region Cadastrar Denúncia
        [HttpPost]
        public ActionResult CadastrarDenuncia(Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                DenunciaDAO.CadastrarDenuncia(denuncia);
                return RedirectToAction("Index", "Animal");
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