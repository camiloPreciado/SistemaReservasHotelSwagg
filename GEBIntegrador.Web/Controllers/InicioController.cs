using GEBIntegrador.Core.Servicios.Contrato;
using GEBIntegrador.Dominio;
using GEBIntegrador.Infraestructura;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GEBIntegrador.Dto;
using System.Transactions;
using GEBIntegrador.Dominio.Mensajes;

namespace GEBIntegrador.Web.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        private readonly ISesionService _sesionServicio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="usuarioServicio"></param>
        /// <param name="sesionServicio"></param>
        public InicioController(IUsuarioService usuarioServicio, ISesionService sesionServicio)
        {
            _usuarioServicio = usuarioServicio;
            _sesionServicio = sesionServicio;
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost("Registrarse")]
        public async Task<IActionResult> Registrarse(LoginDto p_usuario)
        {
            usuario usuario_encontrado;
            try
            {
                usuario_encontrado = await _usuarioServicio.Registrarse(p_usuario);
                if (usuario_encontrado.n_id > 0)
                    return RedirectToAction("IniciarSesion", "Inicio");
            }
            catch (TaskCanceledException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgOcurrioUnProblema;
                return View();
            }

            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string p_correo, string p_clave)
        {
            try
            {
                LoginDto usuario = new LoginDto{
                    v_correo = p_correo, v_clave = p_clave
                };

                AlmacenarSesion(await _sesionServicio.IniciarSesion(usuario));

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex )
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio");
        }

        private void AlmacenarSesion(List<Claim> claims)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            //Se pasa todo el esquema del indentiy por la cookie
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties
                );

        }
    }
}
