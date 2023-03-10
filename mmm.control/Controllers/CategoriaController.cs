using Entidades.Categoria;
using Entidades.General;
using LogicaNegocios.Categorias;
using Microsoft.AspNetCore.Authorization;
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
                return Ok(JsonConvert.SerializeObject(ObjCategoria.DtResultados, Formatting.Indented));
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjCategoria.MensajeError;
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
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }

            } else
            {
                ClsResultado clsResultado= new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjCategoria.MensajeError;
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
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjCategoria.MensajeError;
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
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjCategoria.MensajeError;
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
                    clsResultado.Codigo = -2;
                    clsResultado.Mensaje_Respuesta = "No Existe Id de Registro....";
                    return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
                }
            }
            else
            {
                ClsResultado clsResultado = new ClsResultado();
                clsResultado.Codigo = -1;
                clsResultado.Mensaje_Respuesta = ObjCategoria.MensajeError;
                return BadRequest(JsonConvert.SerializeObject(clsResultado, Formatting.Indented));
            }
        }
    }
}