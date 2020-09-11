using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Models;

namespace APIEmpreGO.Interfaces
{
    interface IEmpresaRepository
    {
        //GET
        List<Empresa> listar();
        Empresa listarEspecifico(long id);

        //POST
        void cadastrar(Empresa usuario);

        //DELETE
        void deletar(long id);

        //PUT
        void atualizar(long id, Empresa usuario);

    }
}
