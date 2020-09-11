using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Models;

namespace APIEmpreGO.Interfaces
{
    interface IVagaRepository
    {
        //GET
        List<Vaga> listar();
        Vaga listarEspecifico(long id);

        //POST
        void ladastrar(Vaga usuario);

        //DELETE
        void deletar(Vaga usuario);

        //PUT
        void atualizar(long id, Vaga usuario);

    }
}
