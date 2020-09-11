using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }
        public int? IdAluno { get; set; }
        public bool? Admicao { get; set; }
        public string Descricao { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
