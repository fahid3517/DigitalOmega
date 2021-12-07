using DigitalOmega.api.Common;
using DigitalOmega.api.DTOs;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.IP;
using DigitalOmega.api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalOmega.api.Services.Implement
{
    public class IPService : IIPService
    {
        do_insightContext db;
        public IPService(do_insightContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddIP(CreateIPsRequest request, Guid userId)
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
                                await db.Ips.AddAsync(new Ip
                                {

                                    GId = SystemGlobal.GetId(),
                                    Ip1= request.IP,
                                    CreatedAt= DateTime.Now,
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
                                var ips = db.Ips.Find(request.Id);

                                if (ips == null) throw new Exception("IP Not Found");

                                ips.Ip1 = request.IP;
                                ips.GId = request.GId;
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

        public GetIPResponse GetIP(ListGeneralModel page)
        {
            try
            {
                GetIPResponse response = new GetIPResponse();
                using (var db = new do_insightContext())
                {
                    var query = db.Ips.Select(s => new CreateIPsRequest
                    {
                        Id = s.Id,
                        IP = s.Ip1,
                        GId= s.GId,
                        CreatedBy= s.CreatedBy,
                        CreatedAt= s.CreatedAt,
                        
                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.IP.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.IP);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.IP) : query.OrderBy(x => x.IP);
                            break;
                     
                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.IPs = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ip> GetIPByID(Guid? ipGId)
        {
            if (db != null)
            {
                return await db.Ips.Where(x => x.GId == ipGId).Select(s => new Ip
                {
                    Id = s.Id,
                    GId = s.GId,
                    Ip1 = s.Ip1,
                    CreatedAt = s.CreatedAt,
                    CreatedBy = s.CreatedBy,
                   
                }).FirstOrDefaultAsync();
            }

            return null;
        }

        public Task<List<Ip>> GetIPs()
        {
            throw new NotImplementedException();
        }
    }
}
