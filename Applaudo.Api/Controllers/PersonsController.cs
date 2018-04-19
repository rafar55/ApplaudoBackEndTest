using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applaudo.Api.DTOS;
using Applaudo.Core.Helpers;
using Applaudo.Core.Interfaces;
using Applaudo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Applaudo.Api.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class PersonsController : Controller
  {
    private readonly IPersonasRepository _personasRepository;

    public PersonsController(IPersonasRepository personasRepository)
    {
      _personasRepository = personasRepository;
    }


    [HttpGet]
    public DataPager<Persona> Get([FromQuery] SearhDataPaginator filtros)
    {
      var datos= _personasRepository.GetPaginado(filtros.Q, filtros.Per_Page, filtros.Page);
      return datos;
    }

    [HttpGet]
    [Route("{id:int}")]
    [Produces(typeof(Persona))]
    public IActionResult Get(int id)
    {
      var persona= _personasRepository.GetById(id);
      if (persona == null) return NotFound();
      return Ok(persona);
    }
  }
}