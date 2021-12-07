using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigitalOmega.api.Request
{
    public class CreateIPsRequest 
    {
   
        public int? Id { get; set; }


        [Required]
        [JsonProperty(PropertyName = "ip")]
        public string? IP { get; set; }

        [JsonProperty(PropertyName = "createdat")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "createdby")]
        public string? CreatedBy { get; set; }

        [JsonProperty(PropertyName = "gid")]
        public Guid? GId { get; set; }


    }
}
