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
        public ActionResult Index(int? id)
        {
            
            ViewBag.Tipo = TipoDAO.BuscarTipos();
            if(id == null)
            {
                return View(AnimalDAO.BuscarAnimais());
            }
            var tipo = AnimalDAO.BuscarAnimalByTipo(id);
            if(tipo.Count.Equals(0))
            {
                return View(tipo);
            }
            return View(tipo);
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

        #region Página WebService for Developers

        public ActionResult WebServiceDesenvolvedores()
        {
            return View();
        }

        #endregion

        #region Pag Cadastro do Animal
        [Authorize(Roles = "Usuario")]
        public ActionResult CadastrarAnimal(int EnderecoId)
        {
            
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");
            TempData["EnderecoId"] = EnderecoId;

            return View();
        }
        #endregion

        #region Cadastro do Animal
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public ActionResult CadastrarAnimal(HttpPostedFileBase fupImagem, Animal animal)
        {
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
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
        [Authorize(Roles = "Usuario")]
        public ActionResult AlterarAnimal(int id)
        {
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");
            return View(AnimalDAO.BuscarById(id));
        }
        #endregion

        #region Alterar Animal
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public ActionResult AlterarAnimal(Animal animalAlterado ,HttpPostedFileBase fupImagem)
        {
            ViewBag.PorteId = new SelectList(PorteDAO.BuscarPortes(), "PorteId", "Tamanho");
            ViewBag.TipoId = new SelectList(TipoDAO.BuscarTipos(), "TipoId", "Especie");

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
                    return RedirectToAction("DetalhesAnimal", "Home", new { id = animalAlterado.AnimalId});
                }
                else
                {
                    ModelState.AddModelError("", "Animal já cadastrado nos sistema!");
                    return View(animalAntigo);
                }

            }
            else if(animalAntigo.PorteId == 0 || animalAntigo.TipoId == 0){
                ModelState.AddModelError("", "Porte ou tipo são campos obrigatórios!");
                return View(animalAntigo);
            }
            
                return View(animalAntigo);
            
        }
        #endregion

        #region Pag de Administração dos Animais pelo Usuário
        [Authorize(Roles = "Usuario")]
        public ActionResult ListaAnimaisUsuario()
        {
            var email = User.Identity.Name;
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
            return View(UsuarioDAO.BuscarAnimaByIdUsuario(usuario.UsuarioId));
        }
        #endregion

        #region Animal Encontrado (Bloquear Animal)
        [Authorize(Roles ="Usuario, Admin")]
        public ActionResult AnimalEncontrado(int id)
        {
            Animal animal = AnimalDAO.BuscarById(id);
            if(animal != null)
            {
                animal.Situacao = 1;
                if (AnimalDAO.AlterarAnimal(animal))
                {
                    return RedirectToAction("Index","Home");
                }
            }
            return RedirectToAction("Index","Home");
        }
        #endregion



//        Resolvido Bug com o Cadastrar Usuário(problema com o IsAdmin Required) +
//Botão bloquear e desbloquear feito na denuncia e adicionado no Ver Postagens Postagens

        #region Desbloquear Postagem (Animal)
        [Authorize(Roles ="Admin")]
        public ActionResult DesbloquearAnimal(int id)
        {
            Animal animal = AnimalDAO.BuscarById(id);
            if (animal != null)
            {
                animal.Situacao = 0;
                if (AnimalDAO.AlterarAnimal(animal))
                {
                    return RedirectToAction("AnimalBloqueado", "Denuncia");
                }
            }
            return RedirectToAction("AnimalBloqueado", "Denuncia");
        }
        #endregion

    }
}