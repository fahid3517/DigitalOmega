using DigitalOmega.api.Request;
using Newtonsoft.Json;

namespace DigitalOmega.api.Response.Agent
{
    public class GetAgentsResponse : ListGeneralModel
    {
        //[JsonProperty(PropertyName = "agents")]
        //public List<CreateAgentsRequest> Agents { get; set; } = new List<CreateAgentsRequest>();

        public List<CreateAgentsRequest> Agents { get; set; }
    }
}
