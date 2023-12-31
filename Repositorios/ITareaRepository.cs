using System.Collections.Generic;
using TP9.Models;

namespace TP9.Repositorios
{
    public interface ITareaRepository
    {
        Tarea CrearTarea(int idTablero, Tarea nuevaTarea);
        Tarea ModificarTarea(int idTarea, Tarea tareaModificada);
        Tarea ObtenerTareaPorId(int idTarea); //
        List<Tarea> ListarTareasDeUsuario(int idUsuario);
        List<Tarea> ListarTareasDeTablero(int idTablero);
        void EliminarTarea(int idTarea);
        void AsignarUsuarioATarea(int idUsuario, int idTarea);
    }
}
