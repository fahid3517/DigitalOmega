using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateProvidersRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "createdat")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "createdby")]
        public string? CreatedBy { get; set; }

        [JsonProperty(PropertyName = "active")]
        public short? Active { get; set; }

        [JsonProperty(PropertyName = "deactivatedat")]
        public DateTime? DeactivatedAt { get; set; }

        [JsonProperty(PropertyName = "deactivatedby")]
        public string? DeactivatedBy { get; set; }



        [JsonProperty(PropertyName = "gid")]
        public Guid? GId { get; set; }


    }
}
