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
    public class UsuariosController : ControllerBase
    {
        private IUsuario _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario NovaUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovaUsuario);

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
                List<Usuario> ListaUsuario = _UsuarioRepository.ListarTodos();

                return Ok(ListaUsuario);
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
                Usuario UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

                if (UsuarioBuscado == null)
                {
                    return NotFound("Nehum Usuario encontrado");
                }
                return Ok(UsuarioBuscado);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, Usuario NovoUsuario)
        {
            Usuario UsuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Usuario Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _UsuarioRepository.AtualizarIdUrl(id, NovoUsuario);

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
                _UsuarioRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
