using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIEmpreGO.Repositories;
using System.Net;

namespace APIEmpreGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        //Listar todos os usuarios
        [HttpGet]
        public List<Usuario> listarTodos()
        {
            return usuarioRepository.listar();
        }

        //Listar usuario especifico
        [HttpGet("{id}")]
        public Usuario listarEspecifico(long id)
        {
            return usuarioRepository.listarEspecifico(id);
        }

        //Colocar usuario especifico
        [HttpPost]
        public HttpStatusCode colocarNoBanco(Usuario usuario)
        {
            usuarioRepository.cadastrar(usuario);
            return HttpStatusCode.OK;
        }

        //Deletar usuario especifico
        [HttpDelete("{id}")]
        public HttpStatusCode deletar(long id)
        {
            usuarioRepository.deletar(id);
            return HttpStatusCode.OK;
        }

        //Atualizar usuario especifico
        [HttpPut("{id}")]
        public HttpStatusCode atualizarNoBanco(long id, Usuario usuario)
        {
            usuarioRepository.atualizar(id, usuario);
            return HttpStatusCode.OK;
        }
    }
}
