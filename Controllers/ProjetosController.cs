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
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoResposiory;
        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoResposiory = projetoRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoResposiory.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoResposiory.Cadastrar(projeto);
            return StatusCode(201);
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Projeto projeto)
        {
            _projetoResposiory.Atualizar(Id, projeto);
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Projeto projeto = _projetoResposiory.BuscarPorId(Id); 

            if (projeto == null)
            {
                return NotFound();
            }

            return Ok(projeto);
        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            Projeto projeto = _projetoResposiory.BuscarPorId(Id);

            if (projeto == null)
            {
                return NotFound();
            } else
            {
                _projetoResposiory.Deletar(Id);
                return StatusCode(204);
            }
        }

    }
}
