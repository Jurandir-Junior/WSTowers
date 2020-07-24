using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowersAPI.Models;
using WSTowersAPI.Repositories;

namespace WSTowersAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadiosController : ControllerBase
    {
        EstadiosRepository repository = new EstadiosRepository();

        [HttpGet("concluidos")]
        public ActionResult buscarConcluidos()
        {
            return Ok(repository.GetAllReady());
        }

        [HttpGet("reforma")]
        public ActionResult buscarReforma()
        {
            return Ok(repository.GetAllNonReady());
        }

        [HttpPost("novo")]
        public ActionResult criarEstadio(Estadio estadio)
        {
            try
            {
                repository.Add(estadio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
