using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TP9.Models;

namespace TP9.Repositorios
{
    public class TareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public Tarea CrearTarea(int idTablero, Tarea nuevaTarea)
        {
            var query = "INSERT INTO Tarea (id_tablero, nombre_tarea, descripcion_tarea, estado_tarea) " +
                        "VALUES (@idTablero, @nombreTarea, @descripcionTarea, @estadoTarea);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", nuevaTarea.NombreTarea));
                command.Parameters.Add(new SQLiteParameter("@descripcionTarea", nuevaTarea.DescripcionTarea));
                connection.Close();
                return nuevaTarea;
            }
        }

        public Tarea ModificarTarea(int idTarea, Tarea tareaModificada)
        {
            var query = "UPDATE Tarea " +
                        "SET nombre_tarea = @nombreTarea, descripcion_tarea = @descripcionTarea, estado_tarea = @estadoTarea " +
                        "WHERE id_tarea = @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombreTarea", tareaModificada.NombreTarea));
                command.Parameters.Add(new SQLiteParameter("@descripcionTarea", tareaModificada.DescripcionTarea));
                command.Parameters.Add(new SQLiteParameter("@estadoTarea", tareaModificada.EstadoTarea.ToString()));
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));

                command.ExecuteNonQuery();
                connection.Close();
            }
            return tareaModificada;
        }

        public Tarea ObtenerTareaPorId(int idTarea)
        {
            var query = "SELECT * FROM Tarea WHERE id_tarea = @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tarea = new Tarea
                        {
                            IdTarea = Convert.ToInt32(reader["id_tarea"]),
                            IdTablero = Convert.ToInt32(reader["id_tablero"]),
                            NombreTarea = reader["nombre_tarea"].ToString(),
                            DescripcionTarea = reader["descripcion_tarea"].ToString(),
                            EstadoTarea = (EstadoTarea)Enum.Parse(typeof(EstadoTarea), reader["estado_tarea"].ToString())
                        };
                        return tarea;
                    }
                }
                connection.Close();
            }
            return null;
        }

        public List<Tarea> ListarTareasDeUsuario(int idUsuario)
        {
            var query = "SELECT * FROM Tarea WHERE id_usuario_asignado = @id_usuario";
            List<Tarea> listaDeTareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id_usuario", idUsuario));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea
                        {
                            IdTarea = Convert.ToInt32(reader["id_tarea"]),
                            NombreTarea = reader["nombre_tarea"].ToString(),
                            DescripcionTarea = reader["descripcion"].ToString()
                        };
                        listaDeTareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return listaDeTareas;
        }

        public List<Tarea> ListarTareasDeTablero(int idTablero)
        {
            var query = "SELECT * FROM Tarea WHERE id_tablero = @idTablero";
            List<Tarea> listaDeTareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea
                        {
                            IdTarea = Convert.ToInt32(reader["id_tarea"]),
                            IdTablero = Convert.ToInt32(reader["id_tablero"]),
                            NombreTarea = reader["nombre_tarea"].ToString(),
                            DescripcionTarea = reader["descripcion_tarea"].ToString(),
                            EstadoTarea = (EstadoTarea)Enum.Parse(typeof(EstadoTarea), reader["estado_tarea"].ToString())
                        };
                        listaDeTareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return listaDeTareas;
        }

        public void EliminarTarea(int idTarea)
        {
            var query = "DELETE FROM Tarea WHERE id_tarea = @idTarea;";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AsignarUsuarioATarea(int idUsuario, int idTarea)
        {
            var query = "INSERT INTO AsignacionTarea (id_usuario, id_tarea) VALUES (@idUsuario, @idTarea);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@id_usuario", idUsuario));
                command.Parameters.Add(new SQLiteParameter("@id_tarea", idTarea));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
