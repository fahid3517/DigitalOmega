using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Packages;
using DigitalOmega.api.Response.Provider;

namespace DigitalOmega.api.Services.Interface
{
    public interface IPackageService
    {
        Task<List<Package>> GetPackages();
        GetPackgesResponse GetPackage(ListGeneralModel page);


        Task<Agent> GetPackageByID(Guid? postId);
        Task<bool> AddPackage(CreatePackagesRequest request, Guid userId);
    }
}
