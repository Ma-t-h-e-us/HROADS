using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.HRODS.webApi.Domains;
using senai.HRODS.webApi.Interfaces;
using senai.HRODS.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.HRODS.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private IUsuario _LoginRepository { get; set; }

        public LoginsController()
        {
            _LoginRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            try
            {
                Usuario UsuarioBuscado = _LoginRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha invÃ¡lidos!");
                }

                var MinhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.TipoUsuarioId.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hrods-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var MeuToken = new JwtSecurityToken(
                        issuer: "hrods.webAPI",
                        audience: "hrods.webAPI",
                        claims: MinhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(MeuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
