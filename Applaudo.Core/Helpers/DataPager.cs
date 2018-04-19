using System.Collections.Generic;

namespace Applaudo.Core.Helpers
{
  /// <summary>
  /// Clase genérica helper para regresar la información de paginado de cualquier entidad
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
    /// Muestra el total de resultados que se encontraron con esos filtros
    /// </summary>
    public int TotalResultados { get; }
    /// <summary>
    /// El listado de datos paginados
    /// </summary>
    public IReadOnlyList<TEntity> Datos { get; }
  }
}