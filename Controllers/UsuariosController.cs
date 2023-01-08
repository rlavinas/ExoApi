using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")] 
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository; 
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Usuario usuario)
        {
            _usuarioRepository.Atualizar(Id, usuario);
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Usuario usuario = _usuarioRepository.BuscarPorId(Id);   

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            Usuario usuario = _usuarioRepository.BuscarPorId(Id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                _usuarioRepository.Deletar(Id);
                return StatusCode(204);
            }
        }
    }
}
