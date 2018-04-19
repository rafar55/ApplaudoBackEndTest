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

    /// <summary>
    ///  Regresa un listado de personas segun los filtros y información de paginación
    /// </summary>
    /// <param name="filtros">Filtros y información para paginado</param>
    /// <returns></returns>
    [HttpGet]
    public DataPager<Persona> Get([FromQuery] SearhDataPaginator filtros)
    {
      var datos= _personasRepository.GetPaginado(filtros.Q, filtros.Per_Page, filtros.Page);
      return datos;
    }

    /// <summary>
    /// Regresa la información de una persona
    /// </summary>
    /// <param name="id">Id de la persona que desea</param>
    /// <returns>Regresa los datos de la persona</returns>
    [HttpGet]
    [Route("{id:int}")]
    [Produces(typeof(Persona))]
    public IActionResult Get([FromRoute] int id)
    {
      var persona= _personasRepository.GetById(id);
      if (persona == null) return NotFound();
      return Ok(persona);
    }

    /// <summary>
    ///  Inserta una nueva persona a la base de datos
    /// </summary>
    /// <param name="datos">Información de la persona</param>
    /// <returns>Persona recien insertada</returns>
    [HttpPost]
    [Produces(typeof(Persona))]
    public IActionResult Add([FromBody] PersonaDto datos)
    {
      if (!ModelState.IsValid)return BadRequest(ModelState);

      //Convierto el DTo al model de persona
      //Me gusta usar DTOS para las apis porque no quiero occupar el modelo que esta en el proyecto core directamente
      //por veces los Modelos core o principales tienen propiedades que no son modificables y ademas no me gusta poner
      //los annotation de las validaciones en los modelos del proyecto core.
      var modelo = ConvertirDtoAModel(datos);

      _personasRepository.AddNew(modelo);
      return CreatedAtAction("Get", new {Id = modelo.Id}, datos);
    }

    /// <summary>
    /// Actualiza una persona en la base de datos
    /// </summary>
    /// <param name="id">Id persona desea actualizar</param>
    /// <param name="datosActualizar">Datos que desea cambiar</param>
    /// <returns>Los datos actualizados de la persona</returns>
    [HttpPut]
    [Route("{id:int}")]
    [Produces(typeof(Persona))]
    public IActionResult Update([FromRoute] int id,[FromBody] PersonaDto datosActualizar)
    {
      var personaDb = _personasRepository.GetById(id);
      if (personaDb == null) return NotFound(id);
      if (!ModelState.IsValid) return BadRequest(ModelState);

      //Convierto el DTo al model de persona
      //Me gusta usar DTOS para las apis porque no quiero occupar el modelo que esta en el proyecto core directamente
      //por veces los Modelos core o principales tienen propiedades que no son modificables y ademas no me gusta poner
      //los annotation de las validaciones en los modelos del proyecto core.
      //Convierto el dto Al model de Persona
      var modelo = ConvertirDtoAModel(datosActualizar, id);

      _personasRepository.Update(modelo);

      return Ok($"Persona con el id {id} actualizada correctamente !");
    }

    /// <summary>
    ///  Elimina una persona de la base de datos
    /// </summary>
    /// <param name="id">Id de la persona que desea eliminar</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
      var personaDb = _personasRepository.GetById(id);
      if (personaDb == null) return NotFound($"No se encontro una persona con id {id}");
      _personasRepository.Delete(id);
      return NoContent();
    }


    private Persona ConvertirDtoAModel(PersonaDto dto,int id=0)
    {
      return new Persona()
      {
        Id = id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Disabled = dto.Disabled
      };
    }
  }
}