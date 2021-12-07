using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.IP;

namespace DigitalOmega.api.Services.Interface
{
    public interface IIPService
    {
        Task<List<Ip>> GetIPs();
        GetIPResponse GetIP(ListGeneralModel page);


        Task<Ip> GetIPByID(Guid? ipGId);
        Task<bool> AddIP(CreateIPsRequest request, Guid userId);
    }
}
