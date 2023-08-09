using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionAvanzada_Proyecto_G2.Entities;
using ProgramacionAvanzada_Proyecto_G2.Models;

namespace ProgramacionAvanzada_Proyecto_G2.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CambiarContrasenna(UsuarioEnt entidad)
        {
            //Comprobar la actual
            entidad.idUsuario = long.Parse(Session["IdSesion"].ToString());
            entidad.correoElectronico = Session["CorreoSesion"].ToString();
            var respValidar = model.IniciarSesion(entidad);

            //Comprobar la contraseña actual
            if (respValidar == null)
            {
                ViewBag.MsjPantalla = "La contraseña actual es incorrecta";
                return View("Cambiar");
            }

            //Comprobar la nueva y la confirmación
            if (entidad.contrasennaNueva != entidad.confirmarContrasenna)
            {
                ViewBag.MsjPantalla = "Las contraseñas no coinciden";
                return View("Cambiar");
            }

            //Comprobar la actual sea diferente a la nueva
            if (entidad.contrasenna == entidad.contrasennaNueva)
            {
                ViewBag.MsjPantalla = "Debe ingresar una contraseña diferente a la actual";
                return View("Cambiar");
            }

            //Cambiar contraseña correctamente
            var respActualizar = model.CambiarContrasenna(entidad);

            if (respActualizar > 0)
                return RedirectToAction("Principal", "Home");
            else
            {
                ViewBag.MsjPantalla = "No se ha podido actualizar su contraseña";
                return View("Cambiar");
            }
        }
    }


}