using Entidades.Habitacion;
using LogicaNegocios.Habitacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace mmm.control.Controllers
{
    [ApiController]
    [Route("api/Habitacion")]
    public class HabitacionController : ControllerBase
    {
        private ClsHabitacion ObjHabitacion = null;
        private readonly ClsHabitacionLn ObjHabitacionLn = new ClsHabitacionLn();

        private readonly ILogger<HabitacionController> _logger;

        public HabitacionController(ILogger<HabitacionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHabitaciones")]
        public IActionResult GetHabitaciones()
        {
            ObjHabitacion = new ClsHabitacion();
            ObjHabitacionLn.Index(ref ObjHabitacion);
            if (ObjHabitacion.MensajeError == null)
            {
                return Ok(JsonConvert.SerializeObject(ObjHabitacion.DtResultados));
            }
            return null;
        }

    }
}