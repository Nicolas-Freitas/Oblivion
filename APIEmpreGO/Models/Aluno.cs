using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            AlunoSkill = new HashSet<AlunoSkill>();
            Inscricao = new HashSet<Inscricao>();
            Skill = new HashSet<Skill>();
        }

        public int IdAluno { get; set; }
        public int? IdUsuario { get; set; }
        public string NumeroMatricula { get; set; }
        public string Curso { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public byte[] Curriculo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<AlunoSkill> AlunoSkill { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
