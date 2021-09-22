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
    public class ClassesController : ControllerBase
    {

        private IClasse _ClasseRepository { get; set; }

        public ClassesController()
        {
            _ClasseRepository = new ClasseRepository();
        }

        [HttpPost]
        public IActionResult Post(Classe NovaClasse)
        {
            try
            {
                _ClasseRepository.Cadastrar(NovaClasse);

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
                List<Classe> ListaClasse = _ClasseRepository.ListarTodos();

                return Ok(ListaClasse);
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Classe ClasseBuscado = _ClasseRepository.BuscarPorId(id);

                if (ClasseBuscado == null)
                {
                    return NotFound("Nehum Classe encontrado");
                }
                return Ok(ClasseBuscado);
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, Classe NovoClasse)
        {
            Classe ClasseBuscado = _ClasseRepository.BuscarPorId(id);

            if (ClasseBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Classe Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _ClasseRepository.AtualizarIdUrl(id, NovoClasse);

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
                _ClasseRepository.Deletar(id);

                return StatusCode(201);
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
