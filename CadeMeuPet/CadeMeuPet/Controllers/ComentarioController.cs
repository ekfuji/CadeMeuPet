﻿using CadeMeuPet.DAL;
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

        #region Index
        [Authorize(Roles = "Usuario")]
        public ActionResult Index()
        {
            var email = User.Identity.Name;
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
            return View(ComentarioDAO.BuscarComentarioByUser(usuario.UsuarioId));
        }
        #endregion

        #region Pag Cadastrar do Comentário
        public ActionResult CadastrarComentario(int id)
        {
            Animal animal = AnimalDAO.BuscarById(id);
            TempData["AnimalId"] = animal.AnimalId;
            return View();
        }
        #endregion

        #region Cadastrar Comentário
        [HttpPost]
        public ActionResult CadastrarComentario(Comentario comentario)
        {
            comentario.DataComentario = DateTime.Now;
            comentario.AnimalId = Convert.ToInt32(TempData["AnimalId"]);
            if (ModelState.IsValid)
            {
                if(comentario.AnimalId != 0)
                {
                    ComentarioDAO.CadastrarComentario(comentario);
                    return RedirectToAction("DetalhesAnimal", "Home", new { id = comentario.AnimalId });
                }
                ModelState.AddModelError("", "Não foi possível enviar o comentário, volte para página inicial e tente novamente!");
            }
            return View(comentario);
        }
        #endregion

        #region Remover Comentário
        [Authorize(Roles = "Usuario")]
        public ActionResult RemoverComentario(int id)
        {
            if (id != 0)
            {
                ComentarioDAO.RemoverComentario(id);
            }
            return RedirectToAction("Index", "Comentario");
        }
        #endregion
    }
}