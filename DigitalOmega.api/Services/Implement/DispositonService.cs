using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Dispositon;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class DispositonService : IDispositonService
    {
        do_insightContext db;
        public DispositonService(do_insightContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddDispositon(CreateDispositonRequest request, Guid userId)
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
                                await db.Dispositions.AddAsync(new Disposition
                                {

                                    GId = SystemGlobal.GetId(),
                                   Status = request.Status,
                                    StatusName = request.StatusName,
                                    Active=request.Active,
                                    CreatedAt=DateTime.Now,
                                    CreatedBy=userId.ToString(),
                                    
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
                                var dispositons = db.Dispositions.Find(request.Id);

                                if (dispositons == null) throw new Exception("Package Not Found");

                                dispositons.Status = request.Status;
                                dispositons.StatusName = request.StatusName;
                                dispositons.Active = request.Active;
                                
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

        public GetDispositonResponse GetDispositon(ListGeneralModel page)
        {
            try
            {
                GetDispositonResponse response = new GetDispositonResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Dispositions.Select(s => new CreateDispositonRequest
                    {
                        Id = s.Id,
                        Status = s.Status,
                        StatusName = s.StatusName,
                        Active = s.Active,
                        CreatedBy=s.CreatedBy,
                        CreatedAt=s.CreatedAt,
                        GId=s.GId,
                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.Status.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.Status);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status);
                            break;
                        case 1:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.StatusName) : query.OrderBy(x => x.StatusName);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Dispositons = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Disposition> GetDispositonByID(Guid? DispositonGId)
        {
            if (db != null)
            {
                return await db.Dispositions.Where(x => x.GId == DispositonGId).Select(s => new Disposition
                {
                    Id = s.Id,
                    GId = s.GId,
                    Status=s.Status,
                    StatusName=s.StatusName,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy,
                    Active = s.Active,
                }).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Disposition>> GetDispositons()
        {
            throw new NotImplementedException();
        }
    }
}
