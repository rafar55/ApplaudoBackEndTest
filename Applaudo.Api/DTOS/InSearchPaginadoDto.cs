using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Applaudo.Api.DTOS
{
  /// <summary>
  /// Representa una lista de parámetros para los métodos GET, para estandarizar la manera de búsqueda y el paginado
  /// </summary>
  public class SearhDataPaginator
  {

    public SearhDataPaginator()
    {
      Page = 1;
      Per_Page = 100;
    }

    /// <summary>
    /// Texto por el que se desea buscar
    /// </summary>
    public string Q { get; set; }

    /// <summary>
    /// Cantidad de resultados desea que se regresen por pagina.
    /// (Si no se envia el parametro se usara 100 por default)
    /// </summary>
    [Range(1,int.MaxValue)]
    public int Per_Page { get; set; }

    /// <summary>
    /// Pagina que desean consultar.
    /// (Si no se envia el parametro se tomara 1 por deault)
    /// </summary>
    [Range(1,int.MaxValue)]
    public int Page { get; set; }
  }
}