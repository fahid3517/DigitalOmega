using DigitalOmega.api.Request;
using Newtonsoft.Json;

namespace DigitalOmega.api.Response.IP
{
    public class GetIPResponse :ListGeneralModel
    {
        public List<CreateIPsRequest> IPs { get; set; }
    }
}
