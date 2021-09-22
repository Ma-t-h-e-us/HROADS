using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using senai.HRODS.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private IHabilidade _HabilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(Habilidade NovaHabilidade)
        {
            try
            {
                _HabilidadeRepository.Cadastrar(NovaHabilidade);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Habilidade> ListaHabilidade = _HabilidadeRepository.ListarTodos();

                return Ok(ListaHabilidade);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Habilidade HabilidadeBuscado = _HabilidadeRepository.BuscarPorId(id);

                if (HabilidadeBuscado == null)
                {
                    return NotFound("Nehum Habilidade encontrado");
                }
                return Ok(HabilidadeBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, Habilidade NovoHabilidade)
        {
            Habilidade HabilidadeBuscado = _HabilidadeRepository.BuscarPorId(id);

            if (HabilidadeBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Habilidade Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _HabilidadeRepository.AtualizarIdUrl(id, NovoHabilidade);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _HabilidadeRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
