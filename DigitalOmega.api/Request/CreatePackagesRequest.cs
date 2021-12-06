using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreatePackagesRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "abbreviation")]
        public string? Abbreviation { get; set; }

        [Required]
        [JsonProperty(PropertyName = "PSUs")]
        public int? PSUs { get; set; }

        [JsonProperty(PropertyName = "gid")]
        public Guid? GId { get; set; }

    }
}
