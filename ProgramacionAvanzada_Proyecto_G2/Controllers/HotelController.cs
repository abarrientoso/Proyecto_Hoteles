using ProgramacionAvanzada_Proyecto_G2.Entities;
using ProgramacionAvanzada_Proyecto_G2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ProgramacionAvanzada_Proyecto_G2.Controllers
{
    public class HotelController : Controller
    {
        public ActionResult Hotel1()
        {
            return View("Hotel1");
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Hotel2()
        {
            return View("Hotel2");
        }

        public ActionResult Hotel3()
        {
            return View("Hotel3");
        }

        public ActionResult Hotel4()
        {
            return View("Hotel4");
        }

        public ActionResult Hotel5()
        {
            return View("Hotel5");
        }

        public ActionResult Hotel6()
        {
            return View("Hotel6");
        }

    }
}