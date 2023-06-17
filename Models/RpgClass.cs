using System.Text.Json.Serialization;

namespace coreprac.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knght = 1,
        Mago = 2,
        Cleric = 3
        
    }
}