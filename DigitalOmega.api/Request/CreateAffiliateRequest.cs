using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateAffiliateRequest
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "affiliateId")]
        public string? AffiliateId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userId")]
        public string? UserId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [Required]
        [JsonProperty(PropertyName = "genericName")]
        public string? GenericName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string? Address { get; set; }

        [JsonProperty(PropertyName = "Active")]
        public short? Active { get; set; }

        [JsonProperty(PropertyName = "Active")]
        public Guid? AffiliatesId { get; set; }
    }

}
