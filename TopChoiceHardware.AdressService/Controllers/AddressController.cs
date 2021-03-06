using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TopChoiceHardware.AdressService.Application.Services;
using TopChoiceHardware.AdressService.Domain.DTOs;
using TopChoiceHardware.AdressService.Domain.Entities;

namespace TopChoiceHardware.AdressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomicilioController : ControllerBase
    {
        private readonly IDomicilioService _service;

        public DomicilioController(IDomicilioService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Domicilio), StatusCodes.Status201Created)]
        public IActionResult Post(DomicilioDto domicilio)
        {
            try
            {
                return new JsonResult(_service.CrearDomicilio(domicilio)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId?}")]
        public IActionResult GetAdressById(int userId)
        {
            try
            {
                return Ok(_service.DomicilosDeUsuario(userId));
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
