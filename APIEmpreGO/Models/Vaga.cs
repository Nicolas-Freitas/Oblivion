using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Vaga
    {
        public Vaga()
        {
            Skill = new HashSet<Skill>();
            VagaSkill = new HashSet<VagaSkill>();
        }

        public int IdVaga { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdFuncionarioEmpresa { get; set; }
        public string NomeVaga { get; set; }
        public string DescricaoVaga { get; set; }
        public DateTime? DisponibilidadeVaga { get; set; }
        public int? CandidatosVaga { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual FuncionarioEmpresa IdFuncionarioEmpresaNavigation { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
        public virtual ICollection<VagaSkill> VagaSkill { get; set; }
    }
}
