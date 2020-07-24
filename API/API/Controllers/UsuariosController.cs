using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WSTowersAPI.Models;
using WSTowersAPI.Repositories;

namespace WSTowersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuariosRepository repository = new UsuariosRepository();
        [HttpPost("cadastro")]
        public ActionResult cadastrar(Usuario usuario)
        {
            try
            {
                repository.add(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult login(LoginViewModel loginViewModel)
        {
            try
            {
                Usuario usuario = repository.buscarPorEmailSenha(loginViewModel);

                if (usuario != null)
                    return Ok(new { token = gerarToken(usuario) }); 
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private string gerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("Chave_api_Autenticacao_JWT");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
