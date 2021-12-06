using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateAgentsRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "agentid")]
        public string? AgentId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userid")]
        public string? UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "agentname")]
        public string? AgentName { get; set; }


        [Required]
        [JsonProperty(PropertyName = "realname")]
        public string? RealName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "affiliate")]
        public string? Affiliate { get; set; }

        [JsonProperty(PropertyName = "affiliate")]

        public short? Live { get; set; }
        public DateTime? LiveDate { get; set; }
        public string? DialerId { get; set; }
        public short? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

        public Guid? GId { get; set; }

    }
}
