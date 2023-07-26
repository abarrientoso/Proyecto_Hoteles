using ProgramacionAvanzada_Proyecto_G2.Entities;
using ProgramacionAvanzada_Proyecto_G2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ProgramacionAvanzada_Proyecto_G2.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                var resp = model.IniciarSesion(entidad);

                if (resp != null)
                {
                    Session["IdSesion"] = resp.idUsuario.ToString();
                    Session["CorreoSesion"] = resp.correoElectronico;
                    Session["NombreSesion"] = resp.nombre;
                    Session["RolSesion"] = resp.nombreRol;
                    Session["IdRolSesion"] = resp.idRol;

                    return RedirectToAction("Principal", "Home");
                }
                else
                {
                    ViewBag.MsjPantalla = "No se ha podido validar su información";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.MsjPantalla = "Consulta con el administrador del sistema";
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult Registrarse(UsuarioEnt entidad)
        {
            entidad.idRol = 2;
            entidad.estado = true;

            var resp = model.Registrarse(entidad);

            if (resp > 0)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido registrar su información";
                return View("Registro");
            }
        }



        [HttpGet]
        public ActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContrasenna(UsuarioEnt entidad)
        {
            var resp = model.RecuperarContrasenna(entidad);

            if (resp)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido recuperar su información";
                return View("Recuperar");
            }
        }
    }
}