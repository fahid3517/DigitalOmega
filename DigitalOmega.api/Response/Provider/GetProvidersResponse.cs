using DigitalOmega.api.Request;
using Newtonsoft.Json;

namespace DigitalOmega.api.Response.Provider
{
    public class GetProvidersResponse : ListGeneralModel
    {
       
            [JsonProperty(PropertyName = "providers")]
            public List<CreateProvidersRequest> Providers { get; set; } = new List<CreateProvidersRequest>();
        
    }
}
