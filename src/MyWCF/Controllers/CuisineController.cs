using MyMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        //[Authorize]
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);

            //throw new Exception("Something horrible just happened.");

            return Content(message);
        }
    }
}