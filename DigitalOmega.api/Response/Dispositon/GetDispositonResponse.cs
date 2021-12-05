using DigitalOmega.api.Request;
using Newtonsoft.Json;

namespace DigitalOmega.api.Response.Dispositon
{
    public class GetDispositonResponse : ListGeneralModel
    {
       
            //[JsonProperty(PropertyName = "dispositons")]
            //public List<CreateDispositonRequest> Dispositons { get; set; } = new List<CreateDispositonRequest>();
        public List<CreateDispositonRequest> Dispositons { get; set; }

    }
}
