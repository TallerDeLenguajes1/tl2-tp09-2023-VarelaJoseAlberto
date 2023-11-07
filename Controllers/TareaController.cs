using Microsoft.AspNetCore.Mvc;
using TP9.Models;
using TP9.Repositorios;

namespace TP9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaRepository tareaRepository;

        public TareaController()
        {
            tareaRepository = new TareaRepository();
        }

        [HttpPost("{idTablero}")]
        public ActionResult<Tarea> CrearTarea(int idTablero, Tarea nuevaTarea)
        {
            var tareaCreada = tareaRepository.CrearTarea(idTablero, nuevaTarea);
            return Ok(tareaCreada);
        }

        [HttpPut("{idTarea}")]
        public ActionResult<Tarea> ModificarTarea(int idTarea, Tarea tareaModificada)
        {
            var tareaModificad = tareaRepository.ModificarTarea(idTarea, tareaModificada);
            return Ok(tareaModificad);
        }

        [HttpGet("{idTarea}")]
        public ActionResult<Tarea> ObtenerTarea(int idTarea)
        {
            var tarea = tareaRepository.ObtenerTareaPorId(idTarea);
            if (tarea != null)
            {
                return Ok(tarea);
            }
            return NotFound("Tarea no encontrada");
        }

        [HttpGet("usuario/{idUsuario}")]
        public ActionResult<List<Tarea>> ListarTareasPorUsuario(int idUsuario)
        {
            var tareas = tareaRepository.ListarTareasDeUsuario(idUsuario);
            return Ok(tareas);
        }

        [HttpGet("tablero/{idTablero}")]
        public ActionResult<List<Tarea>> ListarTareasPorTablero(int idTablero)
        {
            var tareas = tareaRepository.ListarTareasDeTablero(idTablero);
            return Ok(tareas);
        }

        [HttpDelete("{idTarea}")]
        public ActionResult EliminarTarea(int idTarea)
        {
            tareaRepository.EliminarTarea(idTarea);
            return Ok("Tarea eliminada");
        }

        [HttpPost("asignar")]
        public ActionResult AsignarUsuarioATarea(int idUsuario, int idTarea)
        {
            tareaRepository.AsignarUsuarioATarea(idUsuario, idTarea);
            return Ok("Usuario asignado a tarea");
        }
    }
}
