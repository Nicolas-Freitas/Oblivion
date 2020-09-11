using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Interfaces;
using APIEmpreGO.Models;
using APIEmpreGO.Functions;

namespace APIEmpreGO.Repositories
{
    public class VagaRepository : IVagaRepository
    {

        APIEmpreGOContext ctx = new APIEmpreGOContext();
        public void atualizar(long id, Vaga vagaAtualizada)
        {
            Vaga vagaBuscada = listarEspecifico(id);
            //if (usuarioAtualizado.IdTipoUsuario != null)
            //{
            //    usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            //}
            //if (String.IsNullOrEmpty(usuarioAtualizado.NomeUsuario) == false)
            //{
            //    usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            //}
            //if (String.IsNullOrEmpty(usuarioAtualizado.SenhaUsuario) != false)
            //{
            //    usuarioBuscado.SenhaUsuario = util.ComputeSha256Hash(usuarioAtualizado.SenhaUsuario);
            //}
            //if (String.IsNullOrEmpty(usuarioAtualizado.Email) != false)
            //{
            //    usuarioBuscado.Email = util.ComputeSha256Hash(usuarioAtualizado.Email);
            //}

            ctx.SaveChanges();
        }

        public void cadastrar(Vaga vaga)
        {
            ctx.Vaga.Add(vaga);
            ctx.SaveChanges();
        }

        public void deletar(long id)
        {
            ctx.Vaga.Remove(listarEspecifico(id));
            ctx.SaveChanges();
        }

        public List<Vaga> listar()
        {
            List<Vaga> listaDeVagas = ctx.Vaga.ToList();
            return listaDeVagas;
        }

        public Vaga listarEspecifico(long id)
        {
            Vaga vaga = ctx.Vaga.FirstOrDefault(p => p.IdVaga == id);
            return vaga;
        }

    }
}
