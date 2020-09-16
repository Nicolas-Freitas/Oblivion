using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using APIEmpreGO.Interfaces;
using APIEmpreGO.Models;
using APIEmpreGO.Repositories;
using APIEmpreGO.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace APIEmpreGO.Controllers
{
    //Define o formato da resposta como tipo JSON
    [Produces("aplication/json")]

    [Route("api/[controller]")]

    //Define como ApiControler 
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// <response code="200">Retorna o token gerado</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        /// dominio/api/Login
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                // Busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Instalar as dependências:

                    Criar e validar o JWT
                    System.IdentityModel.Tokens.Jwt(5.5.0 ou superior)

                    Integrar a autenticação
                    Microsoft.AspNetCore.Authentication.JwtBearer(2.1.1 ou compatível com o .Net Core do projeto)
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.TituloTipoUsuario.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Emprego-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "APIEmpreGO.WebApi",                 // emissor do token
                    audience: "APIEmpreGO.WebApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido com uma mensagem personalizada
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}