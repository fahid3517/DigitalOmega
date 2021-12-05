using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreatePackagesRequest
    {
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "packagename")]
        public string? PackageName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "abbreviation")]
        public string? Abbreviation { get; set; }

        [Required]
        [JsonProperty(PropertyName = "PSUs")]
        public string? PSUs { get; set; }

    }
}
