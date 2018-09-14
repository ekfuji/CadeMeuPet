using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CadeMeuPet.DAL;
using CadeMeuPet.Models;

namespace CadeMeuPet.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        #region VIEW PAGINA LOGIN
        public ActionResult Login()
        {
            return View();
        }


        #endregion

        #region VIEW PAGINA CADASTRAR USUARIO

        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        #endregion

        #region CADASTRAR USUARIO
        [HttpPost]
        public ActionResult CadastrarUsuario([Bind(Include = "UsuarioId,Nome,Telefone,Email,Password,ConfirmacaoSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioDAO.SalvarUsuario(usuario))
                {
                    return RedirectToAction("CadastrarEndereco", "Endereco");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }
            return View(usuario);
        }


        #endregion

        #region LOGIN
        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")]Usuario usuario)
        {         
            usuario = UsuarioDAO.BuscarUsuarioPorLoginSenha(usuario);
          
            if (usuario != null)
            {
                //Autenticar
                FormsAuthentication.SetAuthCookie(usuario.Email, true);
                Session["Nome"] = usuario.Nome;
                Session["IsAdmin"] = usuario.IsAdmin;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
            return View(usuario);
        }


        #endregion

        #region LOGOUT
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        #endregion


    }
}