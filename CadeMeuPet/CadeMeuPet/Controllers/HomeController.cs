using CadeMeuPet.DAL;
using CadeMeuPet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CadeMeuPet.Controllers
{
    public class HomeController : Controller
    {
        
        #region Index
        public ActionResult Index()
        {
            return View(AnimalDAO.BuscarAnimais());
        }
        #endregion

        #region DetalhesAnimal

        public ActionResult DetalhesAnimal(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (AnimalDAO.BuscarById(id) == null)
            {
                return HttpNotFound();
            }
            return View(AnimalDAO.BuscarById(id));
        }
        #endregion

        #region Pag Cadastro do Animal
        [Authorize]
        public ActionResult CadastrarAnimal(int EnderecoId)
        {
            
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");
            TempData["EnderecoId"] = EnderecoId;

            return View();
        }
        #endregion
        
        #region Cadastro do Animal
        [HttpPost]
        public ActionResult CadastrarAnimal(HttpPostedFileBase fupImagem, Animal animal)
        {
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(userName);
                animal.Situacao = 0;
                animal.UsuarioId = usuario.UsuarioId;

                var id = TempData["EnderecoId"];
                animal.EnderecoId = Convert.ToInt32(id);

                if (ModelState.IsValid)
                {

                    if (fupImagem != null)
                    {
                        string nomeImagem = Path.GetFileName(fupImagem.FileName);
                        string caminho = Path.Combine(Server.MapPath("~/Images/"), fupImagem.FileName);

                        fupImagem.SaveAs(caminho);

                        animal.Imagem = nomeImagem;
                    }
                    else
                    {
                        animal.Imagem = "semimagem.jpg";
                    }

                    Animal animalAntigo = AnimalDAO.BuscarByNameCaracter(animal);
                    if (animalAntigo == null)
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
            }
           var erro = ModelState.ToString();
         
            return View(animal);
        }
        #endregion

        #region Pag Alterar Animal
        [Authorize]
        public ActionResult AlterarAnimal(int id)
        {
            return View(AnimalDAO.BuscarById(id));
        }
        #endregion

        #region Alterar Animal
        public ActionResult AlterarAnimal(Animal animalAlterado ,HttpPostedFileBase fupImagem)
        {
            
            Animal animalAntigo = AnimalDAO.BuscarById(animalAlterado.AnimalId);
            animalAntigo.NomeAnimal = animalAlterado.NomeAnimal;
            animalAntigo.PorteId = animalAlterado.PorteId;
            animalAntigo.TipoId = animalAlterado.TipoId;
            animalAntigo.Caracteristicas = animalAlterado.Caracteristicas;

            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), fupImagem.FileName);

                    fupImagem.SaveAs(caminho);

                    animalAntigo.Imagem = nomeImagem;
                }
                else
                {
                    animalAntigo.Imagem = "semimagem.jpg";
                }

                if (AnimalDAO.AlterarAnimal(animalAntigo))
                {
                    return RedirectToAction("DetalhesAnimal", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Animal já cadastrado nos sistema!");
                    return View(animalAntigo);
                }

            }
            else
            {
                return View(animalAntigo);
            }
        }
        #endregion
    }
}