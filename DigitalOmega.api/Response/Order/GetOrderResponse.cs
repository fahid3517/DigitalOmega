using DigitalOmega.api.Request;

namespace DigitalOmega.api.Response.Order
{
    public class GetOrderResponse : ListOrderModel
    {
        //[JsonProperty(PropertyName = "packages")]
        //public List<CreatePackagesRequest> Packages { get; set; } = new List<CreatePackagesRequest>();
        public List<DTOs.Order> Orders { get; set; }
    }
}
