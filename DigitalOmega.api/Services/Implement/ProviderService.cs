using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Provider;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class ProviderService : IProviderService
    {
        do_insightContext db;
        public ProviderService(do_insightContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddProvider(CreateProvidersRequest request, Guid userId)
        {
            try
            {
                bool response = false;

                if (request.Id == null)
                {
                    // createnew
                    using (var db = new do_insightContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                await db.Providers.AddAsync(new Provider
                                {

                                    GId = SystemGlobal.GetId(),
                                    Name = request.Name,
                                    Active = request.Active,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = userId.ToString(),
                                });
                                await db.SaveChangesAsync();
                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                else
                {
                    using (var db = new do_insightContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var provider = db.Providers.Find(request.Id);

                                if (provider == null) throw new Exception("Provider Not Found");

                                provider.Name = request.Name;
                                provider.Active = request.Active;
                                provider.DeactivatedAt = DateTime.Now;
                                provider.DeactivatedBy=userId.ToString();
                                await db.SaveChangesAsync();

                                trans.Commit();

                                response = true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetProvidersResponse GetProvider(ListGeneralModel page)
        {
            try
            {
                GetProvidersResponse response = new GetProvidersResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Providers.Select(s => new CreateProvidersRequest
                    {

                        Id = s.Id,
                        Name = s.Name,
                        Active = s.Active,
                        GId= s.GId,
                        CreatedAt = s.CreatedAt,
                        CreatedBy = s.CreatedBy,
                        DeactivatedAt= s.DeactivatedAt,
                        DeactivatedBy= s.DeactivatedBy,


                    }).AsQueryable();


                    response.Providers = query.ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Provider> GetProviderByID(Guid? providerGId)
        {
            if (db != null)
            {
                return await db.Providers.Where(x => x.GId == providerGId).Select(s => new Provider
                {
                    Id = s.Id,
                    GId = s.GId,
                    Name = s.Name,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy,
                    Active= s.Active,
                    DeactivatedAt=s.DeactivatedAt,
                    DeactivatedBy=s.DeactivatedBy,
                }).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Provider>> GetProviders()
        {
            throw new NotImplementedException();
        }
    }
}
