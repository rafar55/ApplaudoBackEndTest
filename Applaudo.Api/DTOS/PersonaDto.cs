using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Applaudo.Api.DTOS
{
  /// <summary>
  /// Dto para enviar en los metodos de Insertar y de Actualizar personas
  /// </summary>
  public class PersonaDto
  {
    [Required]
    [MaxLength(80)]
    [JsonProperty(PropertyName = "first")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(80)]
    [JsonProperty(propertyName: "last")]
    public string LastName { get; set; }
    public bool Disabled { get; set; }
  }
}
