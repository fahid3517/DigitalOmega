using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Affiliate;

namespace DigitalOmega.api.Services.Interface
{
    public interface IAffiliateService
    {
        Task<List<Affiliate>> GetAffiliates();
        GetAffiliateResponse GetAffiliate(ListGeneralModel page);


        Task<Affiliate> GetAffiliateByID(Guid? affiliateGId);
        Task<bool> AddAffiliate(CreateAffiliateRequest request, Guid userId);
    }
}
