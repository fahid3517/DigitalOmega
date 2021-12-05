using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Dispositon;

namespace DigitalOmega.api.Services.Interface
{
    public interface IDispositonService
    {
        Task<List<Dispositon>> GetDispositons();
        GetDispositonResponse GetDispositon(ListGeneralModel page);


        Task<Dispositon> GetDispositonByID(Guid? DispositonId);
        Task<bool> AddDispositon(CreateDispositonRequest request, Guid userId);
    }
}
