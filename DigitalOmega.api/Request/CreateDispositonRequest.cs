using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateDispositonRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "status")]
        public string? Status { get; set; }

        [Required]
        [JsonProperty(PropertyName = "statusname")]
        public string? StatusName { get; set; }

        [JsonProperty(PropertyName = "active")]
        public short Active { get; set; }

        [JsonProperty(PropertyName = "createdat")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "createdby")]
        public string? CreatedBy { get; set; }

        [JsonProperty(PropertyName = "gid")]
        public Guid? GId { get; set; }


    }
}
