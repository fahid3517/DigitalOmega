using Newtonsoft.Json;

namespace DigitalOmega.api.Request.PhoneNumber
{
    public class GeneralPhone<T>
    {
       

        [JsonProperty(PropertyName = "phone")]
        public string? Phone { get; set; }
    }
}
