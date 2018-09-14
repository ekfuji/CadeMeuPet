using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TipoController : Controller
    {
        // GET: Tipo
        #region Index do Tipo
        public ActionResult Index()
        {
            return View(TipoDAO.BuscarTipos());
        }
        #endregion

        #region Pag Cadastrar Tipos
        public ActionResult CadastrarTipo()
        {
            return View();
        }
        #endregion

        #region Cadastrar Tipos
        [HttpPost]
        public ActionResult CadastrarTipo(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                if (TipoDAO.CadastrarTipo(tipo))
                {
                    return RedirectToAction("Index", "Tipo");
                }
                else
                {
                    ModelState.AddModelError("", "Tipo já está cadastrado!");
                    return View(tipo);
                }
            }
            else
            {
                return View(tipo);
            }

        }
        #endregion

        #region Pag Alterar Tipo
        public ActionResult AlterarTipo(int id)
        {
            return View(TipoDAO.BuscarById(id));
        }
        #endregion

        #region Alterar Tipo
        [HttpPost]
        public ActionResult AlterarTipo(Tipo tipo)
        {
           Tipo tipoOriginal = TipoDAO.BuscarById(tipo.TipoId);
                tipoOriginal.Especie = tipo.Especie;
            

            if (ModelState.IsValid)
            {
                    TipoDAO.AlterarTipo(tipoOriginal);
                    return RedirectToAction("Index", "Tipo");
                
            }
            return View(tipo);
        }
        #endregion

        #region Remover Tipo
        public ActionResult RemoverTipo(int id)
        {
            if(id != 0)
            {
                TipoDAO.RemoverTipo(id);
            }
            
            return RedirectToAction("Index","Tipo");
        }
        #endregion
    }
}