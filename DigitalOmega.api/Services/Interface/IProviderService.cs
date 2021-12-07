using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Provider;

namespace DigitalOmega.api.Services.Interface
{
    public interface IProviderService
    {
        Task<List<Provider>> GetProviders();
        GetProvidersResponse GetProvider(ListGeneralModel page);


        Task<Provider> GetProviderByID(Guid? ProviderGId);
        Task<bool> AddProvider(CreateProvidersRequest request, Guid userId);
    }
}
