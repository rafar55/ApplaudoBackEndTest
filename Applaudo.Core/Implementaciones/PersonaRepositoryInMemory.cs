using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Applaudo.Core.Helpers;
using Applaudo.Core.Interfaces;
using Applaudo.Core.Models;

namespace Applaudo.Core.Implementaciones
{
  public class PersonaRepositoryInMemory : IPersonasRepository
  {

    //Simulo la base de datos con esta lista estatica en memoria
    private static readonly List<Persona> MemoryDd=new List<Persona>()
    {
      new Persona(){Id = 1,FirstName = "Rafael",LastName = "Romero"},
      new Persona(){Id = 2,FirstName = "Ernesto",LastName = "Guevara",Disabled = true}
    };



    public Persona GetById(int id)
    {
      return MemoryDd.SingleOrDefault(x => x.Id == id);
    }

    public List<Persona> GetAll()
    {
      //le doy toList() porque quiero una copia no quiere regresar la referencia a la lista interna
      return MemoryDd.ToList();
    }

    public DataPager<Persona> GetPaginado(string search,int cantXPagina=100,int pagina=1)
    {

      if (search == null) search = string.Empty;

      if(pagina<=0) throw new ArgumentException("Tiene que ser superior a 0",nameof(pagina));
      if(cantXPagina<=0) throw new ArgumentException("Tiene que ser superior a 0",nameof(cantXPagina));

      var query = MemoryDd.Where(x =>
        (x.FirstName + " " + x.LastName).Contains(search) || x.Id.ToString().Contains(search)).AsQueryable();
     

      var cantidadSkip = (pagina - 1) * cantXPagina;

      var totalResultados = query.Count();
      var listaPaginada = query.Skip(cantidadSkip).Take(cantXPagina).ToList();

      return new DataPager<Persona>(totalResultados,listaPaginada);
    }

    public void Delete(int id)
    {
      var personaAEliminar = GetById(id);
      if(personaAEliminar==null) return;

      MemoryDd.Remove(personaAEliminar);
    }

    public void AddNew(Persona datos)
    {
      if(datos==null) throw new ArgumentException("No puede ser nulo");

      if (MemoryDd.Any(x => x.Id == datos.Id))
        throw new InvalidOperationException($"Ya existe una persona con el id {datos.Id} en la base de datos");

      MemoryDd.Add(datos);
    }

    public void Update(Persona datosActualizados)
    {
      var personaDb = GetById(datosActualizados.Id);
      if(personaDb==null) throw new InvalidOperationException($"No exite niguna persona con el id {datosActualizados.Id} en la base de datos");

      //Aqui se podria usar automapper o algo para no estar igualando cada propiedad una por una
      personaDb.FirstName = datosActualizados.FirstName;
      personaDb.LastName = datosActualizados.LastName;
    }

    
  }
}