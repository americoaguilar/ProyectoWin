using Entidades.UbigeoEstado;
using Entidades.General;
using LogicaNegocios.UbigeoEstados;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
                if (ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoEstado.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetUbigeoEstado(string id)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = id.ToString();
            ObjUbigeoEstadoLn.Read(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoEstado.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpPost]
        public IActionResult CreateUbigeoEstado(ClsUbigeoEstado ubigeoestado)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.Descripcion = ubigeoestado.Descripcion.ToString();
            ObjUbigeoEstado.IdUbigeoPais = ubigeoestado.IdUbigeoPais.ToString();
            ObjUbigeoEstado.Estado = Convert.ToBoolean(ubigeoestado.Estado);
            ObjUbigeoEstado.Usuario = ubigeoestado.Usuario.ToString();
            ObjUbigeoEstadoLn.Create(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoEstado.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoEstado(ClsUbigeoEstado ubigeoestado)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = ubigeoestado.IdUbigeoEstado.ToString();
            ObjUbigeoEstado.Descripcion = ubigeoestado.Descripcion.ToString();
            ObjUbigeoEstado.IdUbigeoPais = ubigeoestado.IdUbigeoPais.ToString();
            ObjUbigeoEstado.Estado = Convert.ToBoolean(ubigeoestado.Estado);
            ObjUbigeoEstado.Usuario = ubigeoestado.Usuario.ToString();
            ObjUbigeoEstadoLn.Update(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            ClsUbigeoEstado clsResultado = new ClsUbigeoEstado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoEstado.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoEstado(string id, string usuario)
        {
            ObjUbigeoEstado = new ClsUbigeoEstado();
            ObjUbigeoEstado.IdUbigeoEstado = id.ToString();
            ObjUbigeoEstado.Usuario = usuario.ToString();
            ObjUbigeoEstadoLn.Delete(ref ObjUbigeoEstado);
            if (ObjUbigeoEstado.MensajeError == null)
            {
                if (ObjUbigeoEstado.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoEstado.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoEstado.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}