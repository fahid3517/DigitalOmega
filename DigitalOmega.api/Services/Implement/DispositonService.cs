using DigitalOmega.api.Common;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Dispositon;
using DigitalOmega.api.Services.Interface;

namespace DigitalOmega.api.Services.Implement
{
    public class DispositonService : IDispositonService
    {
        public async Task<bool> AddDispositon(CreateDispositonRequest request, Guid userId)
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
                                await db.Dispositons.AddAsync(new Dispositon
                                {

                                    Id = SystemGlobal.GetId(),
                                    DispoStatus = request.DispoStatus,
                                    StatusName = request.StatusName
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
                                var dispositons = db.Dispositons.Find(request.Id);

                                if (dispositons == null) throw new Exception("Package Not Found");

                                dispositons.DispoStatus = request.DispoStatus;
                                dispositons.StatusName = request.StatusName;
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
                using (var db = new D_OContext())
                {
                    var query = db.Dispositons.Select(s => new CreateDispositonRequest
                    {
                        Id = s.Id,
                        DispoStatus = s.DispoStatus,
                        StatusName = s.StatusName,
                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.DispoStatus.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.DispoStatus);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.DispoStatus) : query.OrderBy(x => x.DispoStatus);
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

        public Task<Dispositon> GetDispositonByID(Guid? DispositonId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dispositon>> GetDispositons()
        {
            throw new NotImplementedException();
        }
    }
}
