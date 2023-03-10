using Entidades.General;
using Entidades.TipoMiembro;
using LogicaNegocios.TipoMiembro;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TipoMiembroController : ControllerBase
    {
        private ClsTipoMiembro ObjTipoMiembro = null;
        private readonly ClsTipoMiembroLn ObjTipoMiembroLn = new ClsTipoMiembroLn();

        [HttpGet]
        public IActionResult GetTipoMiembros()
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembroLn.Index(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjTipoMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetTipoMiembro(string id)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = id.ToString();
            ObjTipoMiembroLn.Read(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }

            } else
            {
                ClsResultado clsResultado= new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjTipoMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateTipoMiembro(ClsTipoMiembro tipomiembro)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.Descripcion = tipomiembro.Descripcion.ToString();
            ObjTipoMiembro.Estado = Convert.ToBoolean(tipomiembro.Estado);
            ObjTipoMiembroLn.Create(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjTipoMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateTipoMiembro(ClsTipoMiembro tipomiembro)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = tipomiembro.IdTipoMiembro.ToString();
            ObjTipoMiembro.Descripcion = tipomiembro.Descripcion.ToString();
            ObjTipoMiembro.Estado = Convert.ToBoolean(tipomiembro.Estado);
            ObjTipoMiembroLn.Update(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjTipoMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteTipoMiembro(string id)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = id.ToString(); 
            ObjTipoMiembroLn.Delete(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjTipoMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}