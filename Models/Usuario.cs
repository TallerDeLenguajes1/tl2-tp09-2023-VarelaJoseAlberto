namespace TP9.Models
{
    public class Usuario
    {
        private string nombreDeUsuario;
        private int idUsuario;

        // public Usuario(string nombreDeUsuario)
        // {

        //     NombreDeUsuario = nombreDeUsuario;
        // }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }
    }
}