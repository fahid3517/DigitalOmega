using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class LoginRequest
    {
        [Required]
        [JsonProperty(PropertyName = "UserInfo")]
        public string? UserInfo { get; set; }

        [Required]
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }
    }
}
