using Newtonsoft.Json;

namespace Applaudo.Core.Models
{
  public class Persona
  {
    public int Id { get; set; }
    [JsonProperty(PropertyName = "first")]
    public string FirstName { get; set; }
    [JsonProperty(propertyName:"last")]
    public string LastName { get; set; }
    public bool Disabled { get; set; }
  }
}