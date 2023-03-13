using Entidades.General;
using Entidades.UbigeoPais;
using LogicaNegocios.UbigeoPais;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UbigeoPaisController : ControllerBase
    {
        private ClsUbigeoPais ObjUbigeoPais = null;
        private readonly ClsUbigeoPaisLn ObjUbigeoPaisLn = new ClsUbigeoPaisLn();

        [HttpGet]
        public IActionResult GetUbigeoPaises()
        {
            ObjUbigeoPais = new ClsUbigeoPais();
            ObjUbigeoPaisLn.Index(ref ObjUbigeoPais);
            if (ObjUbigeoPais.MensajeError == null)
            {
                if (ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoPais.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetUbigeoPais(string id)
        {
            ObjUbigeoPais = new ClsUbigeoPais();
            ObjUbigeoPais.IdUbigeoPais = id.ToString();
            ObjUbigeoPaisLn.Read(ref ObjUbigeoPais);
            if (ObjUbigeoPais.MensajeError == null)
            {
                if (ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
            } 
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoPais.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpPost]
        public IActionResult CreateUbigeoPais(ClsUbigeoPais ubigeopais)
        {
            ObjUbigeoPais = new ClsUbigeoPais();
            ObjUbigeoPais.Descripcion = ubigeopais.Descripcion.ToString();
            ObjUbigeoPais.Estado = Convert.ToBoolean(ubigeopais.Estado);
            ObjUbigeoPais.Usuario = ubigeopais.Usuario.ToString();
            ObjUbigeoPaisLn.Create(ref ObjUbigeoPais);
            if (ObjUbigeoPais.MensajeError == null)
            {
                if (ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoPais.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoPais(ClsUbigeoPais ubigeopais)
        {
            ObjUbigeoPais = new ClsUbigeoPais();
            ObjUbigeoPais.IdUbigeoPais = ubigeopais.IdUbigeoPais.ToString();
            ObjUbigeoPais.Descripcion = ubigeopais.Descripcion.ToString();
            ObjUbigeoPais.Estado = Convert.ToBoolean(ubigeopais.Estado);
            ObjUbigeoPais.Usuario = ubigeopais.Usuario.ToString();
            ObjUbigeoPaisLn.Update(ref ObjUbigeoPais);
            if (ObjUbigeoPais.MensajeError == null)
            {
                if (ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoPais.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoPais(string id, string usuario)
        {
            ObjUbigeoPais = new ClsUbigeoPais();
            ObjUbigeoPais.IdUbigeoPais = id.ToString();
            ObjUbigeoPais.Usuario = usuario.ToString();
            ObjUbigeoPaisLn.Delete(ref ObjUbigeoPais);
            if (ObjUbigeoPais.MensajeError == null)
            {
                if (ObjUbigeoPais.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoPais.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoPais.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}