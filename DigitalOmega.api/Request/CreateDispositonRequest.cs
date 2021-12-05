using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateDispositonRequest
    {
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "dispostatus")]
        public string? DispoStatus { get; set; }

        [Required]
        [JsonProperty(PropertyName = "statusname")]
        public string? StatusName { get; set; }

     
    }
}
