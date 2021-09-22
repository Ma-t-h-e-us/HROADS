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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidade _TipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _TipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoHabilidade NovaTipoHabilidade)
        {
            try
            {
                _TipoHabilidadeRepository.Cadastrar(NovaTipoHabilidade);

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
                List<TipoHabilidade> ListaTipoHabilidade = _TipoHabilidadeRepository.ListarTodos();

                return Ok(ListaTipoHabilidade);
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
                TipoHabilidade TipoHabilidadeBuscado = _TipoHabilidadeRepository.BuscarPorId(id);

                if (TipoHabilidadeBuscado == null)
                {
                    return NotFound("Nehum TipoHabilidade encontrado");
                }
                return Ok(TipoHabilidadeBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, TipoHabilidade NovoTipoHabilidade)
        {
            TipoHabilidade TipoHabilidadeBuscado = _TipoHabilidadeRepository.BuscarPorId(id);

            if (TipoHabilidadeBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "TipoHabilidade Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _TipoHabilidadeRepository.AtualizarIdUrl(id, NovoTipoHabilidade);

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
                _TipoHabilidadeRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
