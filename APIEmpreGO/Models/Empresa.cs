using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            FuncionarioEmpresa = new HashSet<FuncionarioEmpresa>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Contato { get; set; }
        public string Descricao { get; set; }
        public byte[] Logo { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<FuncionarioEmpresa> FuncionarioEmpresa { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
