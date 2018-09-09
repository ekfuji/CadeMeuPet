﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuPet.Models;
using CadeMeuPet.DAL;

namespace CadeMeuPet.Controllers
{
    [Authorize]
    public class EnderecoController : Controller
    {
        #region VIEW LISTA DE ENDEREÇOS

        public ActionResult Index()
        {
            return View(EnderecoDAO.ListarEnderecos());
        }

        #endregion

        #region  VIEW PAGINA CADASTRAR ENDEREÇO
        public ActionResult CadastrarEndereco(int id)
        {
            ViewBag.Animal = AnimalDAO.BuscarById(id);
            TempData["AnimalId"] = id;
            
            return View();
        }
        #endregion

        #region VIEW PAGINA ALTERAR ENDERECO
        public ActionResult AlterarEndereco()
        {
            return View();
        }
        #endregion

        #region CADASTRAR ENDEREÇO

        [HttpPost]
        public ActionResult CadastrarEndereco(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var id = TempData["AnimalId"];
                endereco.AnimalId = Convert.ToInt32(id);
                if (EnderecoDAO.CadastrarEndereco(endereco))
                {
                    return RedirectToAction("Index", "Endereco");
                }
                else
                {
                    ModelState.AddModelError("", "Endereço já está cadastrado!");
                    return View(endereco);
                }
            }
            else
            {
                return View(endereco);
            }
        }


        #endregion

        #region ALTERAR ENDEREÇO

        [HttpPost]
        public ActionResult AlterarEndereco(Endereco endereco)
        {
            Endereco original = EnderecoDAO.BuscarEnderecoById(endereco.EnderecoId);
            original.Logradouro = endereco.Logradouro;
            original.CEP = endereco.CEP;
            original.Latitude = endereco.Latitude;
            original.Longitude = endereco.Longitude;
            original.Ip = endereco.Ip;
            original.Navegador = endereco.Navegador;

            if (ModelState.IsValid)
            {
                EnderecoDAO.AlterarEndereco(original);
                return RedirectToAction("Index", "Endereco");
            }

            return View(endereco);
        }

        #endregion


    }
}