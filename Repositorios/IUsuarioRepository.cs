using System;
using TP9.Models;

namespace TP9.Repositorio
{
    public interface IUsuarioRepository
    {
        public void CrearUsuario(Usuario usuario);
        public void ModificarUsuario(int idRecibe, Usuario usuario);
        public List<Usuario> TraerTodosUsuarios();
        public Usuario TraerUsuarioPorId(int id);
        public void EliminarUsuarioPorId(int id);
    }
}