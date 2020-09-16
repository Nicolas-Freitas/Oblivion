using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define os requisitos do campo
        [StringLength(50, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 5 e 50 caracteres")]
        public string SenhaUsuario { get; set; }

        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<FuncionarioEmpresa> FuncionarioEmpresa { get; set; }
    }
}
