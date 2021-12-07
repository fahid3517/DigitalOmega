using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Dispositon;

namespace DigitalOmega.api.Services.Interface
{
    public interface IDispositonService
    {
        Task<List<Disposition>> GetDispositons();
        GetDispositonResponse GetDispositon(ListGeneralModel page);


        Task<Disposition> GetDispositonByID(Guid? DispositonGId);
        Task<bool> AddDispositon(CreateDispositonRequest request, Guid userId);
    }
}
