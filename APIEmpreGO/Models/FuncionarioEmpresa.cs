using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class FuncionarioEmpresa
    {
        public FuncionarioEmpresa()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdFuncionarioEmpresa { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        public int? NumeroFuncionario { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
