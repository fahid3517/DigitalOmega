using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.IP;

namespace DigitalOmega.api.Services.Interface
{
    public interface IIPService
    {
        Task<List<Ip>> GetIPs();
        GetIPResponse GetIP(ListGeneralModel page);


        Task<Ip> GetIPByID(Guid? ipId);
        Task<bool> AddIP(CreateIPsRequest request, Guid userId);
    }
}
