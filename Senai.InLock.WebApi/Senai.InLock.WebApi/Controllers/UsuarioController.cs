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
    public class UsuarioController : ControllerBase
    {
        private Iusuario _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        /// <summary>
        /// Controller responsável pelos endpoints mostrar os usuarios da inlock
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }
        /// <summary>
        /// Controller responsável pelos endpoints cadastrar um novo usuario da inlock
        /// </summary>
        [HttpPost]
        public IActionResult Post(UsuariosDomain usuarios)
        {
            if(usuarios == null)
            {
                return NotFound("algum campo invalido");
            }
            else
            {

            _usuarioRepository.AdicionarNovoUsuario(usuarios);
            return Created("Estudio criado com sucesso", usuarios);
            }
        }
    }
}