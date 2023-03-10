using Entidades.Miembro;
using Entidades.General;
using LogicaNegocios.Miembro;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MiembroController : ControllerBase
    {
        private ClsMiembro ObjMiembro = null;
        private readonly ClsMiembroLn ObjMiembroLn = new ClsMiembroLn();

        [HttpGet]
        public IActionResult GetMiembros()
        {
            ObjMiembro = new ClsMiembro();
            ObjMiembroLn.Index(ref ObjMiembro);
            if (ObjMiembro.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjMiembro.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetMiembro(string id)
        {
            ObjMiembro = new ClsMiembro();
            ObjMiembro.IdMiembro = id.ToString();
            ObjMiembroLn.Read(ref ObjMiembro);
            if (ObjMiembro.MensajeError == null)
            {
                if (ObjMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjMiembro.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateMiembro(ClsMiembro miembro)
        {
            ObjMiembro = new ClsMiembro();
            ObjMiembro.IdCard = miembro.IdCard.ToString();
            ObjMiembro.Nombre = miembro.Nombre.ToString();
            ObjMiembro.IdMiembro = miembro.IdMiembro.ToString();
            ObjMiembro.Estado = Convert.ToBoolean(miembro.Estado);
            ObjMiembroLn.Create(ref ObjMiembro);
            if (ObjMiembro.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjMiembro.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateMiembro(ClsMiembro miembro)
        {
            ObjMiembro = new ClsMiembro();
            ObjMiembro.IdMiembro = miembro.IdMiembro.ToString();
            ObjMiembro.IdCard = miembro.IdCard.ToString();
            ObjMiembro.Nombre = miembro.Nombre.ToString();
            ObjMiembro.IdMiembro = miembro.IdMiembro.ToString();
            ObjMiembro.Estado = Convert.ToBoolean(miembro.Estado);
            ObjMiembroLn.Update(ref ObjMiembro);
            if (ObjMiembro.MensajeError == null)
            {
                if (ObjMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjMiembro.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteMiembro(string id)
        {
            ObjMiembro = new ClsMiembro();
            ObjMiembro.IdMiembro = id.ToString(); 
            ObjMiembroLn.Delete(ref ObjMiembro);
            if (ObjMiembro.MensajeError == null)
            {
                if (ObjMiembro.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjMiembro.DtResultados, Formatting.Indented));
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
                clsResultado.Mensaje_Respuesta = ObjMiembro.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}