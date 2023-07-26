using ProgramacionAvanzada_Proyecto_G2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProgramacionAvanzada_Proyecto_G2.Models
{
    public class UsuarioModel
    {
        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/IniciarSesion";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }

                return null;
            }
        }

        public int Registrarse(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/Registrarse";
                JsonContent body = JsonContent.Create(entidad); //serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
        public bool RecuperarContrasenna(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RecuperarContrasenna";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }

                return false;
            }
        }

        public int CambiarContrasenna(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/CambiarContrasenna";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }
    }
}