using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domain;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class TipoUsuarioController : ControllerBase
    {
        private ItipoUsuario _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }
        /// <summary>
        /// Controller responsável pelos endpoints listar os TipoUsuario da inlock
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        /// <summary>
        /// Controller responsável pelos endpoints cadastrar um TipoUsuario da inlock
        /// </summary>
        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain tipo)
        {
            if(tipo == null)
            {
                return NotFound("algum campo invalido");
            }
            else
            {
            _tipoUsuarioRepository.AdicionarTipoUsuario(tipo);
            return Created("TipoUsuario criado com sucesso", tipo);
            }
        }
    }
}