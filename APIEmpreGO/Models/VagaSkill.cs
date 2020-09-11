using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class VagaSkill
    {
        public int IdVagaSkill { get; set; }
        public int? IdVaga { get; set; }
        public int? IdSkill { get; set; }

        public virtual Skill IdSkillNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
