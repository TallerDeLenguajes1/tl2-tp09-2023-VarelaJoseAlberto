using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TP9.Models;
using TP9.Repositorios;

namespace tp9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository usuarioRepository;
    public UsuarioController()
    {
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("usuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("El objeto Usuario es nulo");
        }

        usuarioRepository.CrearUsuario(usuario);
        return Ok(usuario);
    }

    [HttpGet("usuario")]
    public ActionResult<List<Usuario>> TraerTodosUsuarios()
    {
        var listaDeUsuarios = usuarioRepository.TraerTodosUsuarios();
        if (listaDeUsuarios != null && listaDeUsuarios.Count > 0)
        {
            return Ok(listaDeUsuarios);
        }
        return NotFound("Recursos no encontrados");
    }

    [HttpGet("usuario/{id}")]
    public ActionResult<Usuario> TraerUsuarioPorId(int id)
    {
        var usuario = usuarioRepository.TraerUsuarioPorId(id);
        if (usuario != null)
        {
            return Ok(usuario);
        }
        return NotFound("Recursos no encontrado");
    }


    [HttpDelete("EliminarUsuarioPorId/{idRecibe}")]
    public ActionResult<string> EliminarUsuarioPorId(int idRecibe)
    {
        usuarioRepository.EliminarUsuarioPorId(idRecibe);
        return Ok("Se elimino el usuario");
    }

    [HttpPut("usuario/{id}/Nombre")]
    public ActionResult<Usuario> ModificarUsuario(int id, Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("El objeto Usuario es nulo");
        }
        usuarioRepository.ModificarUsuario(id, usuario);
        return Ok(usuario);
    }
}
