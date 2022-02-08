using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGC2.Controllers
{
    public class ChiefController : Controller
    {
        // GET: Chief
        //ChiefManager cm = new ChiefManager(new EfChiefDal());
        public ActionResult Index()
        {
            return View();
        }
    }
}