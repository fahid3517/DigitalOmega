using DigitalOmega.api.Common;
using DigitalOmega.api.Models;
using DigitalOmega.api.Request;
using DigitalOmega.api.Response;
using DigitalOmega.api.Response.Packages;
using DigitalOmega.api.Response.Provider;
using DigitalOmega.api.Services.Interface;

namespace DigitalOmega.api.Services.Implement
{
    public class PackageService : IPackageService
    {
        public async Task<bool> AddPackage(CreatePackagesRequest request, Guid userId)
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
                                await db.Packages.AddAsync(new Package
                                {

                                    Id = SystemGlobal.GetId(),
                                    PackageName = request.PackageName,
                                    Abbreviation = request.Abbreviation,
                                    Psus = request.PSUs
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
                                var package = db.Packages.Find(request.Id);

                                if (package == null) throw new Exception("Package Not Found");

                                package.PackageName = request.PackageName;
                                package.Abbreviation = request.Abbreviation;
                                package.Psus = request.PSUs;
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

        public GetPackgesResponse GetPackage(ListGeneralModel page)
        {
            try
            {
                GetPackgesResponse response = new GetPackgesResponse();
                using (var db = new D_OContext())
                {
                    var query = db.Packages.Select(s => new CreatePackagesRequest
                    {
                        Id = s.Id,
                        PackageName = s.PackageName,
                        Abbreviation = s.Abbreviation,
                        PSUs = s.Psus
                    }).AsQueryable();

                    if (!string.IsNullOrEmpty(page.Search))
                    {
                        var date = new DateTime();
                        var sdate = DateTime.TryParse(page.Search, out date);
                        int totalCases = -1;
                        var isNumber = Int32.TryParse(page.Search, out totalCases);

                        query = query.Where(
                        x => x.PackageName.ToLower().Contains(page.Search.ToLower())
                    );
                    }
                    var orderedQuery = query.OrderByDescending(x => x.PackageName);
                    switch (page.SortIndex)
                    {
                        case 0:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.PackageName) : query.OrderBy(x => x.PackageName);
                            break;
                        case 1:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.Abbreviation) : query.OrderBy(x => x.Abbreviation);
                            break;
                        case 2:
                            orderedQuery = page.SortBy == "desc" ? query.OrderByDescending(x => x.PSUs) : query.OrderBy(x => x.PSUs);
                            break;

                    }
                    response.Page = page.Page;
                    response.PageSize = page.PageSize;
                    response.TotalRecords = orderedQuery.Count();
                    response.Packages = orderedQuery.ToList();
                    //response.IPs = orderedQuery.Skip(page.Page).Take(page.PageSize).ToList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public Task<Agent> GetPackageByID(Guid? postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Package>> GetPackages()
        {
            throw new NotImplementedException();
        }
    }
}
