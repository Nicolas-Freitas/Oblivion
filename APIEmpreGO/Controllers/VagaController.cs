﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIEmpreGO.Models;
using APIEmpreGO.Repositories;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace APIEmpreGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagaController : ControllerBase
    {

        VagaRepository vagaRepository = new VagaRepository();

        //Listar todas as vaga
        [HttpGet]
        public List<Vaga> listarTodos()
        {
            return vagaRepository.listar();
        }

        //Listar vaga especifica
        [HttpGet("{id}")]
        public Vaga listarEspecifico(long id)
        {
            return vagaRepository.listarEspecifico(id);
        }

        //Colocar vaga especifica
        [Authorize(Roles = "1")]
        [HttpPost]
        public HttpStatusCode colocarNoBanco(Vaga vaga)
        {
            vagaRepository.cadastrar(vaga);
            return HttpStatusCode.OK;
        }

        //Deletar vaga especifica
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public HttpStatusCode deletar(long id)
        {
            vagaRepository.deletar(id);
            return HttpStatusCode.OK;
        }

        //Atualizar vaga especifica
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public HttpStatusCode atualizarNoBanco(long id, Vaga vaga)
        {
            vagaRepository.atualizar(id, vaga);
            return HttpStatusCode.OK;
        }
    }
}
