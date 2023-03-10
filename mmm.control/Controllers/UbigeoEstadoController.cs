using Entidades.UbigeoEstado;
using Entidades.General;
using LogicaNegocios.UbigeoEstados;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UbigeoEstadoController : ControllerBase
    {
        private ClsUbigeoEstado ObjUbigeoEstado = null;
        private readonly ClsUbigeoEstadoLn ObjUbigeoEstadoLn = new ClsUbigeoEstadoLn();

        [HttpGet]
        public IActionResult GetUbigeoEstados()
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstadoLn.Index(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoEstado.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetUbigeoEstado(string id)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = id.ToString();
            ObjUbigeoEstadoLn.Read(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoEstado.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateUbigeoEstado(ClsUbigeoEstado ubigeoestado)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.Descripcion = ubigeoestado.Descripcion.ToString();
            ObjUbigeoEstado.Estado = Convert.ToBoolean(ubigeoestado.Estado);
            ObjUbigeoEstadoLn.Create(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoEstado.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoEstado(ClsUbigeoEstado ubigeoestado)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = ubigeoestado.IdUbigeoEstado.ToString();
            ObjUbigeoEstado.Descripcion = ubigeoestado.Descripcion.ToString();
            ObjUbigeoEstado.Estado = Convert.ToBoolean(ubigeoestado.Estado);
            ObjUbigeoEstadoLn.Update(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoEstado.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoEstado(string id)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = id.ToString();
            ObjUbigeoEstadoLn.Delete(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoEstado.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}