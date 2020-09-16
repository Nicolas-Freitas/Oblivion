using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEmpreGO.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Inforrme o e-mail do usuário")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
