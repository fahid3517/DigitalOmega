using DigitalOmega.api.Request;

namespace DigitalOmega.api.Response.Affiliate
{
    public class GetAffiliateResponse: ListGeneralModel
    {
            //[JsonProperty(PropertyName = "agents")]
            //public List<CreateAgentsRequest> Agents { get; set; } = new List<CreateAgentsRequest>();

            public List<CreateAffiliateRequest> Affiliates { get; set; }
        
    }
}
