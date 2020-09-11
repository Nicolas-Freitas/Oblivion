using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIEmpreGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        //Listar todos os usuarios
        [HttpGet]
        public string listarTodos()
        {
            return "Todos os usuarios";
        }

        //Listar usuario especifico
        [HttpGet("{id}")]
        public string listarEspecifico(long id)
        {
            return $"Usuario {id}";
        }

        //Colocar usuario especifico
        [HttpPost]
        public string colocarNoBanco(Usuario usuario)
        {
            return $"Colocando Usuario";
        }

        //Deletar usuario especifico
        [HttpDelete("{id}")]
        public string deletar(long id)
        {
            return $"Deletando Usuario {id}";
        }

        //Atualizar usuario especifico
        [HttpPut("{id}")]
        public string atualizarNoBanco(long id, Usuario usuario)
        {
            return $"Atualizando Usuario {id}";
        }
    }
}
