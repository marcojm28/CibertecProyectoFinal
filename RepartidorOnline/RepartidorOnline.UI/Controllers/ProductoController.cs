using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index(int IdTienda)
        {
            ViewBag.IdTienda = IdTienda;
            return View();
        }
    }
}