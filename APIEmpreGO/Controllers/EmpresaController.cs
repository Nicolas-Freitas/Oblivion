using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIEmpreGO.Models;
using APIEmpreGO.Repositories;
using System.Net;

namespace APIEmpreGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        EmpresaRepository empresaRepository = new EmpresaRepository();

        //Listar todos os Empresas
        [HttpGet]
        public List<Empresa> listarTodos()
        {
            return empresaRepository.listar();
        }

        //Listar Empresa especifica
        [HttpGet("{id}")]
        public Empresa listarEspecifico(long id)
        {
            return empresaRepository.listarEspecifico(id);
        }

        //Colocar Empresa especifica
        [HttpPost]
        public HttpStatusCode colocarNoBanco(Empresa empresa)
        {
            empresaRepository.cadastrar(empresa);
            return HttpStatusCode.OK;
        }

        //Deletar Empresa especifica
        [HttpDelete("{id}")]
        public HttpStatusCode deletar(long id)
        {
            empresaRepository.deletar(id);
            return HttpStatusCode.OK;
        }

        //Atualizar Empresa especifica
        [HttpPut("{id}")]
        public HttpStatusCode atualizarNoBanco(long id, Empresa empresa)
        {
            empresaRepository.atualizar(id, empresa);
            return HttpStatusCode.OK;
        }
    }
}
