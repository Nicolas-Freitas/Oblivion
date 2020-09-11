using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Interfaces;
using APIEmpreGO.Models;
using APIEmpreGO.Functions;

namespace APIEmpreGO.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        APIEmpreGOContext ctx = new APIEmpreGOContext();
        public void atualizar(long id, Empresa usuarioAtualizado)
        {
            Empresa usuarioBuscado = listarEspecifico(id);
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

        public void cadastrar(Empresa empresa)
        {
            ctx.Empresa.Add(empresa);
            ctx.SaveChanges();
        }

        public void deletar(long id)
        {
            ctx.Empresa.Remove(listarEspecifico(id));
            ctx.SaveChanges();
        }

        public List<Empresa> listar()
        {
            List<Empresa> listaDeEmpresas = ctx.Empresa.ToList();
            return listaDeEmpresas;
        }

        public Empresa listarEspecifico(long id)
        {
            Empresa empresa = ctx.Empresa.FirstOrDefault(p => p.IdEmpresa == id);
            return empresa;
        }

    }
}
