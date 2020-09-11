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
    public class EmpresaController : ControllerBase
    {

        //Listar todos os Empresas
        [HttpGet]
        public string listarTodos()
        {
            return "Todas as Empresas";
        }

        //Listar Empresa especifica
        [HttpGet("{id}")]
        public string listarEspecifico(long id)
        {
            return $"Empresa {id}";
        }

        //Colocar Empresa especifica
        [HttpPost]
        public string colocarNoBanco(Empresa empresa)
        {
            return $"Colocando Empresa";
        }

        //Deletar Empresa especifica
        [HttpDelete("{id}")]
        public string deletar(long id)
        {
            return $"Deletando Empresa {id}";
        }

        //Atualizar Empresa especifica
        [HttpPut("{id}")]
        public string atualizarNoBanco(long id, Empresa empresa)
        {
            return $"Atualizando Empresa {id}";
        }
    }
}
