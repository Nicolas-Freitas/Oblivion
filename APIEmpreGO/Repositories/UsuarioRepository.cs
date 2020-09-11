using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEmpreGO.Interfaces;
using APIEmpreGO.Models;
using APIEmpreGO.Functions;

namespace APIEmpreGO.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Utils util = new Utils();

        APIEmpreGOContext ctx = new APIEmpreGOContext();
        public void atualizar(long id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = listarEspecifico(id);
            if (usuarioAtualizado.IdTipoUsuario != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }
            if (String.IsNullOrEmpty(usuarioAtualizado.NomeUsuario) == false)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }
            if (String.IsNullOrEmpty(usuarioAtualizado.SenhaUsuario) != false)
            {
                usuarioBuscado.SenhaUsuario = util.ComputeSha256Hash(usuarioAtualizado.SenhaUsuario);
            }
            if (String.IsNullOrEmpty(usuarioAtualizado.Email) != false)
            {
                usuarioBuscado.Email = util.ComputeSha256Hash(usuarioAtualizado.Email);
            }

            ctx.SaveChanges();
        }

        public void cadastrar(Usuario usuario)
        {
            usuario.SenhaUsuario = util.ComputeSha256Hash(usuario.SenhaUsuario);
            Console.WriteLine(usuario.SenhaUsuario);
            Console.WriteLine(usuario.IdTipoUsuario);
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();
        }

        public void deletar(long id)
        {
            ctx.Usuario.Remove(listarEspecifico(id));
            ctx.SaveChanges();
        }

        public List<Usuario> listar()
        {
            List<Usuario> listaDeUsuarios = ctx.Usuario.ToList();
            return listaDeUsuarios;
        }

        public Usuario listarEspecifico(long id)
        {
            Usuario usuario = ctx.Usuario.FirstOrDefault(p => p.IdUsuario == id);
            return usuario;
        }

    }
}
