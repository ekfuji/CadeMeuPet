using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        #region Index
        public ActionResult Index()
        {
            return View(ComentarioDAO.BuscarComentarios());
        }
        #endregion

        #region Pag Cadastrar do Comentário
        public ActionResult CadastrarComentario()
        {
            return View();
        }
        #endregion

        #region Cadastrar Comentário
        [HttpPost]
        public ActionResult CadastrarComentario(Comentario comentario)
        {
            comentario.DataComentario = DateTime.Now;
            if (ModelState.IsValid)
            {
                ComentarioDAO.CadastrarComentario(comentario);
                return RedirectToAction("Index", "Animal");
            }
            return View(comentario);
        }
        #endregion

        #region Remover Comentário
        public ActionResult RemoverComentario(int id)
        {
            if (id != 0)
            {
                ComentarioDAO.RemoverComentario(id);
            }
            return RedirectToAction("Index", "Denuncia");
        }
        #endregion
    }
}