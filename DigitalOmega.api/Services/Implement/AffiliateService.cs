using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Affiliate;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class AffiliateService : IAffiliateService
    {

        do_insightContext db;
        public AffiliateService(do_insightContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddAffiliate(CreateAffiliateRequest request, Guid userId)
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
                                await db.Affiliates.AddAsync(new Affiliate
                                {

                                    AffiliatesId = SystemGlobal.GetId(),
                                    UserId=request.UserId,
                                    AffiliateId=request.AffiliateId,
                                    Active=request.Active,
                                    GenericName=request.GenericName,
                                    Name=request.Name,
                                    Address=request.Address,
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
                                var affiliates = db.Affiliates.Find(request.Id);

                                if (affiliates == null) throw new Exception("Affiliate Not Found");

                              //  affiliates.AffiliatesId = request.();
                                affiliates.UserId = request.UserId;
                                affiliates.AffiliateId = request.AffiliateId;
                                affiliates.Active = request.Active;
                                affiliates.GenericName = request.GenericName;
                                affiliates.Name = request.Name;
                                affiliates.Address = request.Address;
                                affiliates.UpdatedAt = DateTime.Now;
                                affiliates.UpdatedBy=userId.ToString();
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

        public GetAffiliateResponse GetAffiliate(ListGeneralModel page)
        {
            try
            {
                GetAffiliateResponse response = new GetAffiliateResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Affiliates.Select(s => new CreateAffiliateRequest
                    {
                        AffiliatesId = s.AffiliatesId,
                        UserId = s.UserId,
                        AffiliateId = s.AffiliateId,
                        Active = s.Active,
                        GenericName = s.GenericName,
                        Name = s.Name,
                        Address = s.Address,
                        //CreatedAt = s.CreatedAt,
                        //CreatedBy = s.ToString(),

                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Name.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.Name);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
                            break;
                        case 1:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.GenericName) : query.OrderBy(x => x.GenericName);
                            break;
                        case 2:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.AffiliateId) : query.OrderBy(x => x.AffiliateId);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Affiliates = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Affiliate> GetAffiliateByID(Guid? affiliateGId)
        {
            if (db != null)
            {
                return await db.Affiliates.Where(x => x.AffiliatesId == affiliateGId).Select(s => new Affiliate
                {
                    Id = s.Id,
                    AffiliatesId = s.AffiliatesId,
                    Name = s.Name,
                    AffiliateId = s.AffiliateId,
                    GenericName= s.GenericName,
                    UserId=s.UserId,
                    Active=s.Active,
                    Address=s.Address,
                    UpdatedAt=s.UpdatedAt,
                    UpdatedBy=s.UpdatedBy,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy,

                }).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Affiliate>> GetAffiliates()
        {
            throw new NotImplementedException();
        }
    }
}
