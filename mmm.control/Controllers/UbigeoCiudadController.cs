using Entidades.UbigeoCiudad;
using Entidades.General;
using LogicaNegocios.UbigeoCiudades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UbigeoCiudadController : ControllerBase
    {
        private ClsUbigeoCiudad ObjUbigeoCiudad = null;
        private readonly ClsUbigeoCiudadLn ObjUbigeoCiudadLn = new ClsUbigeoCiudadLn();

        [HttpGet]
        public IActionResult GetUbigeoCiudades()
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudadLn.Index(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoCiudad.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetUbigeoCiudad(string id)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = id.ToString();
            ObjUbigeoCiudadLn.Read(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoCiudad.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpPost]
        public IActionResult CreateUbigeoCiudad(ClsUbigeoCiudad ubigeociudad)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.Descripcion = ubigeociudad.Descripcion.ToString();
            ObjUbigeoCiudad.IdUbigeoEstado = ubigeociudad.IdUbigeoEstado.ToString();
            ObjUbigeoCiudad.Estado = Convert.ToBoolean(ubigeociudad.Estado);
            ObjUbigeoCiudad.Usuario = ubigeociudad.Usuario.ToString();
            ObjUbigeoCiudadLn.Create(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoCiudad.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoCiudad(ClsUbigeoCiudad ubigeociudad)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = ubigeociudad.IdUbigeoCiudad.ToString();
            ObjUbigeoCiudad.Descripcion = ubigeociudad.Descripcion.ToString();
            ObjUbigeoCiudad.IdUbigeoEstado = ubigeociudad.IdUbigeoEstado.ToString();
            ObjUbigeoCiudad.Estado = Convert.ToBoolean(ubigeociudad.Estado);
            ObjUbigeoCiudad.Usuario = ubigeociudad.Usuario.ToString();
            ObjUbigeoCiudadLn.Update(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoCiudad.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoCiudad(string id, string usuario)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = id.ToString();
            ObjUbigeoCiudad.Usuario = usuario.ToString();
            ObjUbigeoCiudadLn.Delete(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjUbigeoCiudad.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}