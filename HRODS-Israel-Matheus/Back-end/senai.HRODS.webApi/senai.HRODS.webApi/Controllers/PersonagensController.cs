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
    public class PersonagensController : ControllerBase
    {
        private IPersonagem _PersonagemRepository { get; set; }

        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        [HttpPost]
        public IActionResult Post(Personagem NovaPersonagem)
        {
            try
            {
                _PersonagemRepository.Cadastrar(NovaPersonagem);

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
                List<Personagem> ListaPersonagem = _PersonagemRepository.ListarTodos();

                return Ok(ListaPersonagem);
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
                Personagem PersonagemBuscado = _PersonagemRepository.BuscarPorId(id);

                if (PersonagemBuscado == null)
                {
                    return NotFound("Nehum Personagem encontrado");
                }
                return Ok(PersonagemBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, Personagem NovoPersonagem)
        {
            Personagem PersonagemBuscado = _PersonagemRepository.BuscarPorId(id);

            if (PersonagemBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Personagem Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _PersonagemRepository.AtualizarIdUrl(id, NovoPersonagem);

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
                _PersonagemRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
