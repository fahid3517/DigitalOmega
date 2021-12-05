using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateAgentsRequest
    {
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userid")]
        public Guid? UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "agentname")]
        public string? AgentName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "affiliate")]
        public string? Affiliate { get; set; }


    }
}
