using System.Collections.Generic;

namespace Applaudo.Core.Helpers
{
  /// <summary>
  /// Clase generica helper para regresar la informacion de cualquier operacion de paginacion
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public class DataPager<TEntity>
    where TEntity: class
  {

    public DataPager(int totalResultados,List<TEntity> datos)
    {
      TotalResultados = totalResultados;
      Datos = datos;
    }
    /// <summary>
    /// Muestra el total de resultados que se encontraron con ese filteo
    /// </summary>
    public int TotalResultados { get; }
    /// <summary>
    /// Los datos paginados
    /// </summary>
    public IReadOnlyList<TEntity> Datos { get; }
  }
}