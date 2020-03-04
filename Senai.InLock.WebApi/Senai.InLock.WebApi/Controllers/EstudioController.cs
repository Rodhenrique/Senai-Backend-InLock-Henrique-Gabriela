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
    /// <summary>
    /// Controller responsável pelos endpoints estudios da inlock
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class EstudioController : ControllerBase
    {
        private Iestudios _estudiosRepository { get; set; }

        public EstudioController()
        {
            _estudiosRepository = new EstudiosRepository();
        }
        /// <summary>
        /// Controller responsável pelos endpoints listar os estudios da inlock
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudiosRepository.Listar());
        }
        /// <summary>
        /// Controller responsável pelos endpoints cadastrar um novo estudio da inlock
        /// </summary>
        [HttpPost]
        public IActionResult Post(EstudiosDomain estudios)
        {
            if(estudios == null)
            {
                return NotFound("algum campo invalido");
            }else
            {
            _estudiosRepository.AdicionarEstudio(estudios);
            return Created("Estudio criado com sucesso", estudios);
            }
        }
    }
}