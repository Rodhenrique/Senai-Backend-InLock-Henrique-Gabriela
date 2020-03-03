using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domain
{
    public class EstudiosDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        [DataType(DataType.Text)]
        public string NomeEstudio { get; set; }

        public JogosDomain jogos { get; set; }
    }
}
