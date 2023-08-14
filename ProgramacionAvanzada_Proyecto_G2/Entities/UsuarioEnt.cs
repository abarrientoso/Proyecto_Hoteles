using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramacionAvanzada_Proyecto_G2.Entities
{
    public class UsuarioEnt
    {
        public long idUsuario { get; set; }
        public string correoElectronico { get; set; }
        public string contrasena { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public bool estado { get; set; }
        public int idRol { get; set; }
        public string nombreRol { get; set; }
    }
}