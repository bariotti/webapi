using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("operacoes")]
    public class OperacoesController : Controller
    {
        [HttpOptions("limpar")]
        public IActionResult LimparListaContato()
        {
            try
            {
                Console.WriteLine("Reiniciando Serviço...");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}