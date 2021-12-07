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

        [JsonProperty(PropertyName = "dvr")]
        public short? Dvr { get; set; }

        [JsonProperty(PropertyName = "box")]
        public short? Box { get; set; }

        [JsonProperty(PropertyName = "modem")]
        public short? Modem { get; set; }

        [JsonProperty(PropertyName = "wifi")]
        public short? Wifi { get; set; }

        [JsonProperty(PropertyName = "gid")]
        public short? PortedHomePhone { get; set; }

        [JsonProperty(PropertyName = "nativehomephone")]
        public short? NativeHomePhone { get; set; }

        [JsonProperty(PropertyName = "portedmobile")]
        public short? PortedMobile { get; set; }

        [JsonProperty(PropertyName = "nativemobile")]
        public short? NativeMobile { get; set; }

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

    }
}
