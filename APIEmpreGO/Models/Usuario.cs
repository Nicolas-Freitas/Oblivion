using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Aluno = new HashSet<Aluno>();
            Empresa = new HashSet<Empresa>();
            FuncionarioEmpresa = new HashSet<FuncionarioEmpresa>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string Email { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<FuncionarioEmpresa> FuncionarioEmpresa { get; set; }
    }
}
