using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewModels
{
    public class LoginViewModel
    {
        // Define que o e-mail é obrigatório
        [Required(ErrorMessage = "Informe o e-mail é obrigatório")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a senha é obrigatória
        [Required(ErrorMessage = "Informe a senha é obrigatório")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
