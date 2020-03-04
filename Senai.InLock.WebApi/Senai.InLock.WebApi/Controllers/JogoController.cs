using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domain;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints jogos da inlock
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class JogoController : ControllerBase
    {
        private Ijogos _JogoRepository { get; set; }
        public JogoController()
        {
            _JogoRepository = new JogosRepository();
        }
        /// <summary>
        /// Controller responsável pelos endpoints listar os jogos da inlock
        /// </summary>
        /// <response code="202">Returns the newly Accepted item</response>

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public IActionResult Get()
        {
            return Ok(_JogoRepository.Listar());
        }
        /// <summary>
        /// Controller responsável pelos endpoints por cadastrar novos jogos da inlock
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="404">If the item is null</response> 

        [Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post(JogosDomain jogos)
        {
            if(jogos == null)
            {
                return NotFound("algum campo invalido");
            }
            else
            {
            _JogoRepository.AdicionarJogo(jogos);
            return Created("Jogo criado com sucesso",jogos);
            }
        }
    }
}