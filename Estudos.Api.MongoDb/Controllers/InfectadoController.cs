using Estudos.Api.Mongo.Infra.Services;
using Estudos.Api.MongoDb.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Api.MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectadoController : ControllerBase
    {
        private readonly InfectadoService _infectadoService;
        public InfectadoController(InfectadoService infectadoService)
        {
            _infectadoService = infectadoService;
        }

        [HttpGet()]
        public async Task<IActionResult> Listar()
        {
            var infectado = await _infectadoService.ListarTodos();

            return Ok(infectado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(string id)
        {
            var infectado = await _infectadoService.Buscar(id);

            if (infectado is null)
            {
                return NotFound();
            }

            return Ok(infectado);

        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] InfectadoViewModel infectadoViewModel)
        {
            await _infectadoService.Salvar(infectadoViewModel);

            return StatusCode(201, "Adicionado com sucesso.");

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Atualizar(string id, [FromBody] InfectadoViewModel infectadoViewModel)
        {
            var infectado = await _infectadoService.Buscar(id);

            if (infectado is null)
            { 
                return NotFound();
            }

            await _infectadoService.Atualizar(infectado.Id, infectadoViewModel);

            return StatusCode(201, "Atualizado com sucesso.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _infectadoService.Deletar(id);

            return StatusCode(201, "Deletado com sucesso.");

        }
    }
}
