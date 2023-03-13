using Entidades.General;
using Entidades.NivelTipoMiembro;
using LogicaNegocios.NivelesTipoMiembro;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NivelTipoMiembroController : ControllerBase
    {
        private ClsNivelTipoMiembro ObjNivelTipoMiembro = null;
        private readonly ClsNivelTipoMiembroLn ObjNivelTipoMiembroLn = new ClsNivelTipoMiembroLn();

        [HttpGet]
        public IActionResult GetNivelesTipoMiembro()
        {
            ObjNivelTipoMiembro = new ClsNivelTipoMiembro();
            ObjNivelTipoMiembroLn.Index(ref ObjNivelTipoMiembro);
            if (ObjNivelTipoMiembro.MensajeError == null)
            {
                if (ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjNivelTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }


        [HttpGet]
        public IActionResult GetNivelTipoMiembro(string id)
        {
            ObjNivelTipoMiembro = new ClsNivelTipoMiembro();
            ObjNivelTipoMiembro.IdNivelTipoMiembro = id.ToString();
            ObjNivelTipoMiembroLn.Read(ref ObjNivelTipoMiembro);
            if (ObjNivelTipoMiembro.MensajeError == null)
            {
                if (ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado= new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjNivelTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            

        }


        [HttpPost]
        public IActionResult CreateNivelTipoMiembro(ClsNivelTipoMiembro niveltipomiembro)
        {
            ObjNivelTipoMiembro = new ClsNivelTipoMiembro();
            ObjNivelTipoMiembro.Descripcion = niveltipomiembro.Descripcion.ToString();
            ObjNivelTipoMiembro.Estado = Convert.ToBoolean(niveltipomiembro.Estado);
            ObjNivelTipoMiembro.Usuario = niveltipomiembro.Usuario.ToString();
            ObjNivelTipoMiembroLn.Create(ref ObjNivelTipoMiembro);
            if (ObjNivelTipoMiembro.MensajeError == null)
            {
                if (ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjNivelTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpPatch]
        public IActionResult UpdateNivelTipoMiembro(ClsNivelTipoMiembro niveltipomiembro)
        {
            ObjNivelTipoMiembro = new ClsNivelTipoMiembro();
            ObjNivelTipoMiembro.IdNivelTipoMiembro = niveltipomiembro.IdNivelTipoMiembro.ToString();
            ObjNivelTipoMiembro.Descripcion = niveltipomiembro.Descripcion.ToString();
            ObjNivelTipoMiembro.Estado = Convert.ToBoolean(niveltipomiembro.Estado);
            ObjNivelTipoMiembro.Usuario = niveltipomiembro.Usuario.ToString();
            ObjNivelTipoMiembroLn.Update(ref ObjNivelTipoMiembro);
            if (ObjNivelTipoMiembro.MensajeError == null)
            {
                if (ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjNivelTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }

        [HttpDelete]
        public IActionResult DeleteNivelTipoMiembro(string id, string usuario)
        {
            ObjNivelTipoMiembro = new ClsNivelTipoMiembro();
            ObjNivelTipoMiembro.IdNivelTipoMiembro = id.ToString();
            ObjNivelTipoMiembro.Usuario = usuario.ToString();
            ObjNivelTipoMiembroLn.Delete(ref ObjNivelTipoMiembro);
            if (ObjNivelTipoMiembro.MensajeError == null)
            {
                if (ObjNivelTipoMiembro.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjNivelTipoMiembro.DtResultados, Formatting.Indented));
            }
            ClsResultado clsResultado = new ClsResultado();
            clsResultado.CodigoError = -1;
            clsResultado.MensajeError = ObjNivelTipoMiembro.MensajeError;
            return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
        }
    }
}