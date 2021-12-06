using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateUserRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "user_id")]
        public string? UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }

        [Required]
        [JsonProperty(PropertyName = "role")]
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public short? Active { get; set; }
        public DateTime? DeactivatedAt { get; set; }
        public string? DeactivatedBy { get; set; }

      
        [JsonProperty(PropertyName = "gid")]
        public Guid? GId { get; set; }


    }
}
