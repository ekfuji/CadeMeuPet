using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuPet.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

    }
}