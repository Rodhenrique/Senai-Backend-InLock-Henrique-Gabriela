using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domain
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O Nome do jogo é obrigatório!")]
        [DataType(DataType.Text)]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "O descrição do jogo é obrigatório!")]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Data De Lançamento do jogo é obrigatório!")]
        [DataType(DataType.DateTime)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Um valor para o jogo é obrigatório!")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Informe o estudio do jogo é obrigatório!")]
        [DataType(DataType.Text)]
        public int IdEstudio { get; set; }
        public EstudiosDomain EstudiosDomain { get; set; }
    }
}
