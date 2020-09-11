using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Models;

namespace APIEmpreGO.Interfaces
{
    interface IUsuarioRepository
    {
        //GET
        List<Usuario> listar();
        Usuario listarEspecifico(long id);

        //POST
        void cadastrar(Usuario usuario);

        //DELETE
        void deletar(long id);

        //PUT
        void atualizar(long id, Usuario usuario);

    }
}
