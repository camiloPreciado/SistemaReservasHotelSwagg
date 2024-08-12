using AutoMapper;
using GEBIntegrador.Core.Servicios.Contrato;
using GEBIntegrador.Dominio;
using GEBIntegrador.Dominio.Mensajes;
using GEBIntegrador.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GEBIntegrador.Web.Controllers
{
    //[Authorize(Roles = "1")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        private readonly IPerfilService _perfilServicio;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="usuarioServicio"></param>
        public UsuariosController(
                                  IUsuarioService usuarioServicio, 
                                  IPerfilService perfilServicio, 
                                  IMapper mapper)
        {
            _usuarioServicio = usuarioServicio;
            _perfilServicio = perfilServicio;
            _mapper = mapper;
        }

        [ClaimsRequirement("Menu", "/Usuarios/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _usuarioServicio.Lista());
        }
        // GET Registrar
        public async Task<IActionResult> _RegistrarPartial()
        {
            ViewBag.items = await cargarListaPerfiles();
            return PartialView();
        }

        [HttpPost("_RegistrarPartial")]
        public async Task<IActionResult> _RegistrarPartial([Bind("v_correo,n_id_perfil,persona")] UsuarioCrearDto usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _usuarioServicio.SaveUsuario(usuario);
                    return Json(new RespuestaDto { success = true, message = "Usuario registrado exitosamente" });
                }
                else
                {
                    // Hay errores de validación, devolver los errores
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();
                    return Json(new RespuestaDto { success = false, messages = errors });
                }
            }
            catch (Exception ex)
            {
                return Json(new RespuestaDto { success = false, message = ex.Message });
            }
        }

        // GET Editar
        public async Task<IActionResult> _EditPartial(int? id)
        {
            usuario usuario = new usuario();
            try
            {
                if (id == null)
                {
                    //ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;// revisar el mensaje
                    return NotFound();
                }

                usuario = await _usuarioServicio.GetUsuario(id);
                if (usuario == null)
                {
                    //ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;// revisar el mensaje
                    return NotFound();
                }
                ViewBag.items = await cargarListaPerfiles();
                var map = _mapper.Map<UsuarioCrearDto>(usuario);
                //return PartialView(_mapper.Map<UsuarioDto>(usuario));
                return PartialView(_mapper.Map<UsuarioCrearDto>(usuario));
            }
            catch (TaskCanceledException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                //return PartialView(usuario);
                return PartialView(_mapper.Map<UsuarioDto>(usuario));
            }
            catch (Exception)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgOcurrioUnProblema;
                //return PartialView(usuario);
                return PartialView(_mapper.Map<UsuarioDto>(usuario));
            }
        }

        [HttpPost("_EditPartial")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> _EditPartial([Bind("n_id,n_id_persona,v_correo,v_usuario,v_clave,n_id_perfil,persona,n_estado")] UsuarioDto usuario)
        //public async Task<IActionResult> _EditPartial([Bind("n_id,n_id_persona,v_correo,v_usuario,n_id_perfil,persona,n_estado")] UsuarioCrearDto usuario)
        public async Task<IActionResult> _EditPartial(UsuarioCrearDto usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //await _usuarioServicio.SaveUsuario(_mapper.Map<usuario>(usuario));
                    await _usuarioServicio.SaveUsuario(usuario);
                    return Json(new RespuestaDto { success = true, message = MensajesSistema.MsgUsuarioActualizado });
                }
                else
                {
                    // Hay errores de validación, devolver los errores
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();
                    return Json(new RespuestaDto { success = false, messages = errors });
                }
            }
            catch (Exception ex)
            {
                return Json(new RespuestaDto { success = false, message = ex.Message });
            }
        }

        // GET Detalles
        public async Task<IActionResult> _DetailsParcial(int? id)
        {
            if (id == null)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;
                return PartialView();
            }

            var usuario = await _usuarioServicio.GetUsuario(id);

            if (usuario == null)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;
                return PartialView();
            }

            return PartialView(_mapper.Map<UsuarioDto>(usuario) );
        }

        // GET Delete
        public async Task<IActionResult> _DeleteParcial(int? id)
        {

            if (id == null)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;
                return PartialView();
            }

            usuario usuario = new usuario();
            try
            {
                usuario = await _usuarioServicio.GetUsuario(id);
                if (usuario == null)
                {
                    ViewData["Mensaje"] = MensajesSistema.MsgUsuarioNoExiste;
                    return PartialView();
                }

                //ViewBag.items = await cargarListaPerfiles();
                return PartialView(_mapper.Map<UsuarioDto>(usuario));
            }
            catch (TaskCanceledException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return PartialView(_mapper.Map<UsuarioDto>(usuario));
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgOcurrioUnProblema +" "+ ex.Message;
                return PartialView(_mapper.Map<UsuarioDto>(usuario));
            }
        }


        // POST: Usuarios/Delete/5
        [HttpPost("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int n_id)
        {
            try
            {
                bool respuesta = await _usuarioServicio.Eliminar(n_id);

                if (respuesta)
                    return Json(new RespuestaDto { success = true, message = MensajesSistema.MsgUsuarioEliminado });
                else
                    return Json(new RespuestaDto { success = false, message = MensajesSistema.MsgNosePudoEliminar });

            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = MensajesSistema.MsgOcurrioUnProblema;
                return Json(new RespuestaDto { success = false, message = ex.Message });
            }
        }

        private async Task<List<SelectListItem>> cargarListaPerfiles()
        {
            List<PerfilDto> lista = await _perfilServicio.ListarActivos();
            List<SelectListItem> items = lista.ConvertAll(p =>
            {
                return new SelectListItem()
                {
                    Text = p.v_descripcion.ToString(),
                    Value = p.n_id.ToString(),
                    Selected = false
                };
            });

            return items;
        }

        [HttpGet("ObtenerUsuariosPorPerfil")]
        public async Task<JsonResult> ObtenerUsuariosPorPerfil(string id_perfil)
        {
            try
            {
                List<usuario> usuarios = new List<usuario>();
                //if (id_perfil != null || id_perfil != 0)
                if (id_perfil != null || id_perfil != "")
                {
                    usuarios = await _usuarioServicio.GetUsuarioByPerfil(int.Parse(id_perfil));
                }
                return Json(new { success = true, data = _mapper.Map<List<UsuarioAutorizadorDto>>(usuarios) });
            }
            catch (Exception ex)
            {
                return Json(new RespuestaDto { success = false, message = ex.Message });
            }
        }
    }

}
