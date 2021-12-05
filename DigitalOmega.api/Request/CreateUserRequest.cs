using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateUserRequest
    {
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }

        [Required]
        [JsonProperty(PropertyName = "role")]
        public string? Role { get; set; }

    }
}
