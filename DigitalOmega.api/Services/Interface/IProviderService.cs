using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response.Provider;

namespace DigitalOmega.api.Services.Interface
{
    public interface IProviderService
    {
        Task<List<Provider>> GetProviders();
        GetProvidersResponse GetProvider();


        Task<Agent> GetProviderByID(Guid? postId);
        Task<bool> AddProvider(CreateProvidersRequest request, Guid userId);
    }
}
