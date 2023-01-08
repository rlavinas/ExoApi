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
    public class AtividadesController : ControllerBase
    {
        private readonly AtividadeRepository _atividadeRepository;

        public AtividadesController(AtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_atividadeRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Atividade atividade)
        {
            _atividadeRepository.Cadastrar(atividade);
            return StatusCode(201);
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Atividade atividade)
        {
            _atividadeRepository.Atualizar(Id, atividade);
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Atividade atividadeBuscada = _atividadeRepository.BuscarPorId(Id);

            if (atividadeBuscada == null)
            {
                return NotFound();
            }

            return Ok(atividadeBuscada);
        }

        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            Atividade atividadeBuscada = _atividadeRepository.BuscarPorId(Id);
            if (atividadeBuscada == null)
            {
                return NotFound();
            }
            else
            {
                _atividadeRepository.Deletar(Id);
                return StatusCode(204);
            }
        }
    }
}
