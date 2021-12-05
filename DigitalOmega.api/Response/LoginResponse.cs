using Newtonsoft.Json;

namespace DigitalOmega.api.Response
{
    public class LoginResponse
    {
       
            [JsonProperty(PropertyName = "accessToken")]
            public string AccessToken { get; set; } = "";
        
    }
}
