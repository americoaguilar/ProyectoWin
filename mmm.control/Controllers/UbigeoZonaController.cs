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
                if (ObjUbigeoZona.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoZona.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetUbigeoZona(string id)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = id.ToString();
            ObjUbigeoZonaLn.Read(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoZona.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpPost]
        public IActionResult CreateUbigeoZona(ClsUbigeoZona ubigeozona)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.Descripcion = ubigeozona.Descripcion.ToString();
            ObjUbigeoZona.IdUbigeoCiudad = ubigeozona.IdUbigeoCiudad.ToString();
            ObjUbigeoZona.Estado = Convert.ToBoolean(ubigeozona.Estado);
            ObjUbigeoZona.Usuario = ubigeozona.Usuario.ToString();
            ObjUbigeoZonaLn.Create(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoZona.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoZona(ClsUbigeoZona ubigeozona)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = ubigeozona.IdUbigeoZona.ToString();
            ObjUbigeoZona.Descripcion = ubigeozona.Descripcion.ToString();
            ObjUbigeoZona.IdUbigeoCiudad = ubigeozona.IdUbigeoCiudad.ToString();
            ObjUbigeoZona.Estado = Convert.ToBoolean(ubigeozona.Estado);
            ObjUbigeoZona.Usuario = ubigeozona.Usuario.ToString();
            ObjUbigeoZonaLn.Update(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoZona.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoZona(string id, string usuario)
        {
            ObjUbigeoZona = new ClsUbigeoZona();
            ObjUbigeoZona.IdUbigeoZona = id.ToString();
            ObjUbigeoZona.Usuario = usuario.ToString();
            ObjUbigeoZonaLn.Delete(ref ObjUbigeoZona);
            if (ObjUbigeoZona.MensajeError == null)
            {
                if (ObjUbigeoZona.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoZona.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoZona.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}