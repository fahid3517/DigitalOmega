using DigitalOmega.api.Common;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response.Provider;
using DigitalOmega.api.Services.Interface;

namespace DigitalOmega.api.Services.Implement
{
    public class ProviderService : IProviderService
    {
        public async Task<bool> AddProvider(CreateProvidersRequest request, Guid userId)
        {
            try
            {
                bool response = false;

                if (request.Id == null)
                {
                    // createnew
                    using (var db = new D_OContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                await db.Providers.AddAsync(new Provider
                                {

                                    Id = SystemGlobal.GetId(),
                                    ProviderName = request.ProviderName
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
                    using (var db = new D_OContext())
                    {
                        using (var trans = db.Database.BeginTransaction())
                        {
                            try
                            {
                                var provider = db.Providers.Find(request.Id);

                                if (provider == null) throw new Exception("Provider Not Found");

                                provider.ProviderName = request.ProviderName;
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

        public GetProvidersResponse GetProvider()
        {
            try
            {
                GetProvidersResponse response = new GetProvidersResponse();
                using (var db = new D_OContext())
                {
                    var query = db.Providers.Select(s => new CreateProvidersRequest
                    {

                        Id = s.Id,
                        ProviderName = s.ProviderName

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

        public Task<Agent> GetProviderByID(Guid? postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Provider>> GetProviders()
        {
            throw new NotImplementedException();
        }
    }
}
