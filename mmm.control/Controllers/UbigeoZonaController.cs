using Entidades.General;
using Entidades.UbigeoZona;
using LogicaNegocios.UbigeoZonas;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UbigeoZonaController : ControllerBase
    {
        private ClsUbigeoZona ObjUbigeoZona = null;
        private readonly ClsUbigeoZonaLn ObjUbigeoZonaLn = new ClsUbigeoZonaLn();

        [HttpGet]
        public IActionResult GetUbigeoZonas()
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZonaLn.Index(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoZona.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetUbigeoZona(string id)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = id.ToString();
            ObjUbigeoZonaLn.Read(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoZona.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateUbigeoZona(ClsUbigeoZona ubigeozona)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.Descripcion = ubigeozona.Descripcion.ToString();
            ObjUbigeoZona.Estado = Convert.ToBoolean(ubigeozona.Estado);
            ObjUbigeoZonaLn.Create(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoZona.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoZona(ClsUbigeoZona ubigeozona)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = ubigeozona.IdUbigeoZona.ToString();
            ObjUbigeoZona.Descripcion = ubigeozona.Descripcion.ToString();
            ObjUbigeoZona.Estado = Convert.ToBoolean(ubigeozona.Estado);
            ObjUbigeoZonaLn.Update(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoZona.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoZona(string id)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = id.ToString(); 
            ObjUbigeoZonaLn.Delete(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoZona.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}