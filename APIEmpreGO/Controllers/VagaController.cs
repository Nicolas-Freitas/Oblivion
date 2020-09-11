using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIEmpreGO.Models;

namespace APIEmpreGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {

        //Listar todas as vaga
        [HttpGet]
        public string listarTodos()
        {
            return "Todas as Vagas";
        }

        //Listar vaga especifica
        [HttpGet("{id}")]
        public string listarEspecifico(long id)
        {
            return $"Vaga {id}";
        }

        //Colocar vaga especifica
        [HttpPost]
        public string colocarNoBanco(Vaga vaga)
        {
            return $"Colocando Vaga";
        }

        //Deletar vaga especifica
        [HttpDelete("{id}")]
        public string deletar(long id)
        {
            return $"Deletando Vaga {id}";
        }

        //Atualizar vaga especifica
        [HttpPut("{id}")]
        public string atualizarNoBanco(long id, Vaga vaga)
        {
            return $"Atualizando Empresa {id}";
        }
    }
}
