using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace {%= name %}.Controllers
{
    public class PagesController : Controller
    {

        /// <summary>
        /// Homepage
        /// </summary>
        public ActionResult Overview()
        {
            return View();
        }
    }
}
