using Entidades.Categoria;
using Entidades.General;
using LogicaNegocios.Categorias;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriaController : ControllerBase
    {
        private ClsCategoria ObjCategoria = null;
        private readonly ClsCategoriaLn ObjCategoriaLn = new ClsCategoriaLn();

        [HttpGet]
        public IActionResult GetCategorias()
        {
            ObjCategoria = new ClsCategoria();
            ObjCategoriaLn.Index(ref ObjCategoria);
            if (ObjCategoria.MensajeError == null)
            {
                if (ObjCategoria.DtResultados.Rows[0][0].ToString().Substring(0, 1) != "-")
                {
                    return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
                }
                return BadRequest(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.CodigoError = -1;
                clsResultado.MensajeError = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }


        [HttpGet]
        public IActionResult GetCategoria(int id)
        {
            ObjCategoria = new ClsCategoria();
            ObjCategoria.IdCategoria = Convert.ToByte(id.ToString());
            ObjCategoriaLn.Read(ref ObjCategoria);
            if (ObjCategoria.MensajeError == null)
            {
                if (ObjCategoria.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.CodigoError = -2;
                    clsResultado.MensajeError = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }

            } else
            {
                ClsResultado clsResultado= new ClsResultado();
                clsResultado.CodigoError = -1;
                clsResultado.MensajeError = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }

        }


        [HttpPost]
        public IActionResult CreateCategoria(ClsCategoria categoria)
        {
            ObjCategoria = new ClsCategoria();
            ObjCategoria.Descripcion = categoria.Descripcion.ToString();
            ObjCategoria.Estado = Convert.ToBoolean(categoria.Estado);
            ObjCategoriaLn.Create(ref ObjCategoria);
            if (ObjCategoria.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.CodigoError = -1;
                clsResultado.MensajeError = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpPatch]
        public IActionResult UpdateCategoria(ClsCategoria categoria)
        {
            ObjCategoria = new ClsCategoria();
            ObjCategoria.IdCategoria = Convert.ToByte(categoria.IdCategoria.ToString());
            ObjCategoria.Descripcion = categoria.Descripcion.ToString();
            ObjCategoria.Estado = Convert.ToBoolean(categoria.Estado);
            ObjCategoriaLn.Update(ref ObjCategoria);
            if (ObjCategoria.MensajeError == null)
            {
                if (ObjCategoria.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.CodigoError = -2;
                    clsResultado.MensajeError = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.CodigoError = -1;
                clsResultado.MensajeError = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategoria(int id)
        {
            ObjCategoria = new ClsCategoria();
            ObjCategoria.IdCategoria = Convert.ToByte(id.ToString()); 
            ObjCategoriaLn.Delete(ref ObjCategoria);
            if (ObjCategoria.MensajeError == null)
            {
                if (ObjCategoria.DtResultados.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
                }
                else
                {
                    ClsResultado clsResultado = new ClsResultado();
                    clsResultado.CodigoError = -2;
                    clsResultado.MensajeError = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.CodigoError = -1;
                clsResultado.MensajeError = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}