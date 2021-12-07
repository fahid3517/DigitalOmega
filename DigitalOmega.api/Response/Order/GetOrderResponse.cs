using DigitalOmega.api.Request;

namespace DigitalOmega.api.Response.Order
{
    public class GetOrderResponse : ListGeneralModel
    {
        //[JsonProperty(PropertyName = "packages")]
        //public List<CreatePackagesRequest> Packages { get; set; } = new List<CreatePackagesRequest>();
        public List<CreateOrderRequest> Orders { get; set; }
    }
}
