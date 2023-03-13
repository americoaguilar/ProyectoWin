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
                if (ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetTipoMiembro(string id)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = id.ToString();
            ObjTipoMiembroLn.Read(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            } 
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpPost]
        public IActionResult CreateTipoMiembro(ClsTipoMiembro tipomiembro)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.Descripcion = tipomiembro.Descripcion.ToString();
            ObjTipoMiembro.Estado = Convert.ToBoolean(tipomiembro.Estado);
            ObjTipoMiembro.Usuario = tipomiembro.Usuario.ToString();
            ObjTipoMiembroLn.Create(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateTipoMiembro(ClsTipoMiembro tipomiembro)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = tipomiembro.IdTipoMiembro.ToString();
            ObjTipoMiembro.Descripcion = tipomiembro.Descripcion.ToString();
            ObjTipoMiembro.Estado = Convert.ToBoolean(tipomiembro.Estado);
            ObjTipoMiembro.Usuario = tipomiembro.Usuario.ToString();
            ObjTipoMiembroLn.Update(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteTipoMiembro(string id, string usuario)
        {
            ObjTipoMiembro = new ClsTipoMiembro();
            ObjTipoMiembro.IdTipoMiembro = id.ToString();
            ObjTipoMiembro.Usuario = usuario.ToString();
            ObjTipoMiembroLn.Delete(ref ObjTipoMiembro);
            if (ObjTipoMiembro.MensajeError == null)
            {
                if (ObjTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}