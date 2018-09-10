using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    [Authorize]
    public class PorteController : Controller
    {

        #region Index 
        // GET: Porte
        public ActionResult Index()
        {
            return View(PorteDAO.BuscarPortes());
        }
        #endregion

        #region Pag Cadastrar Porte
        public ActionResult CadastrarPorte()
        {
            return View();
        }
        #endregion

        #region Cadastrar Porte
        [HttpPost]
        public ActionResult CadastrarPorte(Porte porte)
        {
            if (ModelState.IsValid)
            {
                if (PorteDAO.CadastrarPorte(porte))
                {
                    return RedirectToAction("Index", "Porte");
                }
                else
                {
                    ModelState.AddModelError("", "O porte já está cadastrado!");
                    return View(porte);
                }
            }
            return View();
        }
        #endregion

        #region Pag Alterar Porte
        public ActionResult AlterarPorte(int id)
        {
            return View(PorteDAO.BuscarById(id));
        }
        #endregion

        #region Alterar Porte
        [HttpPost]
        public ActionResult AlterarPorte(Porte porte)
        {
            Porte porteOriginal = PorteDAO.BuscarById(porte.PorteId);
            porteOriginal.Tamanho = porte.Tamanho;
            if (ModelState.IsValid)
            {
                PorteDAO.AlterarPorte(porteOriginal);
                return RedirectToAction("Index", "Porte");
            }
            return View(porte);
        }
        #endregion

        #region Remover Porte
        public ActionResult RemoverPorte(int id)
        {
            if(id != 0)
            {
                PorteDAO.RemoverPorte(id);
            }
            
            return RedirectToAction("Index", "Porte");
        }
        #endregion
    }
}