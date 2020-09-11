using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Skill
    {
        public Skill()
        {
            AlunoSkill = new HashSet<AlunoSkill>();
            VagaSkill = new HashSet<VagaSkill>();
        }

        public int IdSkill { get; set; }
        public int? IdVaga { get; set; }
        public int? IdAluno { get; set; }
        public string NomeSkill { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
        public virtual ICollection<AlunoSkill> AlunoSkill { get; set; }
        public virtual ICollection<VagaSkill> VagaSkill { get; set; }
    }
}
