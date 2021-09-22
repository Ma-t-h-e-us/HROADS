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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuario _TipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario NovaTipoUsuario)
        {
            try
            {
                _TipoUsuarioRepository.Cadastrar(NovaTipoUsuario);

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
                List<TipoUsuario> ListaTipoUsuario = _TipoUsuarioRepository.ListarTodos();

                return Ok(ListaTipoUsuario);
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
                TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

                if (TipoUsuarioBuscado == null)
                {
                    return NotFound("Nehum TipoUsuario encontrado");
                }
                return Ok(TipoUsuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, TipoUsuario NovoTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "TipoUsuario Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _TipoUsuarioRepository.AtualizarIdUrl(id, NovoTipoUsuario);

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
                _TipoUsuarioRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
