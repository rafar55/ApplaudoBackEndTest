using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Applaudo.Api.DTOS
{
  /// <summary>
  /// Representa una lista de parametros para los metodos get para estandarizar la manera de busqueda y de paginado
  /// </summary>
  public class SearhDataPaginator
  {

    public SearhDataPaginator()
    {
      Page = 1;
      Per_Page = 100;
    }

    /// <summary>
    /// Texto por el que se desea buscar en el api
    /// </summary>
    public string Q { get; set; }

    /// <summary>
    /// Cantidad de resultados desea que el api regrese por cada pagina.
    /// Si no se envia el parametro se usara 100 por default
    /// </summary>
    public int Per_Page { get; set; }

    /// <summary>
    /// Pagina que desean consultar en el api
    /// Si no se envia el parametro se tomara 1 por deault
    /// </summary>
    public int Page { get; set; }
  }
}