using DigitalOmega.api.DTOs;
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


        Task<Package> GetPackageByID(Guid? packageGId);
        Task<bool> AddPackage(CreatePackagesRequest request, Guid userId);
    }
}
