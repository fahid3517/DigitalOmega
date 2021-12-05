using DigitalOmega.api.Request;
using Newtonsoft.Json;

namespace DigitalOmega.api.Response
{
    public class GetUsersResponse : ListGeneralModel
    {
        [JsonProperty(PropertyName = "users")]
        public List<CreateUserRequest> Users { get; set; } = new List<CreateUserRequest>();
    }
}
