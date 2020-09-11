using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class AlunoSkill
    {
        public int IdAlunoSkill { get; set; }
        public int? IdAluno { get; set; }
        public int? IdSkill { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Skill IdSkillNavigation { get; set; }
    }
}
