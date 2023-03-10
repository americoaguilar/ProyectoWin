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
        public IActionResult GetUbigeoCiudads()
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudadLn.Index(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoCiudad.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetUbigeoCiudad(string id)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = id.ToString();
            ObjUbigeoCiudadLn.Read(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoCiudad.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateUbigeoCiudad(ClsUbigeoCiudad ubigeociudad)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.Descripcion = ubigeociudad.Descripcion.ToString();
            ObjUbigeoCiudad.Estado = Convert.ToBoolean(ubigeociudad.Estado);
            ObjUbigeoCiudadLn.Create(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjUbigeoCiudad.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateUbigeoCiudad(ClsUbigeoCiudad ubigeociudad)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = ubigeociudad.IdUbigeoCiudad.ToString();
            ObjUbigeoCiudad.Descripcion = ubigeociudad.Descripcion.ToString();
            ObjUbigeoCiudad.Estado = Convert.ToBoolean(ubigeociudad.Estado);
            ObjUbigeoCiudadLn.Update(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoCiudad.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteUbigeoCiudad(string id)
        {
            ObjUbigeoCiudad = new ClsUbigeoCiudad();
            ObjUbigeoCiudad.IdUbigeoCiudad = id.ToString();
            ObjUbigeoCiudadLn.Delete(ref ObjUbigeoCiudad);
            if (ObjUbigeoCiudad.MensajeError == null)
            {
                if (ObjUbigeoCiudad.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjUbigeoCiudad.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjUbigeoCiudad.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}