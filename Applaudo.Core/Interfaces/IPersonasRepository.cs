using System.Collections.Generic;
using Applaudo.Core.Helpers;
using Applaudo.Core.Models;

namespace Applaudo.Core.Interfaces
{
  public interface IPersonasRepository
  {
    Persona GetById(int id);
    List<Persona> GetAll();
    DataPager<Persona> GetPaginado(string search,int cantXPagina=100,int pagina=1);
    void Delete(int id);
    void AddNew(Persona datos);
    void Update(Persona datosActualizados);
  }
}